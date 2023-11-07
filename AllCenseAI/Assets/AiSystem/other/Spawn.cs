using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject objectsToSpawn;
    public float t = 1;
    public Transform spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       
        if (Time.time >= t)

        {
            Vector3 spawnPosition = spawnPoints.position + Random.insideUnitSphere * 10;
            Physics.CheckSphere(transform.position, 40);
            Instantiate(objectsToSpawn, spawnPosition, spawnPoints.rotation);
            t = Time.time+1;   
        }
       Color color = Color.red;
        Gizmos.DrawWireSphere(transform.position,5);
        
    }
    
}
