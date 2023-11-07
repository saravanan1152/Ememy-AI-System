using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrawWire : MonoBehaviour
{
    public Rigidbody body;

   
 
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector3( Input.GetAxis("Vertical")*500*Time.deltaTime,0,0);
      transform.Rotate(Vector3.up*Time.deltaTime*6*Input.GetAxis("Horizontal"));;
    }


}
