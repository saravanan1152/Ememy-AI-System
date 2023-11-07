using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class test : MonoBehaviour
{
    public string[] words;
    public List<string> wordslist;
    public int a = 1;
    public GameObject cube;

 [SerializeField]   public Dictionary<string, int> highScore;
    // Start is called before the first frame update
    void Start()
    {
     
      //  wordslist = words.ToList();

     //   words=wordslist.ToArray();

        highScore.Add("jo", 2000);
        highScore.Add("d", 2005);
        highScore.Add("c", 2001);
      
        Debug.Log("c" + highScore  ["c"]);
      
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.B)) 
        { 
            addnumber(ref a);
            SlowDown(2f);
          
        }
       cube. transform.Rotate(10, 0, 0);
    }
    void addnumber(ref int a)
    {
        a += 40;
        Debug.Log (a);
    }

    private void SlowDown(float slownwss)
    {
        Time.timeScale = slownwss;
        Time.fixedDeltaTime = Time.deltaTime*0.02f;
    }
  
}
