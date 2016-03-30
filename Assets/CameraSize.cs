using UnityEngine;
using System.Collections;

public class CameraSize : MonoBehaviour {

	public Camera camera;

	public float counter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.Q)) {
		
			counter ++;
			camera.orthographicSize = counter;
		
		}
		if (Input.GetKey (KeyCode.E)) {
			
			counter --;
			camera.orthographicSize = counter;
			
		}
		if (Input.GetKey (KeyCode.R)) {
			

			Application.LoadLevel("LevelGenerator");
			
		}

	}
}
