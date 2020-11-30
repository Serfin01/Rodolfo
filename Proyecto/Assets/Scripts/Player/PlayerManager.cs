using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : Player
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Debug.Log("maricon");
            SceneManager.LoadScene(4);
            //Destroy(this.gameObject);
        }
    }
}
