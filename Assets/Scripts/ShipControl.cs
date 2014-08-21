using UnityEngine;
using System.Collections;

public class ShipControl : MonoBehaviour {
	public float speed 				= 6f;  
	public float lower_speed_limit 	= 6f; 
	public float upper_speed_limit 	= 36f; 
	public int turn 				= 85; 
	public GameObject shot; 
	public Transform shot_spawn; 
	public float fire_rate; 

	private bool speedup; 
	private bool slowdown; 
	private float speed_delta = 1f; 
	private Renderer[] ts; 
	private float next_fire; 

	// Uses physics 
	public void FixedUpdate () {
		Move(); 
	}

	// Does not require physics 
	public void Update() {
		Shoot(); 
	}

	public void Move() { 

		if(Input.GetButton("Fire2")) {
			Renderer[] renderers = transform.GetChild(0).GetComponentsInChildren<Renderer>(); 
			foreach(Renderer r in renderers) {
				if(r.name=="part_jet_core") {
					r.enabled = true; 
					break; 
				}
			}

			if(speed<upper_speed_limit) speed += speed_delta; 
			else speedup = false; 
		} else {
			Renderer[] renderers = transform.GetChild(0).GetComponentsInChildren<Renderer>(); 
			foreach(Renderer r in renderers) {
				if(r.name=="part_jet_core") {
					r.enabled = false; 
					break; 
				}
			}

			if(speed>lower_speed_limit) speed -= speed_delta; 
			else slowdown = false; 
		}


		if(Input.GetAxis("Horizontal")<0) 
			transform.Rotate(0,0,2*turn*Time.deltaTime); 
		else if(Input.GetAxis("Horizontal")>0)
			transform.Rotate(0,0,-2*turn*Time.deltaTime); 

		transform.position += Vector3.up*0.87f; 
		transform.position += Vector3.forward*-2.21f; 

		if(Input.GetAxis("Vertical")<0)
			transform.Rotate(-turn*Time.deltaTime,0,0); 
		else if(Input.GetAxis("Vertical")> 0)
			transform.Rotate(turn*Time.deltaTime,0,0); 

		transform.Translate(0,0,speed*Time.deltaTime);
	}

	public void Shoot() {
		if(Input.GetButton("Fire1") && Time.time > next_fire) {
			// print("firing!"); 
			next_fire = Time.time + fire_rate; 
			Instantiate(shot, shot_spawn.position, shot_spawn.rotation); 
		}

	}
}
