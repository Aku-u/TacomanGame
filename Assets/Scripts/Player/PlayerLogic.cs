using UnityEngine;
using System.Collections;
// USAR LIBRERIA NUEVA UI
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour {
	
	// ESTADOS DEL PLAYER
	public enum PlayerStates {AWAKE, DAMAGE, ACTIVE, DIE, WIN, GOOD}
	public PlayerStates state;
	
	// HEALTH
	public int maxHealth;
	public int health;

	public int scores;
	
	// UI PLAYER
//	public Text textPlayerHealth;
//	public Image imagePlayerDamage;
	
	// TEMPORIZADORES DE ESTADO
	public float tempDamage;
	private float temp;
	
	// CONTROLS PLAYER

	// GAME LOGIC
	public GameManager gameLogic;

	public Image Gameover;
	public Button Restart;
	public Button Quit;
	public Canvas GameOver;
	//
	public Text Vida;

	public Text Score;
	
	// Use this for initialization
	void Start () {
		// OBTENGO LOS CONTROLLERS DE LOS DIFERENTES COMPONENTES

		GameOver.enabled = false;
		Gameover.enabled = false;
		Restart.enabled = false;
		Quit.enabled = false;
		setAwake ();
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
		case PlayerStates.AWAKE:
			AwakeBehaviour();
			break;
		case PlayerStates.ACTIVE:
			ActiveBehaviour();
			break;
		case PlayerStates.DAMAGE:
			DamageBehaviour();
			break;
		case PlayerStates.DIE:
			DieBehaviour();
			break;
		case PlayerStates.WIN:
			WinBehaviour();
			break;
		case PlayerStates.GOOD:
			GoodBehaviour();
			break;
		}
	}

	// BEHAVIOURS
	private void WinBehaviour(){
		
	}
	private void GoodBehaviour (){


	}
	
	private void AwakeBehaviour(){
		// INICIALIZO Y DESPUES AL ESTADO ACTIVE
		setActive ();
	}
	
	private void ActiveBehaviour(){
		
	}
	
	private void DamageBehaviour(){
		
		// TEMPORIZADOR HACIA ATRAS
		temp -= Time.deltaTime;
		
		if (temp <= 0) {
			setActive();
		}
		
	}
	
	private void DieBehaviour(){

		
	}
	// SETS
	public void setAwake(){
		// Activamos los controles del player
		ActiveControlPlayer ();
		
		health = maxHealth;

		Vida.text = health.ToString ();
		// EL TEXTO DEL INTERFAZ, SE PASA HEALTH (INT) A STRING UTILIZANDO
		// ToString()
		//		textPlayerHealth.text = health.ToString ();
		
		// DESACTIVAR IMAGEN DE DAÑO
//		imagePlayerDamage.enabled = false;
		
		state = PlayerStates.AWAKE;
	}
	
	public void setActive(){
		// DESACTIVAR IMAGEN DE DAÑO
//		imagePlayerDamage.enabled = false;
		Vida.text = health.ToString ();
		state = PlayerStates.ACTIVE;
	}
	
	public void setDamage(float damage){
		// PARA QUITARLE VIDA EL DAMAGE SE PASA A INT
		health -= int.Parse (
			// SE TIENE QUE CONVERTIR ANTES A STRING
			damage.ToString ());
		
		// INICIALIZAR EL TEMPORIZADOR
		temp = tempDamage;
		Vida.text = health.ToString ();
		if (health <= 0) {
			Gameover.enabled = true;
			Restart.enabled = true;
			Quit.enabled = true;
			GameOver.enabled = true;
			setDie ();
		} else {
			state = PlayerStates.DAMAGE;
		}
	}
	public void setLife(float life){
		// PARA QUITARLE VIDA EL DAMAGE SE PASA A INT
		health += int.Parse (
			// SE TIENE QUE CONVERTIR ANTES A STRING
			life.ToString ());
		
		// INICIALIZAR EL TEMPORIZADOR

		Vida.text = health.ToString ();

	}
	public void setPoints(float points){
		// PARA QUITARLE VIDA EL DAMAGE SE PASA A INT
		scores += int.Parse (
			// SE TIENE QUE CONVERTIR ANTES A STRING
			points.ToString ());
		
		// INICIALIZAR EL TEMPORIZADOR
		
		Score.text = scores.ToString ();
		
	}
	
	public void setDie(){
		
		// Desactivamos los controles del player
		DesActiveControlPlayer ();

		// VIDA A CERO
		health = 0;
		Vida.text = health.ToString ();
		// EL TEXTO DEL INTERFAZ, SE PASA HEALTH (INT) A STRING UTILIZANDO
		// ToString()
		//		textPlayerHealth.text = "";
		Gameover.enabled = true;
		// LLAMAMOS A GAMEOVER EN GAMELOGIC
		gameLogic.setGameOver ();
		
		state = PlayerStates.DIE;
	}
	
	public void setWin(){
		
		// Desactivamos los controles del player
		DesActiveControlPlayer ();
		
		// VIDA A CERO
		health = 0;
		// EL TEXTO DEL INTERFAZ, SE PASA HEALTH (INT) A STRING UTILIZANDO
		// ToString()
		//textPlayerHealth.text = "";
		
		// LLAMAMOS A VICTORY EN GAMELOGIC
		gameLogic.setVictory ();
		
		state = PlayerStates.WIN;
	}
	public void setGood(){
		
		// Desactivamos los controles del player

	
		//health = 1000000;
		// EL TEXTO DEL INTERFAZ, SE PASA HEALTH (INT) A STRING UTILIZANDO
		// ToString()
		//textPlayerHealth.text = "";
		
		// LLAMAMOS A VICTORY EN GAMELOGIC
		gameLogic.setGood ();
		
		state = PlayerStates.GOOD;
	}
	// ACTIVAMOS LOS CONTROLES DEL JUGADOR
	public void ActiveControlPlayer(){
		// RECORRO EL ARRAY DE MouseLookAdavance y habilito cada componente

		

	}
	
	// DESACTIVAMOS LOS CONTROLES DEL JUGADOR
	public void DesActiveControlPlayer(){
		// RECORRO EL ARRAY DE MouseLookAdavance y deshabilito cada componente

	}
}
