using UnityEngine;
using System.Collections;

public class Assignator : MonoBehaviour {

	public float Num;

	public GameObject Enemy;
	public GameObject Enemy2;

	public GameObject Cactus;

	public GameObject Chest;

	public GameObject player;

	public float distance;
	// Use this for initialization
	void Start () {
		Num = Random.Range (1, 100);
		
		Debug.Log(Num);
		distance =Vector2.Distance(transform.position,Vector2.zero);
		if (distance >= 7.5) {
				
			if (Num <= NextLevel.levelDificulty-2) {

				Num = Random.Range (1, 3);
				if(Num == 1)	Instantiate (Enemy, new Vector3 (transform.position.x, transform.position.y, -0.36f), Quaternion.identity);
				if(Num == 2)	Instantiate (Enemy2, new Vector3 (transform.position.x, transform.position.y, -0.36f), Quaternion.identity);
			}
		}
		if (Num >= 95)
		{
			
			Instantiate (Cactus, new Vector3(transform.position.x, transform.position.y,-1.0f), Quaternion.identity);
		}



	}
	
	// Update is called once per frame
	void Update () {


		if (NextLevel.Chests >= 0) {
			
			if ((Num == 88)||(Num == 89) ||(Num == 90)){
				
				Instantiate (Chest, new Vector3(transform.position.x, transform.position.y,-1.0f), Quaternion.identity);
				NextLevel.Chests --;
			}
			
		}
	
	}
}
