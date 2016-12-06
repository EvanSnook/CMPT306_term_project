using UnityEngine;
using System.Collections;

public class BossRangedSkills : MonoBehaviour {

	public int NumberOfBasicRangedUsed; // This holds the number of times that the boss has used the Basic Ranged.
	public int TotalDMGDoneWithRangedMelee; // This is the total about of Damage that has been done with the Basic Ranged.

	public int NumberOfSkill1; // This is just a place holder for the future.
	public int TotalDMGDoneWithSkill1; // This is just a place holder for the future.


	void Start () {
	
	}

	// This just increments for if the Basic Ranged has been used.
	public void BasicMeleeUsed() {
		NumberOfBasicRangedUsed++;
	}

}
