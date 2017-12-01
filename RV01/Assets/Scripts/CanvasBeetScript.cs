using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasBeetScript : MonoBehaviour {

	public GameObject humidityTB;
	public GameObject illuminationTB;

	private Text humidityText;
	private Text illuminationText;

	private string humidity;
	private string illumination;

	// Use this for initialization
	void Start () {

		// Update the humidity.
		humidity = "Normal";
		humidityText = humidityTB.GetComponent<Text>();
		humidityText.text = humidity;

		// Update the illumination.
		illumination = "80 %";
		illuminationText = illuminationTB.GetComponent<Text>();
		illuminationText.text = illumination;

	}

	// Update is called once per frame
	void Update () {

	}
}
