using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSroll : MonoBehaviour
{
    public Camera camera;
    private float camFOV;
    public float zoomspeed;

    private float mouseScrollInput;
    // Start is called before the first frame update
    void Start()
    {
        camFOV = camera.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        mouseScrollInput = Input.GetAxis("Mouse ScrollWheel");

        camFOV -= mouseScrollInput * zoomspeed;
        camFOV = Mathf.Clamp(camFOV, 30, 60);

        camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, camFOV, zoomspeed);
    }
}
