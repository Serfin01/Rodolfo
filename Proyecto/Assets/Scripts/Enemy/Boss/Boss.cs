using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Transform trPlayer;
    private float rotSpeed = 3.0f;
    private float moveSpeed = 3.0f;
    [SerializeField] float gzRange = 10;

    private int maxHealth;
    [SerializeField] int health = 500;
    //public GameObject deathEffect;
    public bool isInvulnerable = false;
    public bool canMove = true;
    float iniMoveSpeed;

    //float distancia;
    private float waitTime;
    [SerializeField] float startWaitTime;
    [SerializeField] private float recoveryTime;
    [SerializeField] private float dashTime;

    private int fase = 1;

    void Start()
    {

        trPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        maxHealth = health;
        waitTime = startWaitTime;

    }

    void Update()
    {
        if (canMove == true)
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(trPlayer.position - transform.position), rotSpeed * Time.deltaTime);
            transform.LookAt(trPlayer);

            transform.position += transform.forward * moveSpeed * Time.deltaTime;

            waitTime -= Time.deltaTime;

            if (waitTime <= 0)
            {
                if (fase == 1)
                {
                    canMove = false;
                    StartCoroutine(Fase1());
                }
                if (fase == 2)
                {
                    canMove = false;
                    StartCoroutine(Fase2());
                }
                waitTime = startWaitTime;
            }
            /*
            distancia = Vector3.Distance(this.transform.position, trPlayer.position);

            if (distancia <= 5)
            {
                moveSpeed = 50;
                if (distancia <= 0.2f)
                {
                    canMove = false;
                    StartCoroutine(Cast());
                }
            }
            */

        }
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        health -= damage;

        if (health <= maxHealth/2)
        {
            //GetComponent<Animator>().SetBool("IsEnraged", true);
            fase = 2;
        }

        if (health <= 0)
        {
            Die();
        }
    }

    public IEnumerator Fase1()
    {
        moveSpeed = 50;

        yield return new WaitForSeconds(dashTime);

        moveSpeed = iniMoveSpeed;

        yield return new WaitForSeconds(recoveryTime);

        canMove = true;
    }

    public IEnumerator Fase2()
    {
        moveSpeed = 50;

        yield return new WaitForSeconds(dashTime);

        moveSpeed = iniMoveSpeed;

        yield return new WaitForSeconds(recoveryTime);

        canMove = true;
    }

    void RangedFase1()
    {

    }

    void BulletsFase1()
    {

    }

    void RangedFase2()
    {

    }

    void BulletsFase2()
    {

    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
