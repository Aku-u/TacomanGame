using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ImageHealth : MonoBehaviour {

	public Sprite[] Life;

	public Image ImageVida;


	public int life;
	// Use this for initialization
	void Start () {
	
		life = 10;

	}
	
	// Update is called once per frame
	void Update () {
	

		

		
		}
	
	public void SetImage(int vida){
		if (vida >= 0) {
			life = vida;

			ImageVida.sprite = Life [vida];	
		
		
		}


	}
}
