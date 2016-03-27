using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class Shoot : MonoBehaviour
{
	public Rigidbody2D projectile;
	public float speed = 20;

	public float ratioShoot;
	private float ratioShoot2;
	public float bullets;
	 

	public AudioClip impact;

	AudioSource audio;
	void Start(){
	
		audio = GetComponent<AudioSource>();
		ratioShoot2 = ratioShoot;
		ratioShoot = 0;


	}
	// Update is called once per frame
	void Update ()
	{
		if ( (Input.GetButton ("Fire1"))&& (bullets != 0) && (ratioShoot <= 0)) {
			Rigidbody2D instantiatedProjectile = Instantiate (projectile, transform.position, transform.rotation)as Rigidbody2D;
			instantiatedProjectile.velocity = transform.TransformDirection (new Vector2 (speed, 0));
			audio.PlayOneShot (impact, 0.7F);
			bullets --;
			ratioShoot = ratioShoot2;
		} else if (ratioShoot >= 0) {
			ratioShoot -= Time.deltaTime;
		}
	}

}