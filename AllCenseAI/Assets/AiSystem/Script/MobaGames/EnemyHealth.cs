using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
    public Slider enemyHealthbar;
   



  public  Stats statsScript;

    // Start is called before the first frame update
    void Start()
    {


       // statsScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Stats>();
       statsScript=GetComponentInParent<Stats>();
        enemyHealthbar = GetComponentInChildren<Slider>();

        enemyHealthbar.maxValue = statsScript.maxHealth;
       
      //  statsScript.health = statsScript.maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        enemyHealthbar.value = statsScript.health;

        transform.LookAt(Camera.main.transform.position);
       transform.Rotate(0, 180, 0);
    }

}
