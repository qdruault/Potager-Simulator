using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoilBoxScreenScript : MonoBehaviour {

	public GameObject humidityTB;

	private Text humidityText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        humidityText = humidityTB.GetComponent<Text>();
        // Update the humidity.
        float humidityValue = (int)Mathf.Round(this.transform.parent.gameObject.transform.GetChild(0).GetComponent<EarthSoilScript>().HumidityLevel * 100);
        if (humidityValue < 25)
        {
            humidityText.text = "Sec";
        } else if (humidityValue < 50)
        {
            humidityText.text = "Normal";
        }
        else if (humidityValue < 75)
        {
            humidityText.text = "Humide";
        }
        else
        {
            humidityText.text = "Très humide";
        }


    }
}
