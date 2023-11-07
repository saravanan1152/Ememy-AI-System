using DamageNumbersPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{   [SerializeField] DamageNumber damageNumber;
    [SerializeField] Transform numberSpawnpoint;
    float Bulletdamage = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ebullet"))
        {
            Debug.Log("player");
            var d = GetComponent<Stats>().health -=Bulletdamage;
            damageNumber.Spawn(numberSpawnpoint.position, Bulletdamage);

            
           
        }
    }
    
}
