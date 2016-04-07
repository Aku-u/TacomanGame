using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {

	public float speed;

	public Transform Trans;

	public Transform RenderTacoman;

	public Transform RenderGun;

	public Transform RenderRay;


	public bool facingRight;

	public float rotationz;

	public Vector2 newScaleGun;
	public Vector2 newScaleTaco;

	public Vector2 newSacaleRay;

	public Texture2D Point;

	void Start(){

		//Cursor.visible = false;

		facingRight = true;


	}

	void FixedUpdate(){
		var mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePos, Vector3.forward);

		transform.rotation = rot;

		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);

		Cursor.SetCursor(Point, new Vector2(mousePos.x + (Point.height/2), mousePos.y + (Point.height/2)), CursorMode.Auto);

		rotationz = Trans.eulerAngles.z;

		if ((rotationz >= 180) && facingRight) {

			Flip ();

		
		} else if (rotationz <= 180 && !facingRight) {

			Flip ();

		} 
	}

	public void Flip(){

		newScaleGun = RenderGun.localScale;
		
		newScaleGun.y *= -1;
		
		RenderGun.localScale = newScaleGun;

		newScaleTaco = RenderTacoman.localScale;
		
		newScaleTaco.x *= -1;
		
		RenderTacoman.localScale = newScaleTaco;

		newSacaleRay = RenderRay.localScale;
		
		newSacaleRay.x *= -1;
		
		RenderRay.localScale = newSacaleRay;


		facingRight = !facingRight;




	}

}