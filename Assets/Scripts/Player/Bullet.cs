using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
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

		if (other.tag == "Enemy") {

			other.transform.GetComponent<Enemy1>().setDamage(damage);
			// LA EXPLOSION SE DESTRUYE A LOS 0.5SEG
			Debug.Log ("Enemy");
			

			Destroy (gameObject);


			// DESTRUIR BALA


		}
	}
}
