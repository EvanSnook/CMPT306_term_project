using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int HealthPoints; // This is the total number of Health this Object Has.

	private bool isPlayer; // If this is the player have it's death do something different.
	private float StartingHealthPoints; // This is the health points that the player has at the start.

	void Start() {
		StartingHealthPoints = HealthPoints; // This just sets the StartingHealthPoints to the health points that were there when they started.
		if (gameObject.tag == "Player") { // Check if the current object is the player or not.
			isPlayer = true;
		} else {
			isPlayer = false;
		}
	}


	void Update() {
		if (HealthPoints <= 0) { // If health is 0 or less call Death.
			Death ();
		}
	}


	// Apply damage to this object.
	public void ApplyDMG(int DMG) {
		HealthPoints -= DMG;
	}
    // This is what happends when dead.
    public void Death() {
        if (!isPlayer) { // If this is the player then do not destroy it
            Destroy(gameObject);
        }
	}

	// This checks to see if this is at full health.
	public bool isFullHealth() {
		if (HealthPoints == StartingHealthPoints) {
			return true;
		} else {
			return false;
		}
	}
}
