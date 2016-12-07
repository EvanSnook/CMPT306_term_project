using UnityEngine;
using System.Collections;

public class SavedData : MonoBehaviour {

	public float StartingTimeRemaining; // This is the time remaining when the game first starts.
	public float TimeRemaining; // This is the time that is remaining for the player.

	// This makes this object not be destroyed when switching scenes.
	void Start () {
        DontDestroyOnLoad (gameObject);

        TimeRemaining = StartingTimeRemaining; // This initializes the Time the first time the game is loaded.
        //make sure there is an object that can be destroyed.
        // This makes sure that there is only one saved data in the game at all times.
		if(GameObject.FindObjectsOfType(GetType()).Length >1)
        {
            Destroy(gameObject);
		    
        }
	}

	// Save any important Data.
    public void SaveData() {
		gameObject.GetComponent<BossSavedData>().SendMessage ("DeathSaveBoss"); // This sends a message to the BossSavedData to save anything it needs.
        TimeRemaining = GameObject.Find("TimerObject").GetComponent<GameTimer>().GameCountdown; // This saves the remaining time.
    }

	// This Resets the TimeRemaining For a new Game.
	public void ResetSavedData() {
		TimeRemaining = StartingTimeRemaining; // This Resets the timer to the starting time.
        gameObject.GetComponent<BossSavedData>().SendMessage("ResetBossSavedData"); // This sends a message to the BossSavedData to have it reset to the starting values.
        gameObject.GetComponent<PlayerSavedData>().SendMessage("ResetPlayerSavedData"); // This sends a message to the PlayerSavedData to have it reset to the starting values.
	}
		

}
