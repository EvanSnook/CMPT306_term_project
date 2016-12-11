using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlockSightManager : MonoBehaviour {

	public List<GameObject> otherFlock = new List<GameObject>();

	private GameObject parent;

	void Start () {
		parent = transform.parent.gameObject;
	}

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject != parent && other.gameObject.GetComponent("FlockAI") != null) {
			otherFlock.Add(other.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject != parent && other.gameObject.GetComponent("FlockAI") != null) {
		otherFlock.Remove(other.gameObject);
		}
	}
}
