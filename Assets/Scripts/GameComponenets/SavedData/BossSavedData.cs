using UnityEngine;
using System.Collections;

public class BossSavedData : MonoBehaviour {

	public bool BossSkillsInitialized; // This is for when the boss first
	public int BossStartingHealth; // This is the Health the the boss originally Starts with.
	public int BossCurrentHealth; // This is the current health of the boss.
	public GameObject Boss; // This will hold a reference to the boss.

	public int NumberOfDeaths; // This is the number of times that the Boss has been killed.

    public int BossCollisionDamage; // This is the amount of damage done to the player in collisions.
    public int BossMeleeDamage; // This is the amount of damage done to the player with the boss' melee attack.
    public int BossRangedDamage; // This is the amount of damage done to the player with the boss' ranged attack.


	void Start() {
		BossCurrentHealth = BossStartingHealth; // Initializes the Bosses Health.
        NumberOfDeaths = 0; // This sets the number of deaths for the boss to start at 0.
        BossMeleeDamage = 0; // This sets the amount of damage done by the boss' melee attack to 0.
        BossRangedDamage = 0; // This sets teh amount of damage done to the player by the boss' ranged attack to 0.
	}

	// This will be called to save any information that is needed for the boss when the player dies.
	public void DeathSaveBoss() {
		int BossHP = Boss.GetComponent<BossHealth> ().HealthPoints; // This gets the health that the boss currently has.
		if (BossHP <= 0) { // If the boss has died reset the boss health to the starting health.
			BossCurrentHealth = BossStartingHealth; // Reset the Boss health since he died.
			NumberOfDeaths++; // Increase the number of deaths for the boss.
		} else {
			BossCurrentHealth = BossHP; // This saves the current health that the boss has.
		}
	}
		
	void Update() {
		if (Boss == null) { // If Boss has not been found search for it.
			Boss = GameObject.Find ("Boss"); // This gets a reference to the boss.
		}
	}

    // This returns the total amount of damage done to the player with all of the boss' attacks.
    public int TotalDamageDoneToPlayer () {
        return BossCollisionDamage + BossRangedDamage + BossMeleeDamage; // This calculates the total damage.
    }

    // This is called when going to the mainmenu and resets any saved data in the BossSavedData.
    public void ResetBossSavedData () {
        NumberOfDeaths = 0; // This resets the number of deaths to 0.
        BossCollisionDamage = 0; // This resets the CollisionDamage Done to the player.
        BossMeleeDamage = 0; // This resets the BossMeleeDamage done to the player.
        BossRangedDamage = 0; // This resets teh BossRangedDamage done to the player.
        BossCurrentHealth = BossStartingHealth; // This resets the BossHealth to the Starting Health.
    }

    public void BossCollisionDMG (int DMGDone) {
        BossCollisionDamage += DMGDone;
    }

    public void BossMeleeDMG (int DMGDone) {
        BossMeleeDamage += DMGDone;
    }

    public void BossRangedDMG (int DMGDone) {
        BossRangedDamage += DMGDone;
    }

}
