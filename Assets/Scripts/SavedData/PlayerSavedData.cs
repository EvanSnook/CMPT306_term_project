using UnityEngine;
using System.Collections;

public class PlayerSavedData : MonoBehaviour {

	public int SkillPoints; // This is the number of skill points that the player currently has.
    //currently equipped skills
    public Object QSkill;
    public Object ESkill;
    public Object RWSkill;
    public Object RSSkill;
    public Object MWSkill;
    public Object MSSkill;


	// This is called to add a specific number of points when sent message.
	public void AddSkillPoints(int NumberOfPoints) {
		SkillPoints += NumberOfPoints;
	}

    public void SubtractSkillPoints(int NumberOfPoints)
    {
        SkillPoints -= NumberOfPoints;
    }

	// Save any Data for the player.
	public void DeathSavePlayer () {
		// Currently Do nothing.
	}
}
