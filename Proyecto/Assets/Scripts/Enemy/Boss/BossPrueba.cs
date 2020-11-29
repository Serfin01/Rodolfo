using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPrueba : MonoBehaviour
{
    Transform trPlayer;
    [SerializeField] float moveSpeed = 3.0f;
    private bool canMove = true;

    int fase = 1;

    private float waitTime;
    [SerializeField] float startWaitTime;

    private float iniMoveSpeed;
    [SerializeField] float dashTime;

    [SerializeField] private float bossAttack;
    //[SerializeField] GameObject bulletsFase1;
    //[SerializeField] GameObject bulletsFase2;
    [SerializeField] ParticleSystem bulletsFase1;
    [SerializeField] ParticleSystem bulletsFase2;

    bool canDash = true;
    int lastFase;
    float cooldown;
    bool ranged = false;

    [SerializeField] int health = 500;
    private int maxHealth;

    [SerializeField] GameObject punch;

    void Start()
    {
        trPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        iniMoveSpeed = moveSpeed;
        waitTime = startWaitTime;
        maxHealth = health;
        bulletsFase1.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            transform.LookAt(trPlayer);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        switch (fase)
        {
            case 1:
                //dash
                if(lastFase != fase)
                {
                    lastFase = fase;
                }
                if (canDash)
                {
                    waitTime -= Time.deltaTime;
                    if (waitTime <= 0)
                    {
                        Debug.Log("dash");
                        StartCoroutine(Dash());
                        waitTime = startWaitTime;
                    }
                }
                break;
            case 2:
                //ranged1
                if (lastFase != fase)
                {
                    lastFase = fase;
                }
                Debug.Log("ranged1");
                RangedFase1();
                break;
            case 3:
                //bullet1
                if (lastFase != fase)
                {
                    lastFase = fase;
                }
                Debug.Log("bullet1");
                StartCoroutine(BulletsFase1());
                break;
            case 4:
                //raned2
                if (lastFase != fase)
                {
                    lastFase = fase;
                }
                Debug.Log("ranged2");
                RangedFase2();
                break;
            case 5:
                //bullet2
                if (lastFase != fase)
                {
                    lastFase = fase;
                }
                Debug.Log("bullet2");
                StartCoroutine(BulletsFase2());
                break;
            case 6:
                switch (lastFase)
                {
                    case 1:
                        if (WaitTime())
                        {
                            //fase = 2;
                            if (health <= maxHealth / 2)
                            {
                                fase = 4;
                            }
                            else
                            {
                                fase = 2;
                            }
                        }
                        break;
                    case 2:
                        if (WaitTime())
                        {
                            fase = 3;
                            Debug.Log("estoy caso2");
                        }
                        break;
                    case 3:
                        if (WaitTime())
                        {
                            fase = 1;
                        }
                        break;
                    case 4:
                        if (WaitTime())
                        {
                            fase = 5;
                        }
                        break;
                    case 5:
                        if (WaitTime())
                        {
                            fase = 1;
                        }
                        break;

                }
                break;
            default:
                fase = 1;
                break;
        }
    }

    bool WaitTime()
    {
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            return false;
        }
        return true;
    }

    public IEnumerator Dash()
    {
        moveSpeed = 20;
        canDash = false;

        yield return new WaitForSeconds(dashTime);

        moveSpeed = iniMoveSpeed;
        canDash = true;

        cooldown = 1;
        fase = 6;
    }

    void RangedFase1()
    {
        Instantiate(punch, transform.position, transform.rotation);
        cooldown = 1;
        fase = 6;
    }

    public IEnumerator BulletsFase1()
    {
        //bulletsFase1.SetActive(true);
        bulletsFase1.Play();

        yield return new WaitForSeconds(bossAttack);

        bulletsFase1.Stop();
        //bulletsFase1.SetActive(false);

        cooldown = 1;
        fase = 6;
    }

    void RangedFase2()
    {


        cooldown = 1;
        fase = 6;
    }

    public IEnumerator BulletsFase2()
    {
        //bulletsFase2.SetActive(true);

        yield return new WaitForSeconds(bossAttack);

        //bulletsFase2.SetActive(false);

        cooldown = 1;
        fase = 6;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
