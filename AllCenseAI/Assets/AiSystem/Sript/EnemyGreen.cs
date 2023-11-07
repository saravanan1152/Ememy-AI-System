using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGreen : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField]private LayerMask layer;

    [SerializeField] GameObject[] Enemys;
    [SerializeField] GameObject[] d;
    [SerializeField] NavMeshAgent agent;
    public GameObject target;
    bool destroy;
    public float helth = 100;

    public EnemyRed red;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();


    }

    // Update is called once per frame
    void Update()
    {

        Enemys = GameObject.FindGameObjectsWithTag("Red");
        foreach (GameObject enemy in Enemys)
        {

            agent.SetDestination(enemy.transform.position);
            {
                // Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, layer);
                if (destroy)
                {
                    float distance = Vector3.Distance(transform.position, enemy.transform.position);


                    if (distance < radius)
                    {
                       

                        agent.SetDestination(enemy.transform.position);

                    }
                    else
                    {
                        enemy.tag = "Untagged";
                    }




                }
            }
              

        }


    }

    void helthDamage(int damage)
    {
        helth -= helth;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
