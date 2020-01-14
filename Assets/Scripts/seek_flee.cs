using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seek_flee : MonoBehaviour
{
	public bool bIsFleeing = true;
    public Transform player_Transform;
    public float watch_radius = 50f;
    public float approach_speed = 5f;
    public Rigidbody rb;
    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player_Transform.position) <= watch_radius)
        {
        	//Target inside watch radius
        	transform.LookAt(player_Transform);

        	Vector3 _direction = transform.position - player_Transform.position;
        	_direction.Normalize();
        	_direction *= approach_speed;
        	

        	if(bIsFleeing)
        	{
        		rb.AddForce(_direction, ForceMode.VelocityChange);
        	}
        	else
        	{
        		rb.AddForce(-_direction, ForceMode.VelocityChange);
        	}

       }
    }
}
