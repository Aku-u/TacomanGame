using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {
	public string currentlevel;

	public static int levelDificulty;
	public static int Chests;
	// Use this for initialization
	void Awake(){

		levelDificulty = 12;
		Chests = 2;
	
	}
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		
		levelDificulty += 2;
		if (other.tag == "Player") {

			currentlevel  = Application.loadedLevelName;

			if(currentlevel == "lvl2 "){

				Application.LoadLevel("lvl1");
			}

			Application.LoadLevel("lvl2");
		}
		
	}
}
