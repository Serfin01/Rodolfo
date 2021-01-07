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

    private void Awake()
    {
        input = new PlayerInput();
        input.CharacterControls.Movement.performed += ctx => {
            currentMovement = ctx.ReadValue<Vector2>();
            movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
            Debug.Log(ctx.ReadValueAsObject());
        };
        input.CharacterControls.GodMode.performed += GodMode;
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
}
