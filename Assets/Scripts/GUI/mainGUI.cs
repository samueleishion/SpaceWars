using UnityEngine;
using System.Collections;

public class mainGUI : MonoBehaviour {
	public GameObject quitButton; 
	public GameObject restartButton; 

	private bool menuOn = false; 

	public void Update() {
		if(Input.GetKeyDown(KeyCode.Escape)) 
			menuOn = !menuOn; 

		if(menuOn) {
			quitButton.SetActive(true); 
			restartButton.SetActive(true); 
		} else {
			quitButton.SetActive(false); 
			restartButton.SetActive(false); 
		}
	}

	public void Quit() {
		Application.LoadLevel("Intro"); 
	}

	public void Restart() {
		Application.LoadLevel("Main"); 
	}
}