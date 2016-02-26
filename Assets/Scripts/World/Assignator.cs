using UnityEngine;
using System.Collections;

public class Assignator : MonoBehaviour {

	public float Num;

	public GameObject Enemy;

	public GameObject Cactus;

	public GameObject Chest;

	public GameObject player;

	public float distance;
	// Use this for initialization
	void Start () {
		Num = Random.Range (1, 100);
		
		Debug.Log(Num);
		distance =Vector2.Distance(transform.position,player.transform.position);
		if (distance >= 7.5) {
				
			if (Num <= NextLevel.levelDificulty-2) {

					Instantiate (Enemy, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
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
