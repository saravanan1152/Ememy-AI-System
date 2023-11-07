using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    private Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float smoothness = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - target.position;
    }

    // Update is called once per frame
  
      
    private void Update()
    {
        Vector3 nuwPos = target.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, nuwPos, smoothness);
    }

}
