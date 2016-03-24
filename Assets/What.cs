using UnityEngine;
using System.Collections;

public class What : MonoBehaviour {


	public BorderAsig border;


	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
	

	}
	void OnTriggerStay2D(Collider2D other){

		
		// SI NO ES TAG DETECTION, REALIZA LA COLISION
		if (other.tag == "Ground") {
			

			// LA EXPLOSION SE DESTRUYE A LOS 0.5SEG

			if(this.gameObject.name == "Up")border.Up = true;
			if(this.gameObject.name == "Down")border.Down = true;
			if(this.gameObject.name == "Left")border.Left = true;
			if(this.gameObject.name == "Right")border.Right = true;
		}

	}
}
