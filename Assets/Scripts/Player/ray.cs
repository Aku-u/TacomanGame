using UnityEngine;
using System.Collections.Generic;

public class ray : MonoBehaviour {

	public Transform Sourcebullet , Raycaster;

	public RaycastHit2D[] hits;


	private bool detection1;

	public bool Spooted;

	public int counter;
	public int counter2;
	public GameObject enemyG;

	public Vector2 enemy;
	public Vector2 other;

	public Vector2 enemy1;

	public Vector2 other1;


	void Update()
	{
		Raycasting ();



	}

	public void Now(){
	

		Spooted = true;
	
	}
	public void AdDamage(){
	
		Debug.Log("Tocado");
		Destroy (enemyG);


	
	}
	void Raycasting(){


		Debug.DrawRay (Sourcebullet.position , Raycaster.position - transform.position);

		hits = Physics2D.RaycastAll(Sourcebullet.position , Raycaster.position - transform.position,Mathf.Infinity);



		foreach (RaycastHit2D hit in hits)
		{
			if (hit.transform.tag == "Enemy")
			{

				enemy = hit.transform.position;


			}
			if (hit.transform.tag == "EnemyRay")
			{
				
				enemy = hit.transform.position;
				
				
			}
			if (hit.transform.tag == "Border")
			{
				
				other = hit.transform.position;

			}
			/*if(hit.transform.tag =="Detection"){

				Debug.Log("Collsiion");
				foreach (RaycastHit2D hit2 in hits)
				{


					if((Vector2.Distance(Sourcebullet.position, enemy) <= Vector2.Distance(Sourcebullet.position, other))&&(hit2.transform.tag == "Enemy")){


						Debug.Log ("Now");

						counter++;

						Spooted = true;

						//Now ();

					}

				}


			}
*/
			if(Spooted &&(hit.transform.tag == "Detection")){


					Spooted = false;


			}
			if((Vector2.Distance(Sourcebullet.position, enemy) <= Vector2.Distance(Sourcebullet.position, other))&&(hit.transform.tag == "Enemy")){

				enemyG = hit.transform.parent.gameObject;

				Spooted = true;

				Debug.Log("esta mas cerca");
			
			}
			if((Vector2.Distance(Sourcebullet.position, enemy) <= Vector2.Distance(Sourcebullet.position, other))&&(hit.transform.tag == "EnemyRay")){
				
				enemyG = hit.transform.parent.gameObject;
				
				Spooted = true;
				
				Debug.Log("esta mas cerca");
				
			}



		}


	}
}