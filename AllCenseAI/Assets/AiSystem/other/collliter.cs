using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collliter : MonoBehaviour
{
    [SerializeField] ParticleSystem fire;
  [HideInInspector]  public bool FireBool;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
           if (FireBool)
            {
                ParticleSystem Child = Instantiate(fire, other.transform.position, transform.rotation);
                Child.transform.SetParent(other.gameObject.transform);
                Debug.Log("Eneter");

                Destroy(other.gameObject, 5);
            }
          
           
        }
       
    }
}
