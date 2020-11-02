using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Mano : MonoBehaviour
{
    [SerializeField] GameObject bala;
    private float timer;
    [SerializeField] ParticleSystem Muzzle;
    /*
    Vector3 mousePos;
    [SerializeField] Camera cam;
    private Rigidbody rb; 
    */
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        timer = 0;
    }
    
    void Update()
    {
        Disparar();
        timer += Time.deltaTime;
    }

    void Disparar()
    {


        if (Input.GetMouseButton(0) && timer >= 0.5)
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
