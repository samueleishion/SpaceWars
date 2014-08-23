using UnityEngine;
using System.Collections;

public class ShipBehaviour : MonoBehaviour {

	public int life; 
	public GameObject explosion; 

	public void OnTriggerEnter(Collider other) {

		string str = "("+life+") "; 
		str += gameObject.name+" hit by "+other.gameObject.name+" tag-"+other.gameObject.tag+" "; 

		if(other.gameObject.tag=="Bolt") life--; 
		else life -= 50; 

		str += "("+life+") "; 
		print(str); 
		
		if(life<=0) {
			Explode(); 
			print("Exploding!! ("+life+")"); 
		}

		print("("+life+") exit OnTriggerEnter"); 
	}

	private void Explode() {
		GameObject e = Instantiate(explosion, transform.position, transform.rotation) as GameObject; 
		Destroy(collider.gameObject); 
		Destroy(gameObject); 
		Destroy(e,2); 
	}
}