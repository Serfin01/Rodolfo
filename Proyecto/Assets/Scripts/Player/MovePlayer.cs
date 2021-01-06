using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    PlayerInput input;

    Vector2 currentMovement;
    bool movementPressed = false;
    [SerializeField] Rigidbody r_body;
    Vector3 moveDirection;

    private void Awake()
    {
        input = new PlayerInput();
        input.CharacterControls.Movement.performed += ctx => {
            currentMovement = ctx.ReadValue<Vector2>();
            movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
            Debug.Log(ctx.ReadValueAsObject());
        };
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
}
