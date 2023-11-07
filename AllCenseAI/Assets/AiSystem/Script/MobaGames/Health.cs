using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider playerHealthbar;
   public Slider ScreenHealthbar;



  public  Stats statsScript;
   
    // Start is called before the first frame update
    void Start()
    {


        statsScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
       
        playerHealthbar = GetComponentInChildren<Slider>();

       
        ScreenHealthbar.maxValue = statsScript.maxHealth;
        playerHealthbar.maxValue = statsScript.maxHealth;
       

    }

    // Update is called once per frame
    void Update()
    {
        playerHealthbar.value = statsScript.health;
        ScreenHealthbar.value = playerHealthbar.value;

        transform.LookAt(Camera.main.transform.position);
        transform.Rotate(0,180,0);
    }


 
}

