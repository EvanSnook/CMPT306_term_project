using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int HealthPoints; // This is the total number of Health this Object Has

	private float StartingHealthPoints; // This is the health points that the player has at the start.
	public GameObject DeathManagerObject; // This is the object that holds what to 


	void Start() {
		DeathManagerObject = GameObject.Find ("DeathManagerObject"); // This gets a reference to the death Manager Object.
		StartingHealthPoints = HealthPoints; // This just sets the StartingHealthPoints to the health points that were there when they started.
	}


	void Update() {
		if (HealthPoints <= 0) { // If health is 0 or less call Death.
			if (gameObject.tag == "Player") { // If this object is the player call PlayerDeath.
				PlayerDeath ();
			} else {
				Death ();
			}
		}
	}


	// Apply damage to this object.
	public void ApplyDMG(int DMG) {
		HealthPoints -= DMG;
	}
	
    // This is what happends when objects other than the player die.
    public void Death() {
	    Destroy(gameObject); // Destroy this object.
	}

	// This is what happends when the player dies.
	public void PlayerDeath() {
		DeathManagerObject.GetComponent<RespawnController> ().SendMessage("PlayerOrBossDied"); // Player Died send message to tell the Gravekeeper about it.
		Destroy(gameObject); // Destroy the body.
	}
}
