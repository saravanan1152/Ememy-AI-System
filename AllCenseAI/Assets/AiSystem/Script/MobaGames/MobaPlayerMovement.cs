using Sirenix.OdinInspector.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MobaPlayerMovement : MonoBehaviour
{
  public  NavMeshAgent agent;
    Animator animator;
    public float rotateSpeedMovement = 0.1f;
   public float rotateVelocity;
    float motionSmoothtime = .1f;

    public ParticleSystem clickParticle;

    private HeroCombat heroCampatScript;

    [SerializeField] InputTargeting targeting;
    [SerializeField] Abilites abilites;
    // Start is called before the first frame update
    //health
   
   
    void Start()
    {
        agent=GetComponent<NavMeshAgent>();
        animator=GetComponent<Animator>();
        heroCampatScript=GetComponent<HeroCombat>();
        targeting=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<InputTargeting>();
        abilites=GetComponent<Abilites>();
     
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        Animations();

        if(heroCampatScript.targetedEnemy!=null)
        {
            if (heroCampatScript.targetedEnemy.GetComponent<HeroCombat>().targetedEnemy != null)
            {
                if (heroCampatScript.targetedEnemy.GetComponent<HeroCombat>().isHeroAlive)
                {
                    heroCampatScript.targetedEnemy = null;
                }
            }
          
        }
   

    }

    void Movement()
    {
       if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "Floor")
                {
                  
                    agent.SetDestination(hit.point);
                    Instantiate(clickParticle,hit.point+=new Vector3(0,0.1f,0),clickParticle.transform.rotation);
                    heroCampatScript.targetedEnemy = null;
                    agent.stoppingDistance = 0;

                    //Rotation
                    Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);

                    float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref rotateVelocity, rotateSpeedMovement * (Time.deltaTime * 5));

                    transform.eulerAngles = new Vector3(0, rotationY, 0);

                    targeting.isFollow = true;
                }
               
            }
        }


       //Look the targetCircle
        if (abilites.targetCircle.enabled == true) 
        
        {
           
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
              
                  
                  

                    //Rotation
                    Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);

                    float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref rotateVelocity, rotateSpeedMovement * (Time.deltaTime * 5));

                    transform.eulerAngles = new Vector3(0, rotationY, 0);

                 
                

            }
        }
        if (abilites.skillShot.enabled == true)

        {
            Debug.Log("Image");
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {




                //Rotation
                Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);

                float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref rotateVelocity, rotateSpeedMovement * (Time.deltaTime * 5));

                transform.eulerAngles = new Vector3(0, rotationY, 0);




            }
        }
    }
    void Animations()
    {
        float speed = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("Speed", speed, motionSmoothtime, Time.deltaTime);


    }

    

}
