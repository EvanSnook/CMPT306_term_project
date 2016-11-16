using UnityEngine;
using System.Collections;

public class SavedData : MonoBehaviour {

	public float BossHealth; // This is the Health of the Boss that will be loaded.
	public int SkillPoints; // This is the number of skill points that the player currently has.
	public float TimeRemaining; // This is the time that is remaining for the player.
	public int NumberOfPlayerDeaths; // This is the number of times the player has died.

	/*
		This makes this object not be destroyed when switching scenes.
	*/
	void Start () {
		DontDestroyOnLoad (gameObject);
		SkillPoints = 0;
	}
		
	/*
		This is called to add a specific number of points when sent message.
	 */
	public void AddSkillPoints(int NumberOfPoints) {
		SkillPoints += NumberOfPoints;
	}


	/*
		This will be invoked to save the health that the boss has when the player dies and goes back to the spawn room. 
		The boss health will take this value when loading scene.
	 */
	public void SaveBossHealth(float Health) {
		BossHealth = Health;
	}


}
