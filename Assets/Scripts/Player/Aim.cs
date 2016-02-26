using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {

	public float speed;

	void FixedUpdate(){
		var mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePos, Vector3.forward);

		transform.rotation = rot;

		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);


	}
}