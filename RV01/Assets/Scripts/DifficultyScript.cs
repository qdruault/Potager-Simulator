using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Difficulty { Easy, Normal, Hard};

public class DifficultyScript : MonoBehaviour {

    private Difficulty gameDifficulty;

    public Difficulty GameDifficulty
    {
        get
        {
            return gameDifficulty;
        }

        set
        {
            gameDifficulty = value;
        }
    }

    // Use this for initialization
    void Start () {
        gameDifficulty = Difficulty.Easy;
        // TODO: Faire une UI jolie.
        Debug.Log("Pour commencer creusez, plantez ce que vous voulez et arrosez afin de garder le sol au taux d’humidité indiqué");
		GameObject.Find ("CanvasFirstPerson").GetComponent<CanvasFirstPersonScript> ().AddText ("Pour commencer creusez, plantez ce que vous voulez et arrosez afin de garder le sol au taux d’humidité indiqué");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
