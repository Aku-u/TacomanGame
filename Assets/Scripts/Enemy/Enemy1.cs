using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour {
	public float health;
	public float maxHealt;

	public Transform target; 
	public GameObject trans;

	public CircleCollider2D detection;

	public bool Active;
	
	public GameObject[] enemy;

	public GameObject nextLevel;
	// Use this for initialization
	void Start () {
	

		Active = false;
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
		
		if (Active) {

			Vector2 direction = new Vector2 (target.position.x - transform.position.x, target.position.y - transform.position.y);
			float rotation = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
			this.transform.eulerAngles = new Vector3 (0, 0, rotation);
		}
	}
	public void setDamage(float damage){

		health -= damage;
		enemy = GameObject.FindGameObjectsWithTag("Enemy");
		// CUANDO VIDA LLEGA A CERO --> DIE()
		if (health <= 0) {
		
			if (enemy.Length == 1) {
				Debug.Log("Solo quedas tuu");

				Instantiate (nextLevel, new Vector3(transform.position.x, transform.position.y,0), Quaternion.identity);
			
			}
			Destroy(this.gameObject);
		}

	}
	public void setAim()
	{
		Active = !Active;
	}
	public void setRute ()
	{
		Active = !Active;
	}

}
