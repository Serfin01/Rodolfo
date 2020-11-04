using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scrolls : MonoBehaviour
{
    [SerializeField] GameObject[] typeScrolls;
    //private int random;

    private int currenIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        int newIndex = UnityEngine.Random.Range(0, typeScrolls.Length);
        typeScrolls[currenIndex].SetActive(false);
        currenIndex = newIndex;
        typeScrolls[currenIndex].SetActive(true);
    }

    enum Abilities
    {
        A1, A2, A3, None
    }

    private Abilities currentAbility = Abilities.None;

    //private Dictionary<int>

    /*
    // Update is called once per frame
    void Update()
    {
        //random = Random.Range(0, typeScrolls.Length);
        int newIndex = Random.Range(0, typeScrolls.Length);
        typeScrolls[currenIndex].SetActive(false);
        currenIndex = newIndex;
        typeScrolls[currenIndex].SetActive(true);
        //Instantiate(typeScrolls[random], transform.position, transform.rotation);
    }
    */
}
