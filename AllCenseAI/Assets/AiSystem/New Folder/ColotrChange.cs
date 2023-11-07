using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColotrChange : MonoBehaviour
{
    public Image image;
    public float speed;
   // public Color color;
    // Start is called before the first frame update
    void Start()
    {
      //  image.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Escape))
        {
           
            Color temp;

           // temp = image.color;
            temp=Color.red;
            temp.a = 0;
            image.color = temp;
            while (image.color.a != 1f)
            {
                temp = image.color;
                temp.a += Time.deltaTime * speed;
                temp.a = Mathf.Clamp(temp.a, 0f, 1f);
                image.color = temp;

            }
        }

    }
    
}
