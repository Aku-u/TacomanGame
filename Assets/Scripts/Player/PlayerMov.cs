using UnityEngine;
using System.Collections;


public class PlayerMov : MonoBehaviour {
	public float move;
	public float speed;

	public Rigidbody2D rigidBody2D;

	void Start()
	{

	}
	void Update () {
	

				
		move = Input.GetAxis ("Vertical");
		// Movement
		rigidBody2D.velocity = new Vector2 (move * speed, rigidBody2D.velocity.y);

		move = Input.GetAxis ("Horizontal");
		// Movement
		rigidBody2D.velocity = new Vector2 (move * speed, rigidBody2D.velocity.x);


	
	}

}