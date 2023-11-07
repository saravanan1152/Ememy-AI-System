using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{

    public CameraMovement camMovementScript;
    public CameraRoam camRoam;

    bool camViewChanged;
    // Start is called before the first frame update
    void Start()
    {
        camMovementScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(camViewChanged);

        if (!camViewChanged)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                camViewChanged = true;

                camRoam.enabled = true;
                camMovementScript.enabled = false;
            }
        }else if (camViewChanged)
        {
            if(Input.GetKeyDown(KeyCode.E)) 
            {
                camViewChanged = false;

                camRoam.enabled = false;    
                camMovementScript.enabled=true;
            }
        }
    }
}
