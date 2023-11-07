using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiBodyGard : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] GameObject FollowPoint;
    [SerializeField]NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float distance = Vector3.Distance(FollowPoint.transform.position, transform.position);

        
    }
}
