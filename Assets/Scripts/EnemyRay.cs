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
	public Transform Player;

	public GameObject Parent;
	
	public RaycastHit2D[] hits;

	public GameObject[] enemy;
	
	public GameObject nextLevel;
	
	public GameObject Enemy;
	// Update is called once per frame
	void Start(){
	
		Range = Vector2.Distance (transform.position, Player.position);
	
	}

	void Update () {
		Raycasting ();
	}
	void Raycasting(){
	
		Player = GameObject.FindGameObjectWithTag ("Player").transform;
		Debug.DrawRay (transform.position , Player.position - transform.position);
		
		hits = Physics2D.RaycastAll(transform.position , Player.position - transform.position);

		foreach (RaycastHit2D hit in hits) {
		
			Debug.Log(hit.transform.tag);
			if(hit.transform.tag =="Border")
				break;
			if(hit.transform.tag == "Player")
			{
				Debug.Log("te voy a matar");
				FollowPlayer();
			}
		}
	
	}
	void FollowPlayer(){

		Vector2 direction = new Vector2 (Player.position.x - transform.position.x, Player.position.y - transform.position.y);
		float rotation = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		this.transform.eulerAngles = new Vector3 (0, 0, rotation);


		if ((Range >= 1f)&& (Range <= 8)) {
			Parent.transform.position = Vector3.MoveTowards (transform.position, Player.position, speed * Time.deltaTime);
		}
		if (Range <= 1f) {
		
			Player.GetComponent<PlayerLogic>().setDamage(4);
			Destroy(Parent);
		
		}
		Range = Vector2.Distance (transform.position, Player.position);
		



	}
	public void setDamage(float damage){
		
		health -= damage;
		enemy = GameObject.FindGameObjectsWithTag("Enemy1");
		// CUANDO VIDA LLEGA A CERO --> DIE()
		if (health <= 0) {
			
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
