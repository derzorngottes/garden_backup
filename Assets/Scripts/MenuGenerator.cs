using UnityEngine;
using System.Collections;

public class MenuGenerator : MonoBehaviour {

	void onGUI() {
		GUI.Box (new Rect (10, 10, 100, 90), "Menu");

		if(GUI.Button(new Rect(20,40,80,20), "Load Game")) {
			// Application.LoadLevel();
		}
			
	}
}
