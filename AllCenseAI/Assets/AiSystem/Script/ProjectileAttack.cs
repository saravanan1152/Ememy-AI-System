using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileAttack : MonoBehaviour
{
    [SerializeField] GameObject projectailPrefab;
    [SerializeField]Transform projectailPoint;
    [SerializeField] float projectileSpeed;
    [SerializeField] float projectileIntravel = 0.5f;
    float nexttime;
 
    [HideInInspector]public  bool Active;
    private void Start()
    {
     //   projectileSpeed = 20;


        Active = false;
    }
    void Update()
    {
       if(Time.time > nexttime&&Active)
        {
            nexttime = Time.time + projectileIntravel;
            Shooting();
        }
    
      
    }
    public   void Shooting()
    {
       
            GameObject projectile = Instantiate(projectailPrefab, projectailPoint.position, projectailPoint.rotation);

            Rigidbody projectileRP = projectile.GetComponent<Rigidbody>();
            projectileRP.velocity = projectailPoint.transform.forward * projectileSpeed;

           
            Debug.Log("Shoot");
            // audioSource.PlayOneShot(ShoodClip, 0.2f);
        
    }
}
