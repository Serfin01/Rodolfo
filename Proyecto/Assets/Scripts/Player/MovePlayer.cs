using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    PlayerInput input;

    Vector2 currentMovement;
    bool movementPressed = false;
    Vector3 moveDirection;
    
    public CapsuleCollider colider;
    public GameObject canvas;
    public static bool isGodModOn = true;
    public Rigidbody r_body;

    [SerializeField] int distDash;
    [SerializeField] TrailRenderer dash;

    private void Awake()
    {
        input = new PlayerInput();
        input.CharacterControls.Movement.performed += ctx => {
            currentMovement = ctx.ReadValue<Vector2>();
            movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
            Debug.Log(ctx.ReadValueAsObject());
        };
        input.CharacterControls.GodMode.performed += GodMode;
        input.CharacterControls.Dash.performed += Dash;
        dash.emitting = false;
    }

    void HandleMovement()
    {
        if (movementPressed)
        {
            moveDirection = new Vector3(currentMovement.x, 0, currentMovement.y).normalized;
            r_body.velocity = moveDirection * Time.deltaTime * 500;
        }
    }

    private void OnEnable()
    {
        input.CharacterControls.Enable();
    }

    private void OnDisable()
    {
        input.CharacterControls.Disable();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    void GodMode(InputAction.CallbackContext obj)
    {
        if (isGodModOn)
        {
            GodModOn();
        }
        else
        {
            GodModOff();
            isGodModOn = true;
        }
    }

    void GodModOn()
    {
        Debug.Log("GodModeON");
        colider.isTrigger = true;
        canvas.SetActive(true);
        isGodModOn = false;
        r_body.useGravity = false;
        transform.gameObject.tag = "Untagged";
    }

    void GodModOff()
    {
        Debug.Log("GodModeOFF");
        colider.isTrigger = false;
        canvas.SetActive(false);
        isGodModOn = true;
        r_body.useGravity = true;
        transform.gameObject.tag = "Player";
    }

    void Dash(InputAction.CallbackContext obj)
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(distDash, 0, 0);
            //dash.emitting = true;
            FindObjectOfType<AudioManager>().Play("dash");
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(-distDash, 0, 0);
            //dash.emitting = true;
            FindObjectOfType<AudioManager>().Play("dash");
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.Translate(0, 0, distDash);
            //dash.emitting = true;
            FindObjectOfType<AudioManager>().Play("dash");
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            transform.Translate(0, 0, -distDash);
            //dash.emitting = true;
            FindObjectOfType<AudioManager>().Play("dash");
        }
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            //dash.emitting = false;
            Debug.Log("dash fuera");
        }
    }
}
