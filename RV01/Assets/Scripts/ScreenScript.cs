using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenScript : MonoBehaviour {

	public GameObject temperatureTB;
	public GameObject illuminationTB;

	private Text temperatureText;
	private Text illuminationText;

	private string temperature;
	private string illumination;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// Update the temperature.
		temperature = GameObject.Find("CursorT").GetComponent<TCursorScript>().Temperature.ToString();
		temperatureText = temperatureTB.GetComponent<Text>();
		temperatureText.text = temperature;
			
		// Update the illumination.
		illumination = GameObject.Find("CursorI").GetComponent<ICursorScript>().Illumination.ToString();
		illuminationText = illuminationTB.GetComponent<Text>();
		illuminationText.text = illumination;
	}
}
