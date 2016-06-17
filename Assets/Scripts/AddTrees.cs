using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AddTrees : MonoBehaviour {

	public Transform Tree2Large;

	public void PlaceTrees() {

		Vector3[] meshVertices = gameObject.GetComponent<MeshFilter>().mesh.vertices;

		int everyNth = 0;

		List<Vector3> pointsToAddTrees = new List<Vector3> ();


		for(int i = 0; i < meshVertices.Length; i++) {
			if (everyNth == 27) {
				if(meshVertices[i].y > 0.5) {
					pointsToAddTrees.Add (transform.TransformPoint(meshVertices [i]));
					everyNth = 0;	
				}
			} else {
				everyNth ++;
			}

		}

		Debug.Log (pointsToAddTrees [30]);

		for(int j = 0; j < pointsToAddTrees.Count; j++) {
			Instantiate (Tree2Large, pointsToAddTrees [j], Quaternion.Euler(270,0,0));
		}
	
	}

	void Start() {
		PlaceTrees ();
	}
}
