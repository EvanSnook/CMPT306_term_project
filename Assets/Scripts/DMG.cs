using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DMG : MonoBehaviour {
	//public string DMGTargetTag;
	public int DMGDone;
	public float DamageRepeatTime;
	public GameObject Owner;

    public GameObject SavedData; // This is the savedData Object.

	private List<GameObject> CollidingWith = new List<GameObject>();

    void Start () {
        SavedData = GameObject.Find ("SavedData"); // This finds and sets the saved Data.
    }

	void SetOwner (GameObject OwnerIn) {
		Owner = OwnerIn;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		// If the colliding object has health and is not the owner
		if (coll.gameObject.GetComponent("Health") != null && coll.gameObject != Owner) {
			coll.gameObject.SendMessage("ApplyDMG", DMGDone); // Deal damage
            SendToSavedData (DMGDone); // This sends the damage to the saved data.

            if (DamageRepeatTime > 0) { // If this can hit multiple times
				CollidingWith.Add(coll.gameObject); // Add the colliding object to the array of colliding objects
				StartCoroutine("DamageRepeat", coll.gameObject); // Call the repeating damage
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		// If the colliding object has health or bossHealth and is not the owner
		if ((coll.gameObject.GetComponent("Health") != null
		 			|| coll.gameObject.GetComponent("BossHealth") != null) && coll.gameObject != Owner) {
			coll.gameObject.SendMessage("ApplyDMG", DMGDone); // Deal damage
            SendToSavedData (DMGDone); // This sends the damage to the saved data.

            if (DamageRepeatTime > 0) { // If this can hit multiple times
				CollidingWith.Add(coll.gameObject); // Add the colliding object to the array of colliding objects
				StartCoroutine("DamageRepeat", coll.gameObject); // Call the repeating damage
			}
		}
	}

// Remove the object from array of colliding gameObjects
	void OnCollisionExit2D(Collision2D coll) {
		if (CollidingWith.Contains(coll.gameObject)) {
			CollidingWith.Remove(coll.gameObject);
		}
	}

// Remove the object from array of colliding gameObjects
	void OnTriggerExit2D(Collider2D coll) {
		if (CollidingWith.Contains(coll.gameObject)) {
			CollidingWith.Remove(coll.gameObject);
		}
	}

// Damages the colliding object, then calls itself
	IEnumerator DamageRepeat(GameObject theObject) {
		yield return new WaitForSeconds(DamageRepeatTime);
		if (theObject != null) { // Check to make sure the object still exists to avoid errors
			if (CollidingWith.Contains(theObject)) { // If you are still colliding with the object

				theObject.SendMessage("ApplyDMG", DMGDone); // Damage object
                SendToSavedData (DMGDone); // This sends the damage to the saved data.

                StartCoroutine ("DamageRepeat", theObject); // and Call self
			}
		}
	}


    // This sends the Damage done to the saved data.
    private void SendToSavedData(int DMGDone) {
        // This figures out who's attack is being used and sends that damage to the saved data.
        if (this.tag == "PlayerShot") {
            SavedData.GetComponent<PlayerSavedData> ().SendMessage ("PlayerRangedDMG", DMGDone); // This passes the PlayerRanged DMG to the Saved Data.
        }
        else if (this.tag == "PlayerMelee") {
            SavedData.GetComponent<PlayerSavedData> ().SendMessage ("PlayerMeleeDMG", DMGDone); // This passes the PlayerMelee DMG to the Saved Data.
        }
        else if (this.tag == "BossRanged") {
            SavedData.GetComponent<BossSavedData> ().SendMessage ("BossRangedDMG", DMGDone); // This passes the BossRanged DMG to the Saved Data.
        }
        else if (this.tag == "BossMelee") {
            SavedData.GetComponent<BossSavedData> ().SendMessage ("BossMeleeDMG", DMGDone); // This passes the BossMelee DMG to the Saved Data.
        } else if (this.tag == "Boss") {
            SavedData.GetComponent<BossSavedData> ().SendMessage ("BossCollisionDMG", DMGDone); // This passes the BossCollision DMG to the saved Data.
        }

    }

}
