﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayoLaser : MonoBehaviour
{

    private LineRenderer lr;

    private bool canShoot;
    //[SerializeField] float shotDuration;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
            //if (hit.collider == Collider.FindObjectOfType<"enemy">)
        }
        else lr.SetPosition(1, transform.forward * 5000);
    }
    
}
/*public class rayoLaser : MonoBehaviour
{

    private LineRenderer lr;
    public Camera cam;
    public LineRenderer lineRenderer;
    public Transform firePoint;
    // Use this for initialization
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, firePoint.position);
        RaycastHit hit;
        var mousePos = (Vector3)cam.ScreenToWorldPoint(Input.mousePosition);

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, mousePos);
            }
        }
        else lr.SetPosition(1, transform.forward * 5000);
    }
}*/