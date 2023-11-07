using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWire1 : MonoBehaviour
{
    public int myint;

    bool finish;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Handheld.Vibrate();

        myint++;
       // Debug.Log(myint % 5);
       // Debug.Log(myint);

        for(int i = 0; i < 10; i++)
        {
            Debug.Log(i);
            if(finish)
            {
                Debug.Log("finish");
                break;
              
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, Vector3.one * 10);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 10);
    }
}
