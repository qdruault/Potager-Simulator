using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasDaikonScript : MonoBehaviour {

	public GameObject humidityTB;
	public GameObject illuminationTB;

	private Text humidityText;
	private Text illuminationText;

	private string humidity;
	private string illumination;

	// Use this for initialization
	void Start () {

		// Update the humidity.
		humidity = "Très humide";
		humidityText = humidityTB.GetComponent<Text>();
		humidityText.text = humidity;

		// Update the illumination.
		illumination = "50 %";
		illuminationText = illuminationTB.GetComponent<Text>();
		illuminationText.text = illumination;

	}

	// Update is called once per frame
	void Update () {

	}
}
