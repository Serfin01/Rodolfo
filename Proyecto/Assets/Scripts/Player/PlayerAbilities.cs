using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    private float activationTime;
    private bool invi;
    public bool canBeDamaged = true;

    bool stance = true;
    bool ability1 = false;
    int ability;
    bool IsSkillUnlocked = false;

    [SerializeField] Shield shield;

    void Start()
    {
        invi = false;
        activationTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        activationTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //this.GetComponent<Collider>().enabled = false;
            //Invi();
            activationTime = 0;
            invi = true;
            
        }
        if(invi == true && activationTime >= 3)
        {
            invi = false;
            //this.GetComponent<Collider>().enabled = true;
            Debug.Log("me ves");
            canBeDamaged = true;
        }
        if(invi == true)
        {
            Invisibility();
        }

        switch (ability)
        {
            case 5:
                
                break;
            case 4:
                
                break;
            case 3:
                
                break;
            case 2:
                
                break;
            case 1:
                
                break;
        }
    }

    void Invisibility()
    {
        //this.GetComponent<Collider>().enabled = false;
        Debug.Log("no me ves");
        canBeDamaged = false;
    }

    void GetAbility()
    {
        ability = Random.Range(1, 4);
    }
    /*
    private List<SkillType> unlockedSkillTypeList;

    private void UnlockSkill(SkillType skillType)
    {
        if (!IsSkillUnlocked(skillType))
        {
            unlockedSkillTypeList.Add(skillType);
        }
    }
    */
}
