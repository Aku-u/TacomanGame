using UnityEngine;
using System.Collections;

public class EnemyDetection : MonoBehaviour {

	public GameObject Shoot;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnTriggerEnter2D(Collider2D other){

		
		if (other.tag == "Player") {
			Debug.Log("Player Entrando");

			transform.parent.GetComponent<Enemy1> ().setAim();
			Shoot.GetComponent<ShootEnemy>().setAim();
		}
		
	}
	public void OnTriggerExit2D(Collider2D other){
		
		
		if (other.tag == "Player") {
			Debug.Log("Player saliendo");	
			transform.parent.GetComponent<Enemy1> ().setRute();
			Shoot.GetComponent<ShootEnemy>().setRute();
		}
		
	}
}
