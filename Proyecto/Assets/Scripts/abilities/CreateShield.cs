using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateShield : MonoBehaviour
{
    [SerializeField] GameObject shield;

    [SerializeField] Image overlayCooldown;
    //[SerializeField] GameObject bola;

    //private bool canShoot;
    

    Ray myRay;
    RaycastHit hit;

    [SerializeField] float cooldown = 3;
    float iniCooldown;

    void Start()
    {
        //shield.SetActive(false);
        iniCooldown = cooldown;
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
        overlayCooldown.GetComponent<Image>().fillAmount = cooldown;
        myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(myRay, out hit))
        {
            if (cooldown <= 0)
            {
                if (Input.GetKeyDown("3"))
                {
                    //Instantiate(shield, hit.point, Quaternion.identity);
                    //Instantiate(bola, hit.point, Quaternion.identity);
                    //Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    //Instantiate(shield, new Vector3(cursorPos.x, 0, cursorPos.z), Quaternion.identity);
                    //cooldown = iniCooldown;
                    InstantiateShield();
                }
            }
        }
    }
    
    void InstantiateShield()
    {
        Instantiate(shield, hit.point, Quaternion.identity);
        cooldown = iniCooldown;
    }
}
