using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[Serializable]
public class EnemyProjecytil
{
    [SerializeField]public GameObject projectailPrefab;
    [SerializeField]public Transform projectailPoint;
    [SerializeField]public float projectileSpeed;
    [SerializeField]public float projectileIntravel = 0.5f;
    public AudioSource Source;
    public AudioClip projectileClip;

  [HideInInspector] public float nexttime;
}
public class Enemy : MonoBehaviour
{
    public enum EnemyType { Minion}
    public EnemyType enemyType;

    
    public Stats stats;

    [SerializeField]public EnemyProjecytil enemyProjecytil;
   
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
        enemyProjecytil.Source=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RockBig"))
        {
            stats.health =stats.health- 50;
        }
        if (collision.gameObject.CompareTag("RockSmall"))
        {
            stats.health -= 30;
        }
     
    }

   public void ONShoot()
    {
        if (Time.time > enemyProjecytil.nexttime)
        {
            GameObject projectile = Instantiate(enemyProjecytil.projectailPrefab,enemyProjecytil. projectailPoint.position,enemyProjecytil. projectailPoint.rotation);

            Rigidbody projectileRP = projectile.GetComponent<Rigidbody>();
            projectileRP.velocity = enemyProjecytil.projectailPoint.transform.forward *enemyProjecytil. projectileSpeed;



           enemyProjecytil. nexttime = Time.time +enemyProjecytil. projectileIntravel;
            enemyProjecytil.Source.clip = enemyProjecytil.projectileClip;
            enemyProjecytil.Source.Play();
            Debug.Log("Shoot");
        }
    }

}
