using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private EnemyAI targetAI;
    [SerializeField] private Zombi _zombi;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private RandomMovement randomMovement;
    private float nexttime;
    private float projectilSpeed = 30;
    private Vector3 throwForce;

    [GUIColor("RGB(0, 1, 0)")]
    [SerializeField] public float health { get; set; }
    [GUIColor("RGB(0, 1, 0)")]
    // [SerializeField] public float attackPower = 20f;


    [ProgressBar(0, 30, ColorGetter = "green")]
    [SerializeField] float detectionRange = 10f;
    [ProgressBar(0, 30, ColorGetter = "yellow")]
    [SerializeField] private float _AttackDistence = 20;




    [GUIColor("RGB(0, 1, 0)")]
    [Tooltip("Set the TransparantFX")]
    [SerializeField] LayerMask targetLayer;

    [Tooltip("Assing bullet ")]
    [Required("Custom error message.")]
    [AssetSelector]
    [SerializeField] GameObject projectailPrefab;

    [PropertyTooltip("Assing bulletSpawn Point ")]
    [AssetSelector]
    [SerializeField] Transform projectailPoint;





    [Tooltip("Assing Shooting Audio ")]
    [AssetSelector]
    [SerializeField] private AudioClip ShoodClip;
    // [SerializeField] private AudioClip CollideClip;
    // [SerializeField] private AudioClip ExplotionClip;
    [AssetSelector]
    [SerializeField] private ParticleSystem explotion;
    [AssetSelector]
    [SerializeField] private ParticleSystem ShootingParticle;


    //  private Renderer renter;



    private void Start()
    {
        health = 500;
        _AttackDistence = 20;

        targetAI = null;
        _zombi = null;
        audioSource = GetComponent<AudioSource>();
        randomMovement = gameObject.AddComponent<RandomMovement>();
        randomMovement = GetComponent<RandomMovement>();
        agent.stoppingDistance = 10;

        
    }

    private void Update()
    {





        agent = GetComponent<NavMeshAgent>();
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRange, targetLayer);

        if (targetAI == null)
        {



            foreach (Collider collider in hitColliders)
            {
                if (Vector3.Distance(transform.position, collider.transform.position) < detectionRange)
                {
                    if (collider.gameObject != gameObject && collider.CompareTag("Enemy"))
                    {

                        EnemyAI detectedAI = collider.gameObject.GetComponent<EnemyAI>();



                        if (detectedAI != null && detectedAI.health > 0)
                        {

                            targetAI = detectedAI;
                            Vector3 targetDirection = (targetAI.transform.position - transform.position);
                            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);
                            // agent.SetDestination(targetAI.transform.position);

                        }
                    }
                    else if (collider.gameObject != gameObject && collider.CompareTag("Zombi"))
                    {


                        _zombi = GameObject.FindGameObjectWithTag("Zombi").GetComponent<Zombi>();
                        Debug.Log("ENTER");
                        float ZombiDistance = Vector3.Distance(transform.position, _zombi.transform.position);

                        Vector3 targetDirection = (_zombi.transform.position - transform.position);
                        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);





                        if (Time.time >= nexttime)
                        {
                           

                            // enemyAI.TakeDamage(attackPower);
                            nexttime = Time.time + 0.1f;
                            Shooting();

                        }

                    }
                    else
                    {
                        _zombi = null;
                        targetAI = null;

                    }

                }
                else
                {

                    agent = null;
                    
                }


            }


        }
        else
        {

            if (targetAI.health > 0)
            {

                Vector3 targetDirection = (targetAI.transform.position - transform.position);
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);
                agent.SetDestination(targetAI.transform.position);
                if (agent.remainingDistance <= _AttackDistence)
                {

                    AttackEnemy(targetAI);
                }



            }
            else
            {

                targetAI = null;

            }


        }



     /*   if (_zombi != null || targetAI != null)
        {
            randomMovement.enabled = false;
        }
        else
        {
            randomMovement.enabled = true;
        }
     */



    }

    private void AttackEnemy(EnemyAI enemyAI)
    {
        AttackEnemy(enemyAI, throwForce);
    }

    private void AttackEnemy(EnemyAI enemyAI, Vector3 throwForce)
    {

        if (Time.time >= nexttime)
        {


            // enemyAI.TakeDamage(attackPower);
            nexttime = Time.time + 0.5f;
            Shooting();

        }


    }

    public void TakeDamage(float damage)
    {

        health -= damage;


        if (health <= 0f)
        {
            Die();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage(20);
            //  audioSource.PlayOneShot(CollideClip, 0.5f);
        }



    }

    private void Die()
    {

        Destroy(gameObject);

        Instantiate(explotion, transform.position, Quaternion.identity);

        explotion.Play();
        //  targetAI.  audioSource.PlayOneShot(ExplotionClip, 1);

    }
    void Shooting()
    {
        GameObject projectile = Instantiate(projectailPrefab, projectailPoint.position, projectailPoint.rotation);
        Rigidbody projectileRP = projectile.GetComponent<Rigidbody>();
        projectileRP.velocity = projectailPoint.transform.forward * projectilSpeed;


        audioSource.PlayOneShot(ShoodClip, 0.2f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _AttackDistence);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, agent.stoppingDistance);


    }


}
