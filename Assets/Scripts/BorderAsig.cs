using UnityEngine;
using System.Collections;

public class BorderAsig : MonoBehaviour {


	public bool Down;
	public bool Up;
	public bool Left;
	public bool Right;

	private bool ADown;
	private bool AUp;
	private bool ALeft;
	private bool ARight;


	public GameObject Shadow;
	public GameObject LeftG;
	public GameObject RightG;
	public GameObject UpG;
		

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Down && !ADown) {
		
			ShadownIntantiate();
		
		}
		if (Left && !ALeft) {
			
			LeftGIntantiate();
			
		}
		if (Right && !ARight) {
			
			RightGIntantiate();
			
		}
		if (Up && !AUp) {
			
			UpGIntantiate();
			
		}


	}
	void ShadownIntantiate(){

		Instantiate (Shadow, transform.position, transform.rotation);
		ADown = true;
	}
	void LeftGIntantiate(){
		
		Instantiate (LeftG, transform.position, Quaternion.Euler(new Vector3(0, 0, 270)));
		ALeft = true;
	}
	void RightGIntantiate(){
		
		Instantiate (RightG, transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
		ARight = true;
	}
	void UpGIntantiate(){
		
		Instantiate (UpG, transform.position, Quaternion.Euler(new Vector3(0, 0, 270)));
		AUp = true;
	}
}
