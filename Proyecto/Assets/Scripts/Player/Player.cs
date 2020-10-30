using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] protected int health = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Damaged(int damage)
    {
        health -= damage;
    }
}
