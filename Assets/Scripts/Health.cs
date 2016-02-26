using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {


	public int Cure;

	public GameObject Player;

	// Use this for initialization
	void Start () {
	
		Player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
		
			Player.transform.GetComponent<PlayerLogic> ().setLife(Cure);

			Destroy(this.gameObject);
		}


	}

}
