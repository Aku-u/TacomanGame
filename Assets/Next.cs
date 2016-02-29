using UnityEngine;
using System.Collections;

public class Next : MonoBehaviour {


	public float count;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;
		if (count >= 3) {
		

			Application.LoadLevel("Menu");
		
		}
	}
}
