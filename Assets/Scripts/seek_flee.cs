using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seek_flee : MonoBehaviour
{
	public bool bIsFleeing = true;
    public Transform player_Transform;
    public float watch_radius = 7f;
    public float arrive_radius = 2f;
    public float approach_speed = 5f;
    public Rigidbody rb;
    // Update is called once per frame
    void Update()
    {
        if((Vector3.Distance(transform.position, player_Transform.position) <= watch_radius))
        {//Player is inside watch radius
        	//Look at the player ///This doesn't fully work on flee bots for some reason
        	transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation( player_Transform.position - transform.position ), Time.deltaTime );


        	//Calculate the vector directly away from the player
        	Vector3 _direction = transform.position - player_Transform.position;
        	_direction.Normalize();
        	_direction *= approach_speed;
        	

        	if(bIsFleeing) 
        	{
        		//Bot in flee mode, move backwards.
        		rb.AddForce(_direction, ForceMode.VelocityChange);

        		if(rb.isKinematic)
        		{
        			transform.position += _direction;
        		}
        	}
        	else if ((Vector3.Distance(transform.position, player_Transform.position) >= arrive_radius)) //If the seeker isn't close enought to the player, approach them
        	{
        		//Bot in seek mode, approach player
        		rb.AddForce(-_direction, ForceMode.VelocityChange);
        		
        		if(rb.isKinematic)
        		{
        			transform.position -= _direction;
        		}
        	}

       }
    }
}
