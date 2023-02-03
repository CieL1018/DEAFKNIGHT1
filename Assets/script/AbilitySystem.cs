using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySystem : MonoBehaviour
{
    [Header("Ability1")]
    public Image abilityImage1;
    public float cooldown = 3f;
    bool isCooldown = false;
    private Animator myAnim;


    void Start()
    {
        myAnim = GetComponent<Animator>();
        abilityImage1.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if(isCooldown == true)
        {
            abilityImage1.fillAmount += 1 / cooldown * Time.deltaTime;
        }

        if(abilityImage1.fillAmount == 1)
        {
            isCooldown = false;
        }
        
    }

    public void Ability1(){
        myAnim = GetComponent<Animator>();
        if(isCooldown == true)
        {
            Debug.Log("IsCooldown!");
        }
        else
        {
            isCooldown = true;
            abilityImage1.fillAmount = 0;
        }
    }

    public void UseSkill()
    {
        myAnim.SetTrigger("dash");
    }
}
