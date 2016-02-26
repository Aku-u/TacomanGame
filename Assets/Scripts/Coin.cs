using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {


	public int Points;

	public GameObject Player;

	// Use this for initialization
	void Start () {
	
		Player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
		
			Player.transform.GetComponent<PlayerLogic> ().setPoints(Points);

			Destroy(this.gameObject);
		}


	}

}
