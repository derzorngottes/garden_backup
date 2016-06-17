using UnityEngine;
using System.Collections;

public class ScreenShot : MonoBehaviour {

	// the URL (with endpoint) it will be sent to, and the file name it will be called
	public string screenShotURL= "http://our-server.html/post";
	public string fileName;

	IEnumerator UploadPic(string fileName, string screenShotURL) {
		// We should only read the screen after all rendering is complete
		yield return new WaitForEndOfFrame();

		// Create a texture the size of the screen, RGB24 format
		int width = Screen.width;
		int height = Screen.height;
		var tex = new Texture2D( width, height, TextureFormat.RGB24, false );

		// Read screen contents into the texture
		tex.ReadPixels( new Rect(0, 0, width, height), 0, 0 );
		tex.Apply();

		// Encode texture into PNG
		byte[] bytes = tex.EncodeToPNG();
		Destroy( tex );

		// Create a Web Form with info to pass with POST request
		WWWForm form = new WWWForm();
		form.AddField("frameCount", Time.frameCount.ToString());
		form.AddBinaryData("fileUpload", bytes, fileName, "image/png");

		// Upload to URL specified
		WWW w = new WWW(screenShotURL, form);
		yield return w;
		if (!string.IsNullOrEmpty(w.error)) {
			print(w.error);
		}
		else {
			print("Finished Uploading Screenshot");
		}
	}

	// Initialization for UploadPic
	void UploadPicture(string fileName, string screenShotURL) {
		StartCoroutine(UploadPic(fileName, screenShotURL));
	}

	// Creates menu on screen for image capture
	void OnGUI() {
		GUILayout.BeginArea(new Rect(0,0, 100, 100)); 			// creates menu body
		fileName = GUILayout.TextField(fileName);				// creates editable text field with file name
		screenShotURL = GUILayout.TextField(screenShotURL);		// creates editable text field with URL to send to
		if(GUILayout.Button("Take picture")) {					// creates button "Take Picture" and if clicked, calls UploadPicture function
			UploadPic(fileName, screenShotURL);
		}
		GUILayout.EndArea();									// removes image capture menu after picture is sent
	}
}