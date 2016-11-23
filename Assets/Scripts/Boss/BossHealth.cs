using UnityEngine;
using System.Collections;

public class BossHealth : MonoBehaviour {

	public int HealthPoints; // This is the total number of Health the boss has.

	public GameObject SavedDataObject; // This is the object that Holds the Scripts that Hold saved Data.
	

	void Start() {
		SavedDataObject = GameObject.Find ("SavedData"); // Set the reference of the saved data.
		HealthPoints = SavedDataObject.GetComponent<BossSavedData> ().BossCurrentHealth; // The boss' Health will be set from the BossSavedData.
	}


	void Update() {
		if (HealthPoints <= 0) { // If health is 0 or less SendMessage that the Boss Died.
			gameObject.GetComponent<BossAIBasic>().SendMessage("BossDeath");
		}
	}

	// Apply damage to the Boss.
	public void ApplyDMG(int DMG) {
		HealthPoints -= DMG;
	}



}
