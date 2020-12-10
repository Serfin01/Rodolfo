using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateShield : MonoBehaviour
{
    [SerializeField] GameObject shield;

    //[SerializeField] Image overlayCooldown;
    //[SerializeField] GameObject bola;

    //private bool canShoot;
    

    Ray myRay;
    RaycastHit hit;

    //[SerializeField] float cooldown = 1;

    private bool isCooldown = false;
    private float cooldown;
    [SerializeField] float iniCooldown;
    [SerializeField] Image imageCooldown;
    //float iniCooldown;

    void Start()
    {
        //shield.SetActive(false);
        imageCooldown.fillAmount = 0.0f;
    }

    void Update()
    {
        myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (isCooldown)
        {
            ApplyCooldown();
        }

        if (Physics.Raycast(myRay, out hit))
        {
            if (Input.GetKeyDown("3"))
            {
                UseSpell();
            }
        }
    }

    void ApplyCooldown()
    {
        cooldown -= Time.deltaTime;

        if (cooldown < 0.0f)
        {
            isCooldown = false;
            imageCooldown.fillAmount = 0.0f;
        }
        else
        {
            imageCooldown.fillAmount = cooldown / iniCooldown;
        }
    }

    public void UseSpell()
    {
        if (isCooldown)
        {
            //StartCoroutine(Shot());
        }
        else
        {
            InstantiateShield();
            isCooldown = true;
            cooldown = iniCooldown;
        }
    }

    void InstantiateShield()
    {
        Instantiate(shield, hit.point, Quaternion.identity);
        cooldown = iniCooldown;
    }
}
