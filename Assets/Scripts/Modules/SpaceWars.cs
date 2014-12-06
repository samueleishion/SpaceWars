using UnityEngine; 
using System.Collections; 
using System.Collections.Generic; 
using System.IO; 
using Modules; 

namespace Modules { 
	public class SpaceWars : MonoBehaviour { 
		// public static List<GameObject> ships; 
		public GameObject enemy_weak; 
		public GameObject enemy_strong; 
		public GameObject player; 

		void Awake() {
			// ships = new List<GameObject>(); 
			GameObject model; 
			int i; 


			for(i=0; i<25; i++) {
				model = (GameObject) Object.Instantiate(enemy_weak, new Vector3(0,1.004f+(i*0.02f),0), Quaternion.identity); 
				((GameObject) model).transform.Rotate(Vector3.up, 180); 
				((GameObject) model).transform.RotateAround(Vector3.zero, Vector3.left, enemy_weak.transform.position.y); 
			}

			
			for(i=0; i<3; i++) {
				model = (GameObject) Object.Instantiate(enemy_weak, new Vector3(0,1.004f+(i*0.02f),0), Quaternion.identity); 
				((GameObject) model).transform.Rotate(Vector3.up, 180); 
				((GameObject) model).transform.RotateAround(Vector3.zero, Vector3.left,  enemy_strong.transform.position.y); 
			}
		}
	}
}