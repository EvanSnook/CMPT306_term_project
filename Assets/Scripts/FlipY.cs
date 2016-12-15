using UnityEngine;
using System.Collections;

public class FlipY : MonoBehaviour {

    // This inverts the y scale fliping the object around the y.
	void Start () {
		transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
	}
}
