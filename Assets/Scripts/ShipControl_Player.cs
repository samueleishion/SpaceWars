using UnityEngine;
using System.Collections;

public class ShipControl_Player : ShipControl {


	public override void Move() { 

		Boost(); 

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

	public void Boost() {
		if(Input.GetButton("Fire2")) {
			if(current_boost>0) {
				// current_boost -= 2; 

				this_renderer.enabled = true; 
				this_renderer.gameObject.audio.volume = 1f; 

				if(speed<upper_speed_limit) speed += speed_delta; 
				else speedup = false; 

				turn = fast_turn; 
			} else {
				this_renderer.enabled = false; 
				if(this_renderer.gameObject.audio.volume>0)
					this_renderer.gameObject.audio.volume -= 0.1f; 

				turn = original_turn; 	
			}
			
		} else {
			
			this_renderer.enabled = false; 
			if(this_renderer.gameObject.audio.volume>0)
				this_renderer.gameObject.audio.volume -= 0.1f; 

			if(speed>lower_speed_limit) speed -= speed_delta/2; 
			else slowdown = false; 

			turn = original_turn; 

			if(current_boost<boost) current_boost += 1; 
		}  
	}

	public override void Shoot() {
		if(Input.GetButton("Fire1") && Time.time > next_fire) { 
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