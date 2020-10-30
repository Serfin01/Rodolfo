using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mano : MonoBehaviour
{
    [SerializeField] GameObject bala;
    /*
    Vector3 mousePos;
    [SerializeField] Camera cam;
    private Rigidbody rb; 
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    */
    void Update()
    {
        Disparar();
    }

    void Disparar()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bala, transform.position, transform.rotation);
            //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            
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
