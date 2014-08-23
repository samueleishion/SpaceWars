using UnityEngine;
using System.Collections;

public class ShipControl_Enemy : ShipControl {


	public override void Move() {  

		// transform.Rotate(0,0,2*turn*Time.deltaTime); 
		transform.Rotate(-turn*Time.deltaTime,0,0); 

		transform.Translate(0,0,speed*Time.deltaTime);
	} 

	public override void Shoot() {
		print(gameObject.name+" shooting"); 
		if(gameObject.name!="vehicle_enemyShip_transport") {
			if(Time.time > next_fire) {
				next_fire = Time.time + (fire_rate * 10); 

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
}