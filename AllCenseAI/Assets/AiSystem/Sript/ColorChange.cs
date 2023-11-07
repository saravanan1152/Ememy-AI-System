using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ColorChange : MonoBehaviour
{
    // Start is called before the first frame update

    //  public Material materailcolor;
    public Color newcolor;
    public SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent < SpriteRenderer>();
        sprite.color=newcolor;
    }

    // Update is called once per frame
    void Update()
    {
      //  materailcolor.SetColor("_Color", Color.blue);
      
    }
}
