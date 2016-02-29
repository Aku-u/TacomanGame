using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {


	public int Points;

	public GameObject Player;

	public GameObject fxs;
	public AudioClip impact;
	AudioSource audio;

	// Use this for initialization
	void Start () {
	
		Player = GameObject.FindGameObjectWithTag("Player");
		fxs = GameObject.FindGameObjectWithTag("FX");

		audio = fxs.transform.GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
		
			Player.transform.GetComponent<PlayerLogic> ().setPoints(Points);
			audio.PlayOneShot(impact, 1.5F);

			Destroy(this.gameObject);

		}


	}

}
