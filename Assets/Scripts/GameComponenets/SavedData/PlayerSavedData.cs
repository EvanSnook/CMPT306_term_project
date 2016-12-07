using UnityEngine;
using System.Collections;

public class PlayerSavedData : MonoBehaviour {

	public int SkillPoints; // This is the number of skill points that the player currently has.

    public int NumberOfDeaths; // This is the number of times that the player has died.
    public int DamageDoneToBoss; // This is the damage done to the boss by the player.

    //currently equipped skills
    public GameObject QSkill;
    public GameObject ESkill;
    public GameObject RWSkill;
    public GameObject RSSkill;
    public GameObject MWSkill;
    public GameObject MSSkill;

    void Start() {
        NumberOfDeaths = 0;
    }

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
		// Do nothing.
	}

    // This is called when the player dies and increments the number of deaths for the player.
    public void PlayerDied () {
        NumberOfDeaths++;
    }


    // This is called when the game goes to the main menu and resets all the saved data for a new game.
    public void ResetPlayerSavedData () {
        NumberOfDeaths = 0; // This resets the number of deaths to 0.
        SkillPoints = 0; // This resets the number of skill points to 0.
        DamageDoneToBoss = 0; // This resets the Damage Done to the boss to 0.
    }

}
