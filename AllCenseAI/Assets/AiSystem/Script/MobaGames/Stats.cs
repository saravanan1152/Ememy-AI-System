using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public float attackDmg;
    public float attachSpeed;
    public float attackTime;

    HeroCombat heroCobatScript;

  
    public float expValue;
    public LevelUP levelup;
    // Start is called before the first frame update
    void Start()
    {
        heroCobatScript=GameObject.FindGameObjectWithTag("Player").GetComponent<HeroCombat>();
        levelup = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelUP>();
        health = maxHealth;
       
       
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            heroCobatScript.targetedEnemy = null;
            heroCobatScript.performMeleeAttack = false;
            heroCobatScript.performRangedAttack = false;

         
          levelup.SetExperience(expValue);
        }
    }
}
