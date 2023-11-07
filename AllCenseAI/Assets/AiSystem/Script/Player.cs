using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 10f;
	public float rotateSpeed = 10f;

	private Vector3 movement;
	private float rotation;


	public ParticleSystem Fire=null;
    public ParticleSystem WaterEffect;
    [SerializeField] AudioClip FlameThrower;
    [SerializeField] AudioSource audioSource;

    public collliter colliterScript;
  
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        colliterScript=GetComponentInChildren<collliter>();
       WaterEffect.Play();
    }
    void Update ()
	{

        movement.z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		rotation = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;

        transform.Translate(movement, Space.Self);
        transform.Rotate(0f, rotation, 0f);

        if (Input.GetKey(KeyCode.Space))
        {
            Fire.Play();
            audioSource.clip= FlameThrower;
            audioSource.Play();
            colliterScript.FireBool = true;
        }
        else
        {
            audioSource.Stop();
            colliterScript.FireBool= false;
        }
      
    }

}
