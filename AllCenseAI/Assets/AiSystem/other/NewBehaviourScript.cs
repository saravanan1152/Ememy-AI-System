using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] anchors;
  //  public GameObject cupe;
    public GameObject spear;
    // Start is called before the first frame update
    void Start()
    {
        anchors = GameObject.FindGameObjectsWithTag("Cupe");

       // cupe = GameObject.FindGameObjectWithTag("c");
    }

    // Update is called once per frame
    void Update()
    {
        
        foreach(GameObject anchor in anchors)
        {
            float distans = Vector3.Distance(transform.position, anchor.transform.position);
            if (distans <5)
            {
              
             
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(spear, transform.position, transform.rotation);
        }
    }

    private void OnDrawGizmos()
    {

        
        Gizmos.DrawWireSphere(transform.position,5);
    }
}
