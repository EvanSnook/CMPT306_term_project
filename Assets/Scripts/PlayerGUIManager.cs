using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerGUIManager : MonoBehaviour {

	public GameObject MainGUI;

	Text HealthNumberGUI; // This is the Element that Holds how much Health the player has.
	Text DeathsNumberGUI; // This is the Element that Holds how many times the player has died.


	void Start () {
		HealthNumberGUI = GetComponent<Text> ();
		DeathsNumberGUI = GetComponent<Text> ();
	}


	/*


	 */

}
