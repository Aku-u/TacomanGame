using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {

	public float speed;

	public Transform Trans;

	public Transform RenderTacoman;

	public Transform RenderGun;

	public bool facingRight;

	public float rotationz;

	public Vector2 newScaleGun;
	public Vector2 newScaleTaco;
	void Start(){

		facingRight = true;
	}

	void FixedUpdate(){
		var mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePos, Vector3.forward);

		transform.rotation = rot;

		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);

		/*
		if (move > 0 && facingRight) Flip ();
		else if (move < 0 && !facingRight) Flip ();


		if (Trans.localRotation.eulerAngles >= new Vector3(180,0,0)) {
		
			if(RenderTacoman.transform.localScale.x >= 0){

				RenderTacoman.transform.localScale.x *= -1;
				RenderGun.transform.localScale.x *= -1;
			}

		
		}*/
		rotationz = Trans.eulerAngles.z;

		if ((rotationz >= 180)&&facingRight) Flip();
		else if (rotationz <= 180 && !facingRight) Flip ();

	}

	public void Flip(){

		newScaleGun = RenderGun.localScale;
		
		newScaleGun.y *= -1;
		
		RenderGun.localScale = newScaleGun;

		newScaleTaco = RenderTacoman.localScale;
		
		newScaleTaco.x *= -1;
		
		RenderTacoman.localScale = newScaleTaco;
		
		facingRight = !facingRight;



	}

}