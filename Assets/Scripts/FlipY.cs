using UnityEngine;
using System.Collections;

public class FlipY : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
	}
}
