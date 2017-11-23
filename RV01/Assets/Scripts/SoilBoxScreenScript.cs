using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoilBoxScreenScript : MonoBehaviour {

	public GameObject humidityTB;

	private Text humidityText;

	private float humidityValue;

	private string humidity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// Update the humidity.
		humidityValue = (int)Mathf.Round(this.transform.parent.gameObject.transform.GetChild(0).GetComponent<EarthSoilScript>().HumidityLevel * 100);
		humidity = humidityValue.ToString ();
		humidityText = humidityTB.GetComponent<Text>();
		humidityText.text = humidity;
		
	}
}
