using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forword : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime*30);
        destroy();
    }

    private void destroy()
    {
        Destroy(gameObject, 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Green")
        {
            Destroy(other.gameObject);
        }
    }
}
