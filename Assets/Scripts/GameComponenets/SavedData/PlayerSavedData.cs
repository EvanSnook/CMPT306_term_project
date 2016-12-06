using UnityEngine;
using System.Collections;

public class PlayerSavedData : MonoBehaviour {

	public int SkillPoints; // This is the number of skill points that the player currently has.
    //currently equipped skills
    public GameObject QSkill;
    public GameObject ESkill;
    public GameObject RWSkill;
    public GameObject RSSkill;
    public GameObject MWSkill;
    public GameObject MSSkill;

    //takes in the object to add the skills to.
    public void ApplySkillsToPlayer(GameObject Player)
    {
        GameObject newskill;
        if(QSkill != null)
        {
            newskill = Instantiate(QSkill);
            newskill.transform.SetParent(Player.transform, false);
        }
        //TODO add cases for all the other skills keys
    }

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
