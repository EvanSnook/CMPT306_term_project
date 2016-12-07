using UnityEngine;
using System.Collections;

public class BossSavedData : MonoBehaviour {

	public bool BossSkillsInitialized; // This is for when the boss first
	public int BossStartingHealth; // This is the Health the the boss originally Starts with.
	public int BossCurrentHealth; // This is the current health of the boss.
	public GameObject Boss; // This will hold a reference to the boss.

	public int NumberOfDeaths; // This is the number of times that the Boss has been killed.
    public int DamageDoneToPlayer; // This is the amount of damage done to the player by the boss' attacks.

	void Start() {
		BossCurrentHealth = BossStartingHealth; // Initializes the Bosses Health.
        NumberOfDeaths = 0; // This sets the number of deaths for the boss to start at 0.
        DamageDoneToPlayer = 0; // This sets the amount of damage that has been done to the player to start at 0.
	}

	// This will be called to save any information that is needed for the boss when the player dies.
	public void DeathSaveBoss() {
		int BossHP = Boss.GetComponent<BossHealth> ().HealthPoints;
		if (BossHP <= 0) { // If the boss has died reset the boss health to the starting health.
			BossCurrentHealth = BossStartingHealth;
			NumberOfDeaths++; // Increase the number of deaths for the boss.
		} else {
			BossCurrentHealth = BossHP;
		}
	}
		
	void Update() {
		if (Boss == null) { // If Boss has not been found search for it.
			Boss = GameObject.Find ("Boss"); // This gets a reference to the boss.
		}
	}

    // This is called when going to the mainmenu and resets any saved data in the BossSavedData.
    public void ResetBossSavedData () {
        NumberOfDeaths = 0; // This resets the number of deaths to 0.
        DamageDoneToPlayer = 0; // This resets the Damage done to the player to 0.
    }

}
