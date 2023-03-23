using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrust=100f;
    [SerializeField] float rotate=5f;
    [SerializeField] ParticleSystem exchaust;
    AudioSource thrustsound;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thrustsound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            rb.AddRelativeForce(Vector3.up*thrust*Time.deltaTime);
            if (thrustsound.isPlaying == false)
            {
               
                thrustsound.Play();
                
            }
            if (!exchaust.isPlaying) {
                exchaust.Play();

            }
            
           }
        else
        {

            thrustsound.Stop();
            exchaust.Stop();

        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            move(rotate);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move(-rotate);
        }
    }
    void move(float moveing) {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward*moveing*Time.deltaTime);
        rb.freezeRotation = false;
    }

}
