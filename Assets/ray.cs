using UnityEngine;
using System.Collections.Generic;

public class ray : MonoBehaviour {

	public Transform Sourcebullet , Raycaster;

	public RaycastHit2D[] hits;


	public Vector2 enemy;
	public Vector2 other;

	public Vector2 enemy1;

	public Vector2 other1;


	void Update()
	{
		Raycasting ();

	}
	
	void Raycasting(){


		Debug.DrawRay (Sourcebullet.position , Raycaster.position - transform.position );

		hits = Physics2D.RaycastAll(Sourcebullet.position , Raycaster.position - transform.position);



		foreach (RaycastHit2D hit in hits)
		{
			if (hit.transform.tag == "Enemy")
			{

				enemy = hit.transform.position;
			}
			if (hit.transform.tag == "Border")
			{
				
				other = hit.transform.position;

			}
			if((Vector2.Distance(Sourcebullet.position, enemy) <= Vector2.Distance(Sourcebullet.position, other))&&( hit.transform.tag == "Enemy"  )){


				Debug.Log("esta mas cerca");
			}


		}


	}
}