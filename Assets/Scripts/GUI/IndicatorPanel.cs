using UnityEngine; 
using System.Collections; 
using System.Collections.Generic; 

public class IndicatorPanel : MonoBehaviour { 
	public GameObject indicator; 
	public GameObject arrow; 

	public List<GameObject> indicatorPool = new List<GameObject>(); 
	int indicatorPoolCursor = 0; 

	public List<GameObject> arrowPool = new List<GameObject>(); 
	int arrowPoolCursor = 0; 

	void LateUpdate() {
		paint(); 
	}

	private void paint() {
		resetPool(); 

		// GameObject[] objects = GameObject.FindObjectsOfType(GameObject); 

		// foreach(GameObject obj in objects) {
		// 	print(obj.name); 
		// }
	}

	private void resetPool() {
		return; 
	}
}