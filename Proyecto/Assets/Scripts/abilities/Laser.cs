using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] GameObject rayo;

    private bool canShoot;
    [SerializeField] float shotDuration;

    void Start()
    {
        rayo.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("4"))
        {
            StartCoroutine(Shot());
        }

        if (canShoot == true)
        {
            rayo.SetActive(true);
        }
        if (canShoot == false)
        {
            rayo.SetActive(false);
        }
    }

    private IEnumerator Shot()
    {
        canShoot = true;
        Debug.Log("on");
        yield return new WaitForSeconds(shotDuration);
        canShoot = false;
        Debug.Log("off");
    }
}
