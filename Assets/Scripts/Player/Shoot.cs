using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class Shoot : MonoBehaviour
{
	public Rigidbody2D projectile;
	public float speed = 20;

	public AudioClip impact;
	AudioSource audio;
	void Start(){
	
		audio = GetComponent<AudioSource>();
	
	}
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Rigidbody2D instantiatedProjectile = Instantiate(projectile,transform.position,transform.rotation)as Rigidbody2D;
			instantiatedProjectile.velocity = transform.TransformDirection(new Vector2(0, speed));
			audio.PlayOneShot(impact, 0.7F);
		}
	}

}