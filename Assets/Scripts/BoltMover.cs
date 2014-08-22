using UnityEngine;
using System.Collections;

public class BoltMover : MonoBehaviour {
	public float speed;

    void Start ()
    {
        rigidbody.velocity = transform.forward * speed;
        // rigidbody.velocity = transform.TransformDirection(new Vector3(0,0,speed)); 
        
    }
}