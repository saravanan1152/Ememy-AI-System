using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputTargeting : MonoBehaviour
{
    public GameObject selectedHero;
    public bool heroPlayer;
    RaycastHit hit;
    public bool isFollow;
   
    // Start is called before the first frame update
    void Start()
    {
        selectedHero = GameObject.FindGameObjectWithTag("Player");
        isFollow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,Mathf.Infinity))
        {
            
            if(hit.collider.GetComponent<Enemy>()!=null&&isFollow)
            {
                if (hit.collider.gameObject.GetComponent<Enemy>().enemyType == Enemy.EnemyType.Minion)
                {
                    selectedHero.GetComponent<HeroCombat>().targetedEnemy=hit.collider.gameObject;
                }
            }
            else if (hit.collider.gameObject.GetComponent<Enemy>() == null)
            {
                selectedHero.GetComponent<HeroCombat>().targetedEnemy = null;
            }
        }
    }
}
