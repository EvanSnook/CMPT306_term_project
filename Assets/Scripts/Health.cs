using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float HealthPoints; // This is the total number of Health this Object Has.

	private bool isPlayer; // If this is the player have it's death do something different.

	void Start() {
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
        if (isPlayer) { // If Player then do something different than enemy.
            SendMessage("ChangeLevel");
        } else { // If anything else just destroy the object.
            Destroy(gameObject);
        }
	}
}
