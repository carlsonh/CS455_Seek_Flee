using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 200f;
    public float sidewaysForce = 500f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called per tick
    void FixedUpdate()
    {

        rb.AddForce(0, -9.8f * Time.deltaTime, 0);

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
        }

        if(rb.position.y < -2f)
        {
        	FindObjectOfType<game_manager>().GameEnd();
        }
    }
    //Wander: Simplify to rand inside min max angle
}

