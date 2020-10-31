using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    private float activationTime;
    private bool invi;
    public bool canBeDamaged = true;

    void Start()
    {
        invi = false;
        activationTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        activationTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //this.GetComponent<Collider>().enabled = false;
            //Invi();
            activationTime = 0;
            invi = true;
            
        }
        if(invi == true && activationTime >= 3)
        {
            invi = false;
            //this.GetComponent<Collider>().enabled = true;
            Debug.Log("me ves");
            canBeDamaged = true;
        }
        if(invi == true)
        {
            Invisibility();
        }
    }

    void Invisibility()
    {
        //this.GetComponent<Collider>().enabled = false;
        Debug.Log("no me ves");
        canBeDamaged = false;
    }
}
