using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DamageNumbersPro;
public class Bullet : MonoBehaviour
{
    [SerializeField]private int destoryTime;
    [SerializeField] DamageNumber damageNumber;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,destoryTime);
    }
    private void OnCollisionEnter(Collision collision)
    {

        /*  if (collision.gameObject.CompareTag("Player"))
          {
              Debug.Log("player");
             var d= collision.gameObject.GetComponent<Stats>().health -=2;
              damageNumber.Spawn(transform.position, d);
              Destroy(gameObject);
          }
          else
          {
              Destroy(gameObject);
          }*/
        Destroy(gameObject);

    }
}
