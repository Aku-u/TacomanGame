using UnityEngine;
using System.Collections;

public class trail : MonoBehaviour {


	public LineRenderer line;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		var mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePos, Vector3.forward);
		
		transform.rotation = rot;
		
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);

		//line.SetPosition (2, mousePos);

	}
}
