using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour {
	public float health;
	public float maxHealt;

	public GameObject HealthCont;
	public GameObject Coins;
	public float num;
	public Transform target; 
	public GameObject trans;

	public GameObject Explosion;

	public CircleCollider2D detection;

	public bool Active;
	
	public GameObject[] enemy;

	public GameObject nextLevel;

	public GameObject Enemy;

	public GameObject EnemyDeath;
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
		enemy = GameObject.FindGameObjectsWithTag("Enemy1");
		// CUANDO VIDA LLEGA A CERO --> DIE()
		if (health <= 0) {

			Instantiate (Explosion, new Vector3(transform.position.x, transform.position.y,-0.36F), Quaternion.identity);
			num= Random.Range(0,100);
			if(num >= 90){

				Instantiate (HealthCont, new Vector3(transform.position.x, transform.position.y,-0.36F), Quaternion.identity);

			}
			if(num <= 30){
				Instantiate (Coins, new Vector3(transform.position.x, transform.position.y,-0.36F), Quaternion.Euler(0, 0, num * 20));
				Instantiate (Coins, new Vector3(transform.position.x + (num / 100), transform.position.y + (num / 90),-0.36F), Quaternion.Euler(0, 0, num * 10));
				Instantiate (Coins, new Vector3(transform.position.x + (num / 90), transform.position.y + (num / 80),-0.36F), Quaternion.Euler(0, 0, num * 4));
				Instantiate (Coins, new Vector3(transform.position.x - (num / 110), transform.position.y - (num / 110),-0.36F), Quaternion.Euler(0, 0, num * 7));
				
			}
			else if(num <= 60){
				Instantiate (Coins, new Vector3(transform.position.x, transform.position.y,-0.36F), Quaternion.Euler(0, 0, 50));
				Instantiate (Coins, new Vector3(transform.position.x + (num / 90), transform.position.y + (num / 90),-0.36F), Quaternion.Euler(0, 0, num * 3));
				Instantiate (Coins, new Vector3(transform.position.x + (num / 100), transform.position.y - (num / 120),-0.36F), Quaternion.Euler(0, 0, num * 1));
				Instantiate (Coins, new Vector3(transform.position.x + (num / 110), transform.position.y + (num / 100),-0.36F), Quaternion.Euler(0, 0, num * 10));
				Instantiate (Coins, new Vector3(transform.position.x - (num / 110), transform.position.y - (num / 100),-0.36F), Quaternion.Euler(0, 0, num * 200));
			}
			else if(num <= 80){
				Instantiate (Coins, new Vector3(transform.position.x, transform.position.y,-0.36F), Quaternion.Euler(0, 0, 180));
				Instantiate (Coins, new Vector3(transform.position.x - (num / 120), transform.position.y - (num / 120),-0.36F), Quaternion.Euler(0, 0, num * 20));
				Instantiate (Coins, new Vector3(transform.position.x + (num / 80), transform.position.y + (num / 100),-0.36F), Quaternion.Euler(0, 0, num * 17));
				Instantiate (Coins, new Vector3(transform.position.x + (num / 90), transform.position.y - (num / 110),-0.36F), Quaternion.Euler(0, 0, num * 10));
				Instantiate (Coins, new Vector3(transform.position.x + (num / 80), transform.position.y + (num / 90),-0.36F), Quaternion.Euler(0, 0, num));
				Instantiate (Coins, new Vector3(transform.position.x - (num / 130), transform.position.y - (num / 130),-0.36F), Quaternion.Euler(0, 0, num * 10));
				
			}
			if (enemy.Length == 1) {
				Debug.Log("Solo quedas tuu");

				Instantiate (nextLevel, new Vector3(transform.position.x, transform.position.y,0), Quaternion.identity);
			
			}
			Instantiate (EnemyDeath, new Vector3(transform.position.x, transform.position.y,-0.36F), Quaternion.identity);
			Destroy(Enemy);
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
