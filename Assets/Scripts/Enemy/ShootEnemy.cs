using UnityEngine;
using System.Collections;

public class ShootEnemy : MonoBehaviour
{
	public Rigidbody2D projectile;
	public float speed = 20;

	public float fireRate;
	public bool Active;
	void Start(){
		Active = false;
	
	}
	// Update is called once per frame
	void Update ()
	{
		if (Active) {
			if (fireRate <= 0) {
					Rigidbody2D instantiatedProjectile = Instantiate (projectile, transform.position, transform.rotation)as Rigidbody2D;
					instantiatedProjectile.velocity = transform.TransformDirection (new Vector2 (0, speed));
					fireRate = 2f;

			}
		}

		fireRate = fireRate -Time.deltaTime;
	}
	public void setAim()
	{
		fireRate = 0.6f;
		Active = !Active;
	}
	public void setRute ()
	{
		fireRate = 0.6f;
		Active = !Active;
	}

}