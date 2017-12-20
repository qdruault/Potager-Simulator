using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFirstPersonScript : MonoBehaviour {

	private bool messageOn = false;
	private float timer = 0;
	// 60 secondes
	private float timerDuration = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (messageOn) {
			float seconds = timer % 60;
			if (seconds < timerDuration) {
				timer+= Time.deltaTime;
			}
			else {
				timer = 0;
				messageOn = false;
				DeleteText ();
			}
				
		}
	}

	public void AddText(string p_message){
		this.transform.GetChild (0).gameObject.GetComponent<Text> ().text = p_message;
		timer = 0;
		messageOn = true;
	}

	void DeleteText(){
		this.transform.GetChild (0).gameObject.GetComponent<Text> ().text = "";
	}
}
