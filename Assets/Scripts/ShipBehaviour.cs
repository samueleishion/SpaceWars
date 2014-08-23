using UnityEngine;
using System.Collections;

public class ShipBehaviour : MonoBehaviour {
	public void OnTriggerEnter(Collider other) {
		Destroy(other.gameObject); 
		Destroy(gameObject); 
	}
}