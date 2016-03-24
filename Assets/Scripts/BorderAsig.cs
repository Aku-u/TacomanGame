using UnityEngine;
using System.Collections;

public class BorderAsig : MonoBehaviour {


	public bool Down;
	public bool Up;
	public bool Left;
	public bool Right;

	private bool ADown;


	public GameObject Shadow;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Down && !ADown) {
		
			ShadownIntantiate();
		
		}


	}
	void ShadownIntantiate(){

		Instantiate (Shadow, transform.position, transform.rotation);
		ADown = true;
	}
}
