using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilities : MonoBehaviour
{
    PlayerInput input;

    public GameObject modelo;

    private float activationTime;
    private bool invi;
    public bool canBeDamaged = true;

    bool stance = true;
    bool ability1 = false;
    int ability;
    bool IsSkillUnlocked = false;

    [SerializeField] GameObject rayo;

    private void Awake()
    {
        input = new PlayerInput();
        input.CharacterControls.Invisibility.performed += InviCooldown;
        input.CharacterControls.GetAbility.performed += GetAbility;
    }

    private void OnEnable()
    {
        input.CharacterControls.Enable();
    }

    private void OnDisable()
    {
        input.CharacterControls.Disable();
    }

    void Start()
    {
        rayo.SetActive(false);
        invi = false;
        activationTime = 0;
        gameObject.GetComponent<Laser>().enabled = false;
        gameObject.GetComponent<CreateShield>().enabled = false;
    }

    void Update()
    {
        activationTime += Time.deltaTime;
        
        if(invi == true && activationTime >= 3)
        {
            invi = false;
            //this.GetComponent<Collider>().enabled = true;
            Debug.Log("me ves");
            canBeDamaged = true;
            modelo.SetActive(true);
        }
        if(invi == true)
        {
            Invisibility();
        }

        
    }

    void InviCooldown(InputAction.CallbackContext obj)
    {
        activationTime = 0;
        invi = true;
    }

    void Invisibility()
    {
        //this.GetComponent<Collider>().enabled = false;
        Debug.Log("no me ves");
        canBeDamaged = false;
        modelo.SetActive(false);
    }

    void GetAbility(InputAction.CallbackContext obj)
    {
        ability = Random.Range(1, 3);

        switch (ability)
        {
            case 5:

                break;
            case 4:

                break;
            case 3:

                break;
            case 2:
                if (gameObject.GetComponent<CreateShield>().enabled == false)
                {
                    gameObject.GetComponent<CreateShield>().enabled = true;
                    Debug.Log("si");
                }
                else
                {
                    input.CharacterControls.GetAbility.performed += GetAbility;
                    Debug.Log("no");
                }
                Debug.Log("2");
                break;
            case 1:
                if (gameObject.GetComponent<Laser>().enabled == false)
                {
                    gameObject.GetComponent<Laser>().enabled = true;
                    Debug.Log("lo tenemos");
                }
                else
                {
                    input.CharacterControls.GetAbility.performed += GetAbility;
                    Debug.Log("no lo tenemos");
                }
                Debug.Log("1");
                break;
            default:
                input.CharacterControls.GetAbility.performed += GetAbility;
                break;
        }
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
