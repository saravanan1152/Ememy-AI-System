using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class initialize : MonoBehaviour
{
    public List<int> mylist = new List<int>() { 0, 1, 8 };
    public string[] say = { "hi", "hello", "greetings" };

    public Dropdown myDropDown;
  
    public Dictionary<int, string> sayb = new Dictionary<int, string>()
    {
        {1,"hello1" },
        {2,"bye" },
        {3,"see" },

    };
    // Start is called before the first frame update
    void Start()
    {
        // myDropDown = GetComponent<Dropdown>();
      
    }

    // Update is called once per frame
    void Update()
    {
        option();
        
    }

    void option()
    {
        switch (myDropDown.value)
        {
            case 1:Debug.Log("chose A");
                break;

            case 2: Debug.Log("chose B");
                break; 
            case 3: Debug.Log("chose C");
                break;
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("MouseDown");
    }
}
