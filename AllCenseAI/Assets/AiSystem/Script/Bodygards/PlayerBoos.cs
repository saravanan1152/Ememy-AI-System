using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoos : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal")*100*Time.deltaTime, 0,0);
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * 10 * Time.deltaTime * x);
        transform.Rotate(Vector3.up*10*Time.deltaTime*y);

      //  transform.Rotate(Vector3.up*20*Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {

        }
    }
}
