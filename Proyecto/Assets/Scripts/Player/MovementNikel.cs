using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNikel : MonoBehaviour
{

    public int speed;
    Vector3 moveDirection;
    [SerializeField] int distDash;
    [SerializeField] TrailRenderer dash;
    public AudioSource audio;
    public static bool isGodModOn = false;
    public CapsuleCollider colider;
    public GameObject canvas;
    public Rigidbody r_body;

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

        if (Input.GetAxis("Vertical") != 0 && audio.isPlaying == false)
        {
            audio.volume = Random.Range(0.2f, 0.4f);
            audio.pitch = Random.Range(0.8f, 1.1f);
            audio.Play();
        }
        if (Input.GetAxis("Horizontal") != 0 && audio.isPlaying == false)
        {
            audio.volume = Random.Range(0.2f, 0.4f);
            audio.pitch = Random.Range(0.8f, 1.1f);
            audio.Play();
        }
        if(Input.GetKeyDown(KeyCode.F10))
        {
            if (isGodModOn)
            {
                GodModOn();
            }
            else
            {
                GodModOff();
                isGodModOn = true;
            }
        }

        Dash();
    }

    void GodModOn()
    {
        Debug.Log("GodModeON");
        colider.isTrigger = true;
        canvas.SetActive(true);
        isGodModOn = false;
        r_body.useGravity = false;
        transform.gameObject.tag = "Untagged";
    }

    void GodModOff()
    {
        Debug.Log("GodModeOFF");
        colider.isTrigger = false;
        canvas.SetActive(false);
        isGodModOn = true;
        r_body.useGravity = true;
        transform.gameObject.tag = "Player";
    }

    void Dash() {

        if (Input.GetKeyDown(KeyCode.Space)) {

            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.Translate(distDash, 0, 0);
                dash.emitting = true;
                FindObjectOfType<AudioManager>().Play("dash");
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.Translate(-distDash, 0, 0);
                dash.emitting = true;
                FindObjectOfType<AudioManager>().Play("dash");
            }
            if (Input.GetAxis("Vertical") > 0)
            {
                transform.Translate(0, 0, distDash);
                dash.emitting = true;
                FindObjectOfType<AudioManager>().Play("dash");
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                transform.Translate(0, 0, -distDash);
                dash.emitting = true;
                FindObjectOfType<AudioManager>().Play("dash");

            }

        }
        else
        {
            dash.emitting = false;
        }
    }
}
