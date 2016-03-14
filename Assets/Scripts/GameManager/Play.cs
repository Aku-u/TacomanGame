using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClickPlay(){

		Application.LoadLevel("lvl2");
	}
	public void OnClickChallenges(){
		
		Application.LoadLevel("lvl2");
	}
	public void Settings(){
		
		Application.LoadLevel("lvl2");
	}
	public void Quit(){
		
		Application.Quit();
	}
	public void Restart(){

		NextLevel.levelDificulty = 12;
		Application.LoadLevel("lvl2");

	}
}
