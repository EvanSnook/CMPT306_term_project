using UnityEngine;
using System.Collections;

public class BossSavedData : MonoBehaviour {

	public bool BossSkillsInitialized; // This is for when the boss first
	public int BossStartingHealth; // This is the Health the the boss originally Starts with.
	public int BossCurrentHealth; // This is the current health of the boss.

	public int BossNumberOfDeaths; // This is the number of times that the Boss has been killed.



	void Start() {
		BossCurrentHealth = BossStartingHealth;
		BossSkillsInitialized = false;
	}



}
