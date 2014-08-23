using UnityEngine;
using System.Collections;

public class ShipBehaviour : MonoBehaviour {

	public int life; 
	public GameObject explosion; 

	public void OnTriggerEnter(Collider other) {

		print("hit by "+other.gameObject.name+" tag-"+other.gameObject.tag); 

		if(other.gameObject.tag=="Bolt") life--; 
		else life -= 50; 
		
		if(life<=0) 
			Explode(collider); 
	}

	private void Explode(Collider other) {
		GameObject e = Instantiate(explosion, transform.position, transform.rotation) as GameObject; 
		Destroy(other.gameObject); 
		Destroy(gameObject); 
		Destroy(e,2); 
	}
}