using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {

	public GameManager game;

	// Use this for initialization
	void Start () {
		game = GameObject.FindGameObjectWithTag ("GameManager").
			// OBTENGO SU COMPONENTE PlayerLogic
			GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	 
		if (Input.GetKey (KeyCode.Q)) {
			

			Application.LoadLevel("LevelGenerator");
			
		}
	}

	public void OnClickPlay(){

		Application.LoadLevel("lvl2");
	}
	public void OnClickChallenges(){
		
		Application.LoadLevel("lvl2");
	}
	public void Resume(){

		game.setGame ();

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
