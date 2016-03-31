using UnityEngine;
using System.Collections;

public class EnemyRay : MonoBehaviour {

	public float health;
	public float maxHealt;
	public int speed;
	public float Range;
	public GameObject HealthCont;
	public GameObject Coins;
	public float num;

	public GameObject Player;
	public GameObject Explosion;
	public GameObject Parent;
	
	public RaycastHit2D[] hits;

	public GameObject[] enemy;
	
	public GameObject nextLevel;
	
	public GameObject Enemy;
	// Update is called once per frame
	void Start(){
	
		Player = GameObject.FindGameObjectWithTag("Player");
		Range = Vector2.Distance (transform.position, Player.transform.position);


	}

	void Update () {
		//Raycasting ();

		Range = Vector2.Distance (transform.position, Player.transform.position);

		if (Range <= 10) {
		

			Debug.DrawRay (transform.position , Player.transform.position - transform.position);
			
			hits = Physics2D.RaycastAll(transform.position , Player.transform.position - transform.position);
			
			foreach (RaycastHit2D hit in hits) {
				
				Debug.Log(hit.transform.tag);
				if(hit.transform.tag =="Border")
					break;
				if(hit.transform.tag == "Player")
				{

					FollowPlayer();
				}
			}
		
		}

	}
	void Raycasting(){
	


	
	}
	void FollowPlayer(){

		Vector2 direction = new Vector2 (Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y);
		float rotation = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		this.transform.eulerAngles = new Vector3 (0, 0, rotation);


		if ((Range >= 1f)&& (Range <= 8)) {
			Parent.transform.position = Vector3.MoveTowards (transform.position, Player.transform.position, speed * Time.deltaTime);
		}
		if (Range <= 1f) {
		
			Player.GetComponent<PlayerLogic>().setDamage(4);
			Instantiate (Explosion, new Vector3(transform.position.x, transform.position.y,-0.36F), Quaternion.identity);
			Destroy(Parent);
		
		}
		Range = Vector2.Distance (transform.position, Player.transform.position);
		



	}
	public void setDamage(float damage){
		
		health -= damage;
		enemy = GameObject.FindGameObjectsWithTag("Enemy1");
		// CUANDO VIDA LLEGA A CERO --> DIE()
		if (health <= 0) {

			Instantiate (Explosion, new Vector3(transform.position.x, transform.position.y,-0.36F), Quaternion.identity);
			num= Random.Range(0,100);
			if(num >= 80){
				
				Instantiate (HealthCont, new Vector3(transform.position.x, transform.position.y,-0.36F), Quaternion.identity);
				
			}
			else if(num <= 30){
				Instantiate (Coins, new Vector3(transform.position.x, transform.position.y,-0.36F), Quaternion.identity);
				
			}
			if (enemy.Length == 1) {
				Debug.Log("Solo quedas tuu");
				
				Instantiate (nextLevel, new Vector3(transform.position.x, transform.position.y,0), Quaternion.identity);
				
			}
			Destroy(Enemy);
		}
		
	}
}
