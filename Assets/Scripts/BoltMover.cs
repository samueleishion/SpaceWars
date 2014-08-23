using UnityEngine;
using System.Collections;

public class BoltMover : MonoBehaviour {
	public float speed;
	private float start; 
	private bool active; 
	private float bolt_duration; 

    void Start ()
    {
        rigidbody.velocity = transform.forward * speed;
        bolt_duration = 1.5f; 
        start = Time.time; 
        active = true; 
        // rigidbody.velocity = transform.TransformDirection(new Vector3(0,0,speed)); 
        
    }

    void Update() { 
    	if(active) { 
	    	if(Time.time-start>=bolt_duration) { 
	    		active = false; 
	    		Destroy(gameObject); 
	    	} 
	    } 
    }
}