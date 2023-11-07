using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCombat : MonoBehaviour
{
    public enum HeroAttackType { mellee,Ranged};
    public HeroAttackType heroattackType;

    public GameObject targetedEnemy;
    public float attackRange;
    public float rotateSpeedForAttck;

    public MobaPlayerMovement movementScript;
    private Stats statsScript;
    public Animator animator;

    public bool basicAtckIdle=false;
    public bool isHeroAlive;
    public bool performMeleeAttack = true;
    public bool performRangedAttack = true;

    [Header("Ranged Variables")]
    public GameObject projPrefab;
    public Transform projSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        movementScript = GetComponent<MobaPlayerMovement>();
        statsScript = GetComponent<Stats>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
          
                
                    heroattackType = HeroAttackType.mellee;
                    Debug.Log("attack" + heroattackType);
           
            attackRange = 2;
           
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            heroattackType = HeroAttackType.Ranged;
            Debug.Log("attack" + heroattackType);
        
            attackRange = 5;
        }

        if(targetedEnemy != null)
        {
            if ((Vector3.Distance(gameObject.transform.position, targetedEnemy.transform.position) > attackRange))
                {
                movementScript.agent.SetDestination(targetedEnemy.transform.position);
                movementScript.agent.stoppingDistance = attackRange;


               
            }
            else
            {
                if(heroattackType==HeroAttackType.mellee)
                {
                    
                    //Rotation
                    Quaternion rotationToLookAt = Quaternion.LookRotation(targetedEnemy.transform.position - transform.position);

                    float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref movementScript.rotateVelocity, rotateSpeedForAttck * (Time.deltaTime * 5));

                    transform.eulerAngles = new Vector3(0, rotationY, 0);
                    movementScript.agent.SetDestination(transform.position);

                    if (performMeleeAttack)
                    {
                        Debug.Log("Attack the Minion_01");

                        StartCoroutine(MeleeAttackInterval());

                        Debug.Log(1);
                    }
                }
                //Ranged character
                if (heroattackType == HeroAttackType.Ranged)
                {
                    Debug.Log(2);
                    //Rotation
                   
                    Quaternion rotationToLookAt = Quaternion.LookRotation(targetedEnemy.transform.position - transform.position);

                    float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref movementScript.rotateVelocity, rotateSpeedForAttck * (Time.deltaTime * 5));

                    transform.eulerAngles = new Vector3(0, rotationY, 0);
                    movementScript.agent.SetDestination(transform.position);
                   
                    if (performRangedAttack)
                    {
                        Debug.Log("Attack the Minion_02");

                        Debug.Log("Enter1");
                        StartCoroutine(RangedAttackInterval());
                    }
                }
            }
            
        }
    }


    IEnumerator MeleeAttackInterval()
    {
        performMeleeAttack = false;
        animator.SetBool("Basic Attck", true);
        yield return new WaitForSeconds(statsScript.attackTime / ((100 + statsScript.attackTime) * 0.01f));

        if (targetedEnemy == null)
        {
            animator.SetBool("Basic Attck", false);
            performMeleeAttack = true;
        }
    }
    IEnumerator RangedAttackInterval()
    {
        
        performRangedAttack = false;
        animator.SetBool("Projectil Attack", true);
        yield return new WaitForSeconds(statsScript.attackTime / ((100 + statsScript.attackTime) * 0.01f));

        if (targetedEnemy == null)
        {
            animator.SetBool("Projectil Attack", false);
            performRangedAttack = true;
           
        }
    }

    public void MeleeAttack()
    {
        if (targetedEnemy != null)
        {
            if(targetedEnemy.GetComponent<Enemy>().enemyType==Enemy.EnemyType.Minion)
            {
                targetedEnemy.GetComponent<Stats>().health -= statsScript.attackDmg;
            }
        }
        performMeleeAttack = true;
    }
    public void RangedAttack()
    {
        if (targetedEnemy != null)
        {
            if (targetedEnemy.GetComponent<Enemy>().enemyType == Enemy.EnemyType.Minion)
            {
               
                SpawnRangedProjectil("Minion", targetedEnemy);
            }
        }
        performRangedAttack = true;
    }
    void SpawnRangedProjectil(string typeofEnemy,GameObject targetedEnemyObj )
    {
        float dmg=statsScript.attackDmg;

        Instantiate(projPrefab, projSpawnPoint.transform.position,Quaternion.identity
            );

        if (typeofEnemy == "Minion")
        {
            projPrefab.GetComponent<Projectail>().targetType = typeofEnemy;
            projPrefab.GetComponent<Projectail>().target = targetedEnemyObj;
            projPrefab.GetComponent<Projectail>().targetSet= true;

        }
    }
}
