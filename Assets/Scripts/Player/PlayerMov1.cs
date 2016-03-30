using UnityEngine;
using System.Collections;


public class PlayerMov1 : MonoBehaviour {
	public float moveX;
	public float moveY;
	public float speed;


	public bool moving;


	public Rigidbody2D rigidBody2D;

	void Start()
	{

	}
	void Update () {
	

				
		moveY = Input.GetAxis ("Vertical");
		// Movement
		rigidBody2D.velocity = new Vector2 (moveY * speed, rigidBody2D.velocity.y);

		moveX = Input.GetAxis ("Horizontal");
		// Movement
		rigidBody2D.velocity = new Vector2 (moveX * speed, rigidBody2D.velocity.x);

		if ((moveX != 0) || (moveY != 0)) {
		
			moving = true;


		}
		if ((moveX == 0) && (moveY == 0)) {
			
			moving = false;

			
		}
	}

}