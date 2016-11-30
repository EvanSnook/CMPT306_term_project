using UnityEngine;
using System.Collections;

public class BossSavedData : MonoBehaviour {

	public bool BossSkillsInitialized; // This is for when the boss first
	public int BossStartingHealth; // This is the Health the the boss originally Starts with.
	public int BossCurrentHealth; // This is the current health of the boss.
	public GameObject Boss; // This will hold a reference to the boss.

	public int BossNumberOfDeaths; // This is the number of times that the Boss has been killed.

	void Start() {
		BossCurrentHealth = BossStartingHealth; // Initializes the Bosses Health.
	}

	// This will be called to save any information that is needed for the boss when the player dies.
	public void DeathSaveBoss() {
		int BossHP = Boss.GetComponent<BossHealth> ().HealthPoints;
		if (BossHP <= 0) {
			BossCurrentHealth = BossStartingHealth;
			BossNumberOfDeaths++;
		} else {
			BossCurrentHealth = BossHP;
		}
	}
		
	void Update() {
		if (Boss == null) { // If Boss has not been found search for it.
			Boss = GameObject.Find ("Boss"); // This gets a reference to the boss.

		}
	}


}
