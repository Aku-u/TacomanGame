using UnityEngine;
using System.Collections;

using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class Shoot : MonoBehaviour
{
	public Rigidbody2D projectile;
	public float speed = 20;

	public SpriteRenderer Gunsprite;

	public Sprite GunS;
	public Sprite M4S;
	public Sprite RayS;

	public GameObject RayGun;



	public float bulletsGun;
	public float ratioShootGun;
	private float ratioShootGun2;
	public Image Gun;

	public float bulletsRay;
	public float ratioShootRay;
	private float ratioShootRay2;
	public Image Ray;

	public float bulletM4;
	public float ratioShootM4;
	private float ratioShootM42;
	public Image M4;

	public int GunType;

	public AudioClip impact;
	public ray rayhit;
	AudioSource audio;
	void Start(){
	
		RayGun.SetActive (false);
		audio = GetComponent<AudioSource>();
		ratioShootGun2 = ratioShootGun;
		ratioShootGun = 0;
		ratioShootRay2 = ratioShootRay;
		ratioShootRay = 0;
		ratioShootM42 = ratioShootM4;
		ratioShootM4 = 0;
		M4.enabled = false;
		Ray.enabled = false;
		Gun.enabled = true;

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
				M4.enabled = false;
				Ray.enabled = true;
				Gun.enabled = false;
				RayGun.SetActive (true);
				Gunsprite.sprite = RayS;

				GunType = 2;
			}
			if(Input.GetKeyDown(KeyCode.Alpha3)){
				M4.enabled = true;
				Ray.enabled = false;
				Gun.enabled = false;
				Gunsprite.sprite = M4S;
				GunType = 3;
			}
		}
		if (GunType == 3) {
			if ((Input.GetButton ("Fire1")) && (bulletM4 != 0) && (ratioShootM4 <= 0)) {
				Rigidbody2D instantiatedProjectile = Instantiate (projectile, transform.position, transform.rotation)as Rigidbody2D;
				instantiatedProjectile.velocity = transform.TransformDirection (new Vector2 (speed, 0));
				audio.PlayOneShot (impact, 0.7F);
				bulletM4 --;
				ratioShootM4 = ratioShootM42;
			} else if (ratioShootM4 >= 0) {
				ratioShootM4 -= Time.deltaTime;
			}
			if(Input.GetKeyDown(KeyCode.Alpha2)){
				M4.enabled = false;
				Ray.enabled = true;
				Gun.enabled = false;
				Gunsprite.sprite = RayS;
				GunType = 2;
			}
			if(Input.GetKeyDown(KeyCode.Alpha1)){

				M4.enabled = false;
				Ray.enabled = false;
				Gun.enabled = true;
				Gunsprite.sprite = GunS;
				GunType = 1;
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
				M4.enabled = false;
				Ray.enabled = false;
				Gun.enabled = true;
				Gunsprite.sprite = GunS;
				RayGun.SetActive (false);
				GunType = 1;
			}
			if(Input.GetKeyDown(KeyCode.Alpha3)){

				M4.enabled = true;
				Ray.enabled = false;
				Gun.enabled = false;
				Gunsprite.sprite = M4S;
				RayGun.SetActive (false);
				GunType = 3;
			}
		
		}
	}

}