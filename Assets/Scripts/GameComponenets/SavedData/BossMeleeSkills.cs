using UnityEngine;
using System.Collections;

public class BossMeleeSkills : MonoBehaviour {

	public int NumberOfBasicMeleeUsed; // This holds the number of times that the boss has used the Basic Melee.
	public int TotalDMGDoneWithBasicMelee; // This is the total about of Damage that has been done with the basic melee.

	public int NumberOfSkill1; // This is just a place holder for the future.
	public int TotalDMGDoneWithSkill1; // This is just a place holder for the future.

	void Start () {
		
	}

	// This just increments for if the Basic Melee has been used.
	public void BasicMeleeUsed() {
		NumberOfBasicMeleeUsed++;
	}
	
}
