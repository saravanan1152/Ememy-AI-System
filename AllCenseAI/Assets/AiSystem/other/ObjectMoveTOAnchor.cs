using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectMoveTOAnchor : MonoBehaviour
{
    [SerializeField] GameObject helmat;
    [SerializeField] GameObject transformObject;
    [SerializeField] float speed = 2;
    [SerializeField] GameObject[] worker;
    [SerializeField] GameObject[] points;
    [SerializeField] float speetnum = 1;
    [SerializeField] GameObject UIshow;
    [SerializeField][Range(2,20)] float range=5;
    [SerializeField] bool tag;
    // Start is called before the first frame update
    void Start()
    {

        worker = GameObject.FindGameObjectsWithTag("Cupe");
        points = GameObject.FindGameObjectsWithTag("point");
    }

    // Update is called once per frame
    void Update()
    {
       
        if(tag)
        if (Input.GetKeyDown(KeyCode.Space))
        {
             
            Instantiate(helmat, transform.position, transform.rotation);
          
        
               
                    transformObject = GameObject.FindGameObjectWithTag("c").gameObject;
                
         

         

        }
       
        foreach (GameObject anchorPoint in points)
        {
            if (Vector3.Distance(transform.position, anchorPoint.transform.position) < range)
            {
                if (anchorPoint.CompareTag("point"))
                {
                    tag = true;
                    anchorPoint.SetActive(true);
                    transformObject.transform.position = Vector3.MoveTowards(transformObject.transform.position, anchorPoint.transform.position, speed * Time.deltaTime);

                    transformObject.tag = "Untagged";
                    if (transformObject.transform.position == anchorPoint.transform.position)
                    {
                        anchorPoint.tag = "Untagged";
                        transformObject = null;

                        tag = false;


                    }
                    else
                    {
                        tag = true;
                    }
                }
              // 


            }
            else anchorPoint.SetActive(false);
            tag = false;
        }
       
        foreach (GameObject work in worker)
        {
            if (Vector3.Distance(work.transform.position, transform.position) < range)
            {
                UIshow.SetActive(true);
              //  h = GameObject.FindGameObjectWithTag("c").gameObject;
            }
            else UIshow.SetActive(false);
        }

      




    }

    public void Helmet()
    {
      


    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }


}
