using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShorHand : MonoBehaviour
{
    public bool isBool;
    public int a;
    public int b;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // isBool=a>b ? true : false;
      string result  = a > b ? "Abig" : a < b ? "Bbig" : "fedljndsfuj";
        Debug.Log(result);

    }
}
