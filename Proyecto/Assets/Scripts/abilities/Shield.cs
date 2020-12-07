using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] GameObject shield;
    [SerializeField] GameObject bola;

    private bool canShoot;
    [SerializeField] float shotDuration;

    Ray myRay;
    RaycastHit hit;

    void Start()
    {
        //shield.SetActive(false);
    }

    void Update()
    {
        myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(myRay, out hit))
        {
            if (Input.GetKeyDown("3"))
            {
                Debug.Log("escudo");
                Instantiate(shield, hit.point, Quaternion.identity);
                Instantiate(bola, hit.point, Quaternion.identity);
                //Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //Instantiate(shield, new Vector3(cursorPos.x, 0, cursorPos.z), Quaternion.identity);

            }
        }
        /*if (Input.GetKeyDown("3"))
        {
            //StartCoroutine(Shot());
            //Vector3 mousePos = Input.mousePosition;
            //Vector3 objectPos = Camera.current.ScreenToWorldPoint(mousePos);
            //Instantiate(shield, objectPos, Quaternion.identity);
            myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(myRay, out hit))
            {

            }
                Instantiate(shield, transform.position, transform.rotation);
            Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(shield, new Vector3(cursorPos.x, 0, cursorPos.z), Quaternion.identity);

        }
        */
        /*
        if (canShoot == true)
        {
            shield.SetActive(true);
        }
        if (canShoot == false)
        {
            shield.SetActive(false);
        }
    }

    private IEnumerator Shot()
    {
        canShoot = true;
        //Debug.Log("on");
        yield return new WaitForSeconds(shotDuration);
        canShoot = false;
        //Debug.Log("off");
    }
    */
    }
}
