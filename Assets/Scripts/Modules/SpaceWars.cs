using UnityEngine; 
using System.Collections; 
using System.Collections.Generic; 
using System.IO; 
using Modules; 

namespace Modules { 
	public class SpaceWars : MonoBehaviour { 
		public static List<GameObject> ships; 

		void Awake() {
			ships = new List<GameObject>(); 
		}
	}
}