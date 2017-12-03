using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenScript : MonoBehaviour {

	public GameObject temperatureTB;
	public GameObject illuminationTB;

	private Text temperatureText;
	private Text illuminationText;

	// Use this for initialization
	void Start () {
        // Store the textboxes.
        temperatureText = temperatureTB.GetComponent<Text>();
        illuminationText = illuminationTB.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {

		// Update the temperature.
		float temperature = GameObject.Find("CursorT").GetComponent<TCursorScript>().Temperature * 40.0f;
		temperatureText.text = System.Math.Round(temperature, 1).ToString() + " °C";
			
		// Update the illumination.
		float illumination = GameObject.Find("CursorI").GetComponent<ICursorScript>().Illumination * 100.0f;
		illuminationText.text = System.Math.Round(illumination, 1).ToString() + "%"; ;
	}
}
