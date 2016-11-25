using UnityEngine;
using System.Collections;

public class PlayerSavedData : MonoBehaviour {

	public int SkillPoints; // This is the number of skill points that the player currently has.

	// Use this for initialization
	void Start () {
		SkillPoints = 0; // Initializes Skill Points to 0.
	}
	
	/*
		This is called to add a specific number of points when sent message.
	 */
	public void AddSkillPoints(int NumberOfPoints) {
		SkillPoints += NumberOfPoints;
	}

    public void SubtractSkillPoints(int NumberOfPoints)
    {
        SkillPoints -= NumberOfPoints;
    }

}
