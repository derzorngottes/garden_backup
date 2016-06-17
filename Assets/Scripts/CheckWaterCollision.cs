using UnityEngine;
using System.Collections;

public class CheckWaterCollision : MonoBehaviour {

//	private Transform playerTransform;
//
//	void Start() {
//		Vector3 playerPos = GameObject.Find ("Main Camera").transform.position;
//	}
//
//	void upDate() {
//		Vector3 playerPos = playerTransform.position;
//
//		Debug.Log ("player is: " + playerPos);
//	}

	void OnTriggerEnter(Collider other) {
		//Vector3 prevPos = upDate ();
		//upDate();
		Debug.Log("hit water");
	}
}
