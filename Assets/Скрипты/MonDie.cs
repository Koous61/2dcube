using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonDie : MonoBehaviour {

	public GameObject other;

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			Mon.lives--;
			Destroy (other);
		}
	}

}
