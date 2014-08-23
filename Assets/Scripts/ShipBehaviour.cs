using UnityEngine;
using System.Collections;

public class ShipBehaviour : MonoBehaviour {

	public GameObject explosion; 

	public void OnTriggerEnter(Collider other) {
		GameObject e = Instantiate(explosion, transform.position, transform.rotation) as GameObject; 
		Destroy(other.gameObject); 
		Destroy(gameObject); 
		Destroy(e,2); 
	}
}