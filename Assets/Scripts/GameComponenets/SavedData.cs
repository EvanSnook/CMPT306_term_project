using UnityEngine;
using System.Collections;

public class SavedData : MonoBehaviour {

	public float StartingTimeRemaining; // This is the time remaining when the game first starts.
	public float TimeRemaining; // This is the time that is remaining for the player.

	/*
		This makes this object not be destroyed when switching scenes.
	*/
	void Start () {
        DontDestroyOnLoad (gameObject);
        TimeRemaining = StartingTimeRemaining; // This initializes the Time the first time the game is loaded.
        if(GameObject.FindObjectsOfType(GetType()).Length >1)
        {
            Destroy(gameObject);
		    
        }
	}

    void SaveData()
    {

        TimeRemaining = GameObject.Find("TimerObject").GetComponent<GameTimer>().GameCountdown;
    }
		

}
