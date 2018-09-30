using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitGoal : MonoBehaviour {

	public bool hitGoal;

	// Use this for initialization
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "trail"){
			hitGoal = true;
			print("hit goal");
		}
	}
}
