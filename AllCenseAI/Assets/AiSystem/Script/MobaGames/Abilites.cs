using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Abilites : MonoBehaviour
{
    [Header("Ability 1")]
    public Image abilityImage1;
    public float coolDown1 = 5;
    bool isCoolDown;
    public KeyCode ability1;
    [SerializeField] string ability1Animation;

    //Ability 1 input 
    public Vector3 position;
    public Canvas ability1canvas;
    public Image skillShot;
    public Transform player;

    [Header("Ability 2")]
    public Image abilityImage2;
    public float coolDown2 = 10;
    bool isCoolDown2;
    public KeyCode ability2;
    [SerializeField] string ability2Animation;
    //Ability 2 inptu

    public Image targetCircle;
    public Image indicatorRangeCicle;
    public Canvas abilityCanvas2;
    private Vector3 posUp;
    public float maxAbiloity2DDistance;

    [Header("Ability 3")]
    public Image abilityImage3;
    public float coolDown3 = 10;
    bool isCoolDown3;
    public KeyCode ability3;

    [SerializeField] InputTargeting targeting;
    [SerializeField] HeroCombat heroCombat;


    // Start is called before the first frame update
    void Start()
    {



        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;

        skillShot.GetComponent<Image>().enabled = false;
        targetCircle.GetComponent<Image>().enabled = false;
        indicatorRangeCicle.GetComponent<Image>().enabled = false;

        targeting = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<InputTargeting>();
        heroCombat = GetComponent<HeroCombat>();


    }

    // Update is called once per frame
    void Update()
    {


        Ability1();
        Ability2();
        Ability3();



        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);






        //Ability 1 Inputs
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }

        //Ability 2 Inputs
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            posUp = new Vector3(hit.point.x, 10f, hit.point.z);
            position = hit.point;



        }

        //Ability Canvas 1 Inputs
        Quaternion transRot = Quaternion.LookRotation(position - player.transform.position);
        ability1canvas.transform.rotation = Quaternion.Lerp(transRot, ability1canvas.transform.rotation, 0f);

        //Avility 2 canvas Inputs
        var hitPosDir = (hit.point - transform.position).normalized;
        float distance = Vector3.Distance(hit.point, transform.position);
        distance = Mathf.Min(distance, maxAbiloity2DDistance);

        var newHitpos = transform.position + hitPosDir * distance;
        abilityCanvas2.transform.position = (newHitpos);



    }
    void Ability1()
    {
        if (Input.GetKey(ability1) && isCoolDown == false)
        {
            skillShot.GetComponent<Image>().enabled = true;

            //Disable Other UI
            indicatorRangeCicle.GetComponent<Image>().enabled = false;
            targetCircle.GetComponent<Image>().enabled = false;

            targeting.isFollow = false;

        }
        if (skillShot.GetComponent<Image>().enabled == true && Input.GetMouseButtonDown(0))
        {
            abilityImage1.fillAmount = 1;
            isCoolDown = true;
            heroCombat.animator.Play(ability1Animation);

            float t= Time.deltaTime;
            if(t>2)
            {
                targeting.isFollow = true;
            }
            

          



        }

        if (isCoolDown)
        {
            abilityImage1.fillAmount -= 1 / coolDown1 * Time.deltaTime;
            skillShot.GetComponent<Image>().enabled = false;
            if (abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCoolDown = false;

            }
        }
        //colse ability
        if (Input.GetKey(KeyCode.Escape) && !isCoolDown)
        {
            targeting.isFollow = true;
            skillShot.GetComponent<Image>().enabled = false;

        }


    }
    void Ability2()
    {


        if (Input.GetKey(ability2) && isCoolDown2 == false)
        {
            indicatorRangeCicle.GetComponent<Image>().enabled = true;
            targetCircle.GetComponent<Image>().enabled = true;
           

           // Disable Skillshot UI
            skillShot.GetComponent<Image>().enabled = false;

            targeting.isFollow = false;
        }



        if (targetCircle.GetComponent<Image>().enabled == true && Input.GetMouseButtonDown(0))
        {


            isCoolDown2 = true;
            abilityImage2.fillAmount = 1;
            heroCombat.animator.Play(ability2Animation);

            float t = Time.deltaTime;
            if (t > 2)
            {
                targeting.isFollow = true;
            }

           

        }
        if (isCoolDown2)
        {
            indicatorRangeCicle.GetComponent<Image>().enabled = false;
            targetCircle.GetComponent<Image>().enabled = false;

            abilityImage2.fillAmount -= 1 / coolDown2 * Time.deltaTime;

            if (abilityImage2.fillAmount <= 0)
            {
                abilityImage2.fillAmount = 0;
                isCoolDown2 = false;
            }
        }


        //close ability
        if (Input.GetKeyDown(KeyCode.Escape) && !isCoolDown2)
        {
            targeting.isFollow = true;

            indicatorRangeCicle.GetComponent<Image>().enabled = false;
            targetCircle.GetComponent<Image>().enabled = false;

        }





    }
    void Ability3()
    {
        if (Input.GetKey(ability3) && isCoolDown3 == false)
        {
            isCoolDown3 = true;
            abilityImage3.fillAmount = 1;
        }
        if (isCoolDown3)
        {
            abilityImage3.fillAmount -= 1 / coolDown3 * Time.deltaTime;

            if (abilityImage3.fillAmount <= 0)
            {
                abilityImage3.fillAmount = 0;
                isCoolDown3 = false;
            }
        }
    }




}

