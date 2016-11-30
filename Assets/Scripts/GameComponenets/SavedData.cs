using UnityEngine;
using System.Collections;

public class SavedData : MonoBehaviour {

	public float StartingTimeRemaining; // This is the time remaining when the game first starts.
	public float TimeRemaining; // This is the time that is remaining for the player.

	// This makes this object not be destroyed when switching scenes.
	void Start () {
        DontDestroyOnLoad (gameObject);

        TimeRemaining = StartingTimeRemaining; // This initializes the Time the first time the game is loaded.
        
		if(GameObject.FindObjectsOfType(GetType()).Length >1)
        {
            Destroy(gameObject);
		    
        }
	}

	// Save any important Data.
    void SaveData() {
		gameObject.GetComponent<BossSavedData>().SendMessage ("DeathSaveBoss"); // This sends a message to the BossSavedData to save anything it needs.
		gameObject.GetComponent<PlayerSavedData> ().SendMessage ("DeathSavePlayer"); // This sends a message to the PlayerSavedData to save anything it needs.
        TimeRemaining = GameObject.Find("TimerObject").GetComponent<GameTimer>().GameCountdown; // This saves the remaining time.
    }
		

}
