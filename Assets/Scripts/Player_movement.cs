using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{

    public Rigidbody2D rb;
    public bool thrustOn = false;
    public float angle;
    public Vector2 v;
    public float controlForce = 10;

    public bool rotright = false;
    public bool rotleft = false;
    public float rotspeed = 10;

    public ParticleSystem partsys;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {  
    }

    public void TurnLeft() {

        if (!rotleft)
        {
            rotleft = true;
        }
        else {
            rotleft = false;
        }
    }

    public void TurnRight()
    {

        if (!rotright)
        {
            rotright = true;
        }
        else
        {
            rotright = false;
        }
    }


    public void Thrust()
    {
        if (!thrustOn)
        {
            thrustOn = true;
        }
        else
        {
            thrustOn = false;
        }
    }

    private void FixedUpdate()
    {

        if (thrustOn || Input.GetKey("w"))
        {

            rb.constraints = RigidbodyConstraints2D.None;
            angle = this.transform.eulerAngles.z;
            v = new Vector2(controlForce * Mathf.Cos(angle * (Mathf.PI / 180) + (Mathf.PI / 2)), controlForce * Mathf.Sin(angle * (Mathf.PI / 180) + (Mathf.PI / 2)));
            rb.AddForce(v * Time.deltaTime, ForceMode2D.Force);
            partsys.startLifetime = 0.5f;
        }
        else
        {
            partsys.startLifetime = 0;
        }

        if (rotleft || Input.GetKey("a"))
        {
            rb.AddTorque(rotspeed * Time.deltaTime, ForceMode2D.Force);
        }

        if (rotright || Input.GetKey("d"))
        {
            rb.AddTorque(-rotspeed * Time.deltaTime, ForceMode2D.Force);
        }

        //anim.SetBool("Is_thrust", thrustOn);
      

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
