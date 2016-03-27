using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class Shoot : MonoBehaviour
{
	public Rigidbody2D projectile;
	public float speed = 20;

	public float ratioShootGun;
	private float ratioShootGun2;

	public float ratioShootRay;
	private float ratioShootRay2;

	public float bulletsGun;
	public float bulletsRay;

	public int GunType;

	public AudioClip impact;
	public ray rayhit;
	AudioSource audio;
	void Start(){
	
		audio = GetComponent<AudioSource>();
		ratioShootGun2 = ratioShootGun;
		ratioShootGun = 0;
		ratioShootRay2 = ratioShootRay;
		ratioShootRay = 0;


		GunType = 1;

	}
	// Update is called once per frame
	void Update ()
	{
		if (GunType == 1) {
			if ((Input.GetButton ("Fire1")) && (bulletsGun != 0) && (ratioShootGun <= 0)) {
				Rigidbody2D instantiatedProjectile = Instantiate (projectile, transform.position, transform.rotation)as Rigidbody2D;
				instantiatedProjectile.velocity = transform.TransformDirection (new Vector2 (speed, 0));
				audio.PlayOneShot (impact, 0.7F);
				bulletsGun --;
				ratioShootGun = ratioShootGun2;
			} else if (ratioShootGun >= 0) {
				ratioShootGun -= Time.deltaTime;
			}
			if(Input.GetKeyDown(KeyCode.Alpha2)){

				GunType = 2;
			}
		}
		if (GunType == 2) {

			if ((Input.GetButton ("Fire1")) && (bulletsRay != 0) && (ratioShootRay <= 0)) {

				if(rayhit.Spooted)
				{
					rayhit.AdDamage();
				}
				bulletsRay --;
				ratioShootRay = ratioShootRay2;
			} else if (ratioShootRay >= 0) {
				ratioShootRay -= Time.deltaTime;
			}

		
			if(Input.GetKeyDown(KeyCode.Alpha1)){
				
				GunType = 1;
			}
		
		}
	}

}