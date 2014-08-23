using UnityEngine;
using System.Collections;

public class ShipBehaviour : MonoBehaviour {

	public int life; 
	public GameObject explosion; 

	public void OnTriggerEnter(Collider other) {

		if(other.gameObject.tag=="Bolt") {
			life--; 
			if(life<=0) 
				Explode(other); 
		} else {
			Explode(other); 
			Explode(collider); 
		}
	}

	private void Explode(Collider other) {
		GameObject e = Instantiate(explosion, transform.position, transform.rotation) as GameObject; 
		Destroy(other.gameObject); 
		Destroy(gameObject); 
		Destroy(e,2); 
	}
}