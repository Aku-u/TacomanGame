using UnityEngine;
using System.Collections;
// USAR LIBRERIA NUEVA UI
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// UI GAME OVER
//	public GameObject gameOverUI;
	// UI VICTORY
//	public GameObject victoryUI;
	
	// GAMELOGIC STATES
	public enum GameStates{START,GAME,GAMEOVER,VICTORY,RESTART,PAUSE,GOOD}
	public GameStates state;


	// PLAYER LOGIC
	private PlayerLogic playerLogic;
	
	// NIVEL EN EL QUE ESTAMOS
	private int currentLevel;

	// Use this for initialization
	void Start () {
	
		currentLevel = Application.loadedLevel;
		
		// BUSCO EL PLAYER MEDIANTE EL TAG "Player"
		playerLogic = GameObject.FindGameObjectWithTag ("Player").
			// OBTENGO SU COMPONENTE PlayerLogic
			GetComponent<PlayerLogic> ();
		
		setStart ();
	}
	
	// Update is called once per frame
	void Update () {
		
		switch(state){
		case GameStates.START:
			StartBehaviour();
			break;
			
		case GameStates.GAME:
			GameBehaviour();
			break;
			
		case GameStates.PAUSE:
			PauseBehaviour();
			break;
			
		case GameStates.GAMEOVER:
			GameOverBehaviour();
			break;
			
		case GameStates.RESTART:
			RestartBehaviour();
			break;
			
		case GameStates.VICTORY:
			VictoryBehaviour();
			break;
		case GameStates.GOOD:
			GoodBehaviour();
			break;
			
		}
		
	}
	// BEHAVIOURS
	private void GoodBehaviour(){
		// VAMOS AL ESTADO GAME
		if (Input.GetKeyDown (KeyCode.L)) {
			setGame();
		}
		setGood ();
	}

	private void StartBehaviour(){
		// VAMOS AL ESTADO GAME
		setGame ();
	}
	
	private void GameBehaviour(){
		// SI APRETAMOS LA TECLA P SE PAUSA
		if (Input.GetKeyDown (KeyCode.P)) {
			setPause();
		}

		
	}
	
	private void PauseBehaviour(){
		// SI APRETAMOS LA TECLA P --> RESUME GAME
		if (Input.GetKeyDown (KeyCode.P)) {
			setGame();
		}
		
	}
	
	private void GameOverBehaviour(){
		
		// SI APRETAMOS LA BARRA ESPACIADORA --> RESTART GAME
		if (Input.GetKeyDown (KeyCode.Space)) {
			setRestart();
		}
		
	}
	
	private void VictoryBehaviour(){
		
		// SI APRETAMOS LA BARRA ESPACIADORA --> CARGAMOS EL SIGUIENTE NIVEL
		if (Input.GetKeyDown (KeyCode.Space)) {
			
			if(currentLevel<Application.levelCount-1){
				// CARGA EL SIGUIENTE NIVEL SI HAY MAS ESCENAS
				Application.LoadLevel(currentLevel+1);
			} else {
				// SI NO HAY MAS ESCENAS, CARGAR EL MENU PRINCIPAL
				Application.LoadLevel(1);
			}
			
			
		}
	}
	
	private void RestartBehaviour(){
		
		
	}
	
	// SETS
	public void setStart(){
		// DESACTIVO GAME OVER UI
//		gameOverUI.SetActive (false);
		// DESACTIVO VICTORY UI
//		victoryUI.SetActive (false);
		
		state = GameStates.START;
	}
	
	public void setGame(){
		// EL TIEMPO SE ESTABLECE
		Time.timeScale = 1;
		
		// ACTIVAMOS LOS CONTROLES DEL PLAYER
		playerLogic.ActiveControlPlayer ();
		
		state = GameStates.GAME;
	}
	
	public void setPause(){
		// DESACTIVAMOS LOS CONTROLES DEL PLAYER
		playerLogic.DesActiveControlPlayer ();
		
		// PARAMOS EL TIEMPO
		Time.timeScale = 0;
		
		state = GameStates.PAUSE;
	}
	
	public void setGameOver(){
		// ACTIVAR LA UI GAMEOVER
//		gameOverUI.SetActive(true);
		
		// DESACTIVAMOS LOS CONTROLES DEL PLAYER
		playerLogic.DesActiveControlPlayer ();
		
		state = GameStates.GAMEOVER;
	}
	
	public void setVictory(){
		// ACTIVO VICTORY UI
//		victoryUI.SetActive (true);
		
		// DESACTIVAMOS LOS CONTROLES DEL PLAYER
		playerLogic.DesActiveControlPlayer ();
		
		state = GameStates.VICTORY;
	}
	
	public void setRestart(){
		
		// CARGAMOS DE NUEVO EL NIVEL
		Application.LoadLevel (currentLevel);
		
		state = GameStates.RESTART;
	}
	public void setGood(){
		
		// CARGAMOS DE NUEVO EL NIVEL



		
		state = GameStates.GOOD;
	}


}
