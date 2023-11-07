using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectail : MonoBehaviour
{
    public float damage;
    public GameObject target;

    public bool targetSet;
    public string targetType;
    public float Speed = 5;
    public bool stopProjectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            if (target == null)
            {
                Destroy(gameObject);
                return;
            }
            transform.position=Vector3.MoveTowards(transform.position,target.transform.position, Speed*Time.deltaTime);

            if(!stopProjectile)
            {
                if (Vector3.Distance(transform.position, target.transform.position) < 0.5f)
                {
                    if (targetType == "Minion")
                    {
                        target.GetComponent<Stats>().health -= damage;
                        stopProjectile = true;
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

}
