using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoam : MonoBehaviour
{
    public float camSpeed = 10;
    public float screensizeThickness = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos=transform.position;

        //up
        if (Input.mousePosition.y >= Screen.height - screensizeThickness)
        {
            pos.x-=camSpeed*Time.deltaTime;
        } 
        //down
        if (Input.mousePosition.y <= screensizeThickness)
        {
            pos.x+=camSpeed*Time.deltaTime;
        }
        //Right
        if (Input.mousePosition.x >= Screen.width - screensizeThickness)
        {
            pos.z += camSpeed * Time.deltaTime;
        }
        //Left
        if (Input.mousePosition.x <= screensizeThickness)
        {
            pos.z -= camSpeed * Time.deltaTime;
        }
        transform.position = pos;   
    }
}
