using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target; 
	public float distance; 
	public float height; 
	public float heightDamping; 
	public float rotationDamping; 

	public void LateUpdate() {
		// if(!target) return; 

		// float wantedRotationAngle = target.eulerAngles.y; 
		// float wantedHeight = target.position.y + height; 

		// float currentRotationAngle = transform.eulerAngles.y; 
		// float currentHeight = transform.position.y; 

		// currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime); 

		// currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime); 

		// Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0); 

		// transform.position = target.position; 
		// transform.position -= currentRotation * Vector3.forward * distance; 

		// Vector3 temp = transform.position; 
		// temp.y = wantedHeight; 
		// transform.position = temp; 

		transform.LookAt(target); 
	}

}