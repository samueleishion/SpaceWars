﻿using UnityEngine;
using System.Collections;

public class ShipControl : MonoBehaviour {
	public float speed; 
	public float speed_limit; 
	public float turn; 
	public Rigidbody shot; 
	public Transform shot_spawn; 
	public float fire_rate; 


	private float lower_speed_limit; 
	private float upper_speed_limit; 
	private bool speedup; 
	private bool slowdown; 
	private float speed_delta = 0.5f; 
	private Renderer[] ts; 
	private float next_fire; 
	private float original_turn; 
	private float fast_turn; 
	private Renderer this_renderer; 

	// Uses physics 
	public void Start() {
		lower_speed_limit = speed; 
		upper_speed_limit = speed_limit; 
		original_turn = turn*1.0f; 
		fast_turn = turn*1.5f; 
	}

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
				if(r.name=="part_jet_flare") {
					r.enabled = true; 
					r.gameObject.audio.volume = 1f; 
					break; 
				}
			}

			if(speed<upper_speed_limit) speed += speed_delta; 
			else speedup = false; 

			turn = fast_turn; 
		} else {
			Renderer[] renderers = transform.GetChild(0).GetComponentsInChildren<Renderer>(); 
			foreach(Renderer r in renderers) {
				if(r.name=="part_jet_flare") { 
					this_renderer = r; 
					r.enabled = false; 
					break; 
				}
			}

			if(speed>lower_speed_limit) speed -= speed_delta/2; 
			else slowdown = false; 

			if(this_renderer.gameObject.audio.volume>0)
				this_renderer.gameObject.audio.volume -= 0.1f; 

			turn = original_turn; 
		}


		if(Input.GetAxis("Horizontal")<0) 
			transform.Rotate(0,0,2*turn*Time.deltaTime); 
		else if(Input.GetAxis("Horizontal")>0)
			transform.Rotate(0,0,-2*turn*Time.deltaTime); 

		// transform.position += Vector3.up*0.87f; 
		// transform.position += Vector3.forward*-2.21f; 
		// transform.position += Vector3.up*0.087f*Time.deltaTime; 
		// transform.position += Vector3.forward*0.221f*Time.deltaTime; 

		if(Input.GetAxis("Vertical")<0)
			transform.Rotate(-turn*Time.deltaTime,0,0); 
		else if(Input.GetAxis("Vertical")> 0)
			transform.Rotate(turn*Time.deltaTime,0,0); 

		transform.Translate(0,0,speed*Time.deltaTime);
	}

	public void Shoot() {
		if(Input.GetButton("Fire1") && Time.time > next_fire) {
			// print("firing!"); 
			try {
				next_fire = Time.time + fire_rate; 
				Rigidbody bullet = Instantiate(shot, shot_spawn.position, shot_spawn.rotation) as Rigidbody; 
				Vector3 direction = new Vector3(0,0,speed); 
				bullet.velocity = transform.TransformDirection(direction); 
			} catch (System.NullReferenceException e) {
			}
		}

	}
}
