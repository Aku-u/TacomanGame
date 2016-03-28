using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour {
	
	private Animator animator;
	private Vector3 Enemy;
	private Vector2 EnemyDirection;
	private int Ground;
	
	public float xDir;
	public float yDir;
	private float speed = 10;
	
	void Start () 
	{
		animator = this.GetComponent<Animator>();
		Ground = 1 << 12;
	}
	
	void Update () 
	{
		Enemy = GameObject.Find ("Player").transform.position;
		
		xDir = Enemy.x - transform.position.x;
		yDir = Enemy.y - transform.position.y;
		
		EnemyDirection = new Vector2 (xDir, yDir);
		
		//line of sight
		if (!Physics2D.Raycast(transform.position, EnemyDirection, 1, Ground))
		{
			GetComponent<Rigidbody2D>().AddForce(EnemyDirection.normalized * speed);
		}
		
		// directional control
		if (yDir > 1)
		{
			animator.SetInteger("Direction", 2);
			animator.SetFloat("Speed", 1.0f);
		}
		else if (yDir < -1)
		{
			animator.SetInteger("Direction", 0);
			animator.SetFloat("Speed", 1.0f);
		}
		else if (xDir < -1)
		{
			animator.SetInteger("Direction", 1);
			animator.SetFloat("Speed", 1.0f);
		}
		else if (xDir > 1)
		{
			animator.SetInteger("Direction", 3);
			animator.SetFloat("Speed", 1.0f);
		}
		else
		{
			animator.SetFloat("Speed", 0.0f);
		}
	}
}