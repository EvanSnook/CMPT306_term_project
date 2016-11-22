using UnityEngine;
using System.Collections;


public class BossAIBasic : MonoBehaviour {

	public GameObject ThePlayer; // This is the player that the boss is trying to kill.
	public GameObject SceneControllerObject; // This is a reference to the Scene Controller so when the boss dies it will change scenes.
	public GameObject SavedDataObject; // This is the object that holds scripts that hold save information for the boss and player.

	public GameObject BossSkillsManagerObject; // This is the object that manages what skills and attacks the boss has unlocked.
	public float[] BossMeleeSkills; // The type of this is just a place holder. This is the array of Melee Skills the boss has unlocked.

	public int BossLowHealth; // This is what is considered as low health for the boss. It is done in percentage so 1% to 100%.


	void Start () {
		SavedDataObject = GameObject.Find ("SavedDataObject");

		BossMeleeSkills = BossSkillsManagerObject.GetComponent<BossSkillsManager> ().UnlockedMeleeSkills;
	}

	void FixedUpdate() {
		float DistanceToPlayer = Vector3.Distance (ThePlayer.transform.position, gameObject.transform.position);

		isAnyMeleeSkillsInRange (DistanceToPlayer);

	}

	// This checks all unlocked skills to find a Skill that is in range to the player.
	private float[] isAnyMeleeSkillsInRange(float DistanceToPlayer) {
		float[] BossMeleeSkillsInRange = new float[30]; // This will hold an Array of MeleeSkills that are in range.
		int z = 0;

		for (int i =0; i < BossMeleeSkills.Length; i++) {
			if (BossMeleeSkills[i] /*.Range*/ < DistanceToPlayer ) {
				BossMeleeSkillsInRange[z] = BossMeleeSkills [i];
				z++;
			}
		}
		return BossMeleeSkillsInRange;
	}

	private void isPlayerInMeleeRange() {
		
	}

	// This is a check to see of the Boss is at low health.
	private void isBossLowHealth() {
		int BossHealth = gameObject.GetComponent<BossHealth> ().HealthPoints;


	}


}
