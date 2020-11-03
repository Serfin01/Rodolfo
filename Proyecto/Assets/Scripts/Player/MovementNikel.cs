using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNikel : MonoBehaviour
{

    public int speed;
    Vector3 moveDirection;
    [SerializeField] int distDash;
    [SerializeField] TrailRenderer dash;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal")* speed * Time.deltaTime,0,Input.GetAxis("Vertical")*speed* Time.deltaTime);

        moveDirection = Vector3.ClampMagnitude(moveDirection, 1);

        transform.Translate(moveDirection);

        Dash();
    }

    void Dash() {

        if (Input.GetKeyDown(KeyCode.Space)) {

            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.Translate(distDash, 0, 0);
                dash.emitting = true;
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.Translate(-distDash, 0, 0);
                dash.emitting = true;
            }
            if (Input.GetAxis("Vertical") > 0)
            {
                transform.Translate(0, 0, distDash);
                dash.emitting = true;
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                transform.Translate(0, 0, -distDash);
                dash.emitting = true;
            }

        }
        else
        {
            dash.emitting = false;
        }


    }
}
