﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mano : MonoBehaviour
{
    PlayerInput input;

    [SerializeField] GameObject bala;
    private float timer;
    [SerializeField] ParticleSystem Muzzle;
    /*
    Vector3 mousePos;
    [SerializeField] Camera cam;
    private Rigidbody rb; 
    */

    private void Awake()
    {
        input = new PlayerInput();
        input.CharacterControls.Shoot.performed += Disparar;
    }

    private void OnEnable()
    {
        input.CharacterControls.Enable();
    }

    private void OnDisable()
    {
        input.CharacterControls.Disable();
    }

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        timer = 0;
    }
    
    void Update()
    {
        timer += Time.deltaTime;
    }

    void Disparar(InputAction.CallbackContext obj)
    {
        if (timer >= 0.5)
        {

            Instantiate(bala, transform.position, transform.rotation);
            
            Muzzle.Play();
            
            timer = 0;
        }
    }

    
    /*
    void FixedUpdate()
    {
        Vector3 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan(lookDir.y) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    */
}
