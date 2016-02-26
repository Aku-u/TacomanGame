using UnityEngine;
using System.Collections;

public class BulletEnemy: MonoBehaviour {
	public float damage;

	// Use this for initialization
	void Start () {
	
		damage = 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){


		// SI NO ES TAG DETECTION, REALIZA LA COLISION
		if (other.tag == "Border") {
			
			// LA EXPLOSION SE DESTRUYE A LOS 0.5SEG
			Debug.Log ("Hola");
			// DESTRUIR BALA
			Destroy (gameObject);
		}
		if (other.tag == "Player") {
			
			// LA EXPLOSION SE DESTRUYE A LOS 0.5SEG
			Debug.Log ("Tocado");

			other.transform.GetComponent<PlayerLogic>().setDamage(damage);

			// DESTRUIR BALA
			Destroy (gameObject);
		}
	}
}
