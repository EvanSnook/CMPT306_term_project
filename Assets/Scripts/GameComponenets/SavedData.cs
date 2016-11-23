using UnityEngine;
using System.Collections;

public class SavedData : MonoBehaviour {

	public int SkillPoints; // This is the number of skill points that the player currently has.
	public float TimeRemaining; // This is the time that is remaining for the player.

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

}
