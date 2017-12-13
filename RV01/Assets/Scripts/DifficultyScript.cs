using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
