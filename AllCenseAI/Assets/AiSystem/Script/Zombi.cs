using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Zombi : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private EnemyAI targetAI;
    [SerializeField] private float radius =20;
    private Collider[] Colliders;
    public Renderer render;
    public float health= 1000;
    [SerializeField] RandomMovement randomMovement;

    [SerializeField]public LayerMask layermask;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        randomMovement = gameObject.AddComponent<RandomMovement>();
        agent.stoppingDistance = 0;
        health = 200;
    

    }

   
    void Update()
    {
        randomMovement = GetComponent<RandomMovement>();
       

        Colliders = Physics.OverlapSphere(transform.position, radius);




        foreach (Collider collider in Colliders)
        {
            if (targetAI == null)
            {


                if (Vector3.Distance(transform.position, collider.transform.position) < radius)
                {
                    if (collider.gameObject.CompareTag("Enemy"))
                    {

                        EnemyAI detectedAI = collider.gameObject.GetComponent<EnemyAI>();
                        targetAI = detectedAI;
                        
                       
                       
                    }
                    else
                    {
                        targetAI = null;

                        randomMovement.enabled = true;

                    }

                }
              
            }
            else
            {
                if (targetAI.health >= 0)
                {
                    Debug.Log("Enemy");
                    randomMovement.enabled = false;
                    agent.SetDestination(targetAI.transform.position);
                }
                else
                {
                    randomMovement.enabled = true;
                }
            }
        }
        
        if (Colliders.Length <= 0)
        {
           
        }
        else
        {
           
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
           collision. gameObject.layer = LayerMask.GetMask("Default");
            gameObject.layer = LayerMask.GetMask("Default");
            gameObject.tag = "Zombi";
            collision.gameObject.tag = "Zombi";
            render = collision.gameObject.GetComponent<Renderer>();
            render.material.color = Color.gray;
            collision.gameObject.AddComponent<Zombi>();
          
          EnemyAI  targetAI =collision.gameObject.GetComponent<EnemyAI>();
            Destroy(targetAI);
          RandomMovement randomMovement = collision.gameObject.GetComponent<RandomMovement>();
            Destroy(randomMovement);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            health -= 20;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
