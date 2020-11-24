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
    [SerializeField] GameObject bulletsFase1;
    [SerializeField] GameObject bulletsFase2;

    bool canDash = true;
    int lastFase;
    float cooldown;
    bool ranged = false;

    void Start()
    {
        trPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        iniMoveSpeed = moveSpeed;
        waitTime = startWaitTime;
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
                break;
            case 3:
                //bullet1
                if (lastFase != fase)
                {
                    lastFase = fase;
                }
                Debug.Log("bullet1");
                break;
            case 4:
                //raned2
                if (lastFase != fase)
                {
                    lastFase = fase;
                }
                Debug.Log("raned2");
                break;
            case 5:
                //bullet2
                if (lastFase != fase)
                {
                    lastFase = fase;
                }
                Debug.Log("bullet2");
                break;
            case 6:
                switch (lastFase)
                {
                    case 1:
                        if (WaitTime())
                        {
                            fase = 2;
                        }
                        break;
                    case 2:
                        if (WaitTime())
                        {
                            fase = 2;
                        }
                        break;
                    case 3:
                        if (WaitTime())
                        {
                            fase = 2;
                        }
                        break;
                    case 4:
                        if (WaitTime())
                        {
                            fase = 2;
                        }
                        break;
                    case 5:
                        if (WaitTime())
                        {
                            fase = 2;
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

    }

    public IEnumerator BulletsFase1()
    {
        bulletsFase1.SetActive(true);

        yield return new WaitForSeconds(bossAttack);

        bulletsFase1.SetActive(false);
    }

    void RangedFase2()
    {

    }

    public IEnumerator BulletsFase2()
    {
        bulletsFase2.SetActive(true);

        yield return new WaitForSeconds(bossAttack);

        bulletsFase2.SetActive(false);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
