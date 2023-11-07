using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class EnemyRed : MonoBehaviour
{
  
    [SerializeField][Range(1, 6)] float attackRange;
   [SerializeField] [Range(1, 20)] float ditectingRange;
   
    [SerializeField] LayerMask layer;

    public EnemyRed enemy;
  
    public float nextAttackTime=1;
    [SerializeField] NavMeshAgent agent;
   
    public float helth=100;
    public Collider[] targets;
    public GameObject bullet;
    public GameObject SapwnPos;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
      

    }

   
    void Update()
    {
    
        targets = Physics.OverlapSphere(transform.position,ditectingRange, layer);
       

        foreach (Collider target in targets)
        {
           float distance = Vector3.Distance(transform.position, target.transform.position);

            if (distance<ditectingRange&&gameObject.tag=="Green")
            {



                agent.SetDestination(target.transform.position);
                Vector3 targetDirection = (target.transform.position - transform.position);
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);
                agent.stoppingDistance = attackRange;
             

                if (distance <= attackRange)
                {
                   

                   
                    if (Time.time >= nextAttackTime)
                    {


                        Instantiate(bullet, SapwnPos.transform.position, transform.rotation);

                        ditectingRange=20;
                        nextAttackTime = Time.time + 1;

                      
                    }

                }
             


            }
           
           
        }



        
            
              
               
            
           
     


    }

   
    void helthDamage(int damage)
    {
        helth -= helth;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            helthDamage(20);
        }
    }


    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, ditectingRange);
    }
}
