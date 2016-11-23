using UnityEngine;
using System.Collections;

public class BossSavedData : MonoBehaviour {

	public bool BossSkillsInitialized; // This is for when the boss first
	public int BossStartingHealth; // This is the Health the the boss originally Starts with.
	public int BossCurrentHealth; // This is the current health of the boss.

	public int BossNumberOfDeaths; // This is the number of times that the Boss has been killed.


	// This will be called to save any information that is needed for the boss when the player dies.
	public void PlayerDeathSaveBoss() {
		BossCurrentHealth = GetComponent<BossHealth> ().HealthPoints;
	}

	// This will be called to save and reset any information that is needed for the boss after it dies.
	public void BossDeathSaveBoss() {
		BossCurrentHealth = BossStartingHealth;
	}



}
