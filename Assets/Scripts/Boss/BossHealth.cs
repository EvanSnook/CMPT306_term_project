﻿using UnityEngine;
using System.Collections;

public class BossHealth : MonoBehaviour {

	public int StartingHealthPoints; // This is the starting health of the boss. It is changed in the BossSavedData.
	public int HealthPoints; // This is the total number of Health the boss has.

	public GameObject SavedDataObject; // This is the object that Holds the Scripts that Hold saved Data.
	public GameObject DeathManagerObject; // This will hold a reference to the object that holds the death management scripts.
	

	void Start() {
		SavedDataObject = GameObject.Find ("SavedData"); // Set the reference of the saved data.
		DeathManagerObject = GameObject.Find("DeathManagerObject"); // Set the reference of DeathManagerObject.
		HealthPoints = SavedDataObject.GetComponent<BossSavedData> ().BossCurrentHealth; // The boss' Health will be set from the BossSavedData.
		StartingHealthPoints = SavedDataObject.GetComponent<BossSavedData>().BossStartingHealth; // This gets and stores the starting health of the boss.
	}


	void Update() {
		if (HealthPoints <= 0) { // If health is 0 or less SendMessage that the Boss Died.
			DeathManagerObject.GetComponent<RespawnController>().SendMessage("PlayerOrBossDied");
			Destroy (gameObject); // Destroy Boss
		}
	}

	// Apply damage to the Boss.
	public void ApplyDMG(int DMG) {
		HealthPoints -= DMG;
	}


	// This returns a decimal equivelent of a percentage of the health remaining.
	public float FractionHealthRemaining() {
		if (HealthPoints <= 0) {
			return 0;
		} else {
			return (float) HealthPoints / (float) StartingHealthPoints;
		}
	}



}
