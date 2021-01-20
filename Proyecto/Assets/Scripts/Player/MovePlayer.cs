﻿using System.Collections;
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
        input.CharacterControls.Dash.canceled += DisableDash;
        dash.emitting = false;
    }

    void HandleMovement()
    {
        if (movementPressed)
        {
            moveDirection = new Vector3(currentMovement.x, 0, currentMovement.y).normalized;
            r_body.velocity = moveDirection * Time.deltaTime * 700;
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
        FixedUpdateDash();
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

    bool performADash = false;
    void Dash(InputAction.CallbackContext obj)
    {
        performADash = true;
    }

    bool mustStop = false;
    void FixedUpdateDash()
    {
        if (performADash)
        {
            performADash = false;
            mustStop = true;

            Vector3 dashMovement = Vector3.zero;
            if (Input.GetAxis("Horizontal") > 0)  { dashMovement.x = distDash;  }
            if (Input.GetAxis("Horizontal") < 0)  { dashMovement.x = -distDash; }
            if (Input.GetAxis("Vertical") > 0)    { dashMovement.z = distDash;  }
            if (Input.GetAxis("Vertical") < 0)    { dashMovement.z = -distDash; }

            if (dashMovement.magnitude > 0.1f)
            {
                r_body.velocity = dashMovement / Time.fixedDeltaTime;
                dash.emitting = true;
                FindObjectOfType<AudioManager>().Play("dash");
            }
        }
        else if (mustStop)
        {
            r_body.velocity = Vector3.zero;
            mustStop = false;
        }
    }

    void DisableDash(InputAction.CallbackContext obj)
    {
        dash.emitting = false;
    }
}
