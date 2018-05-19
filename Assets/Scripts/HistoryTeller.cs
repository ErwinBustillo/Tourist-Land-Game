using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HistoryTeller : MonoBehaviour {

	//TODO hacerla mas interezante
	public GameObject [] panelesDeHistoria; // aqui se almacena todo el relato por paneles

	int index = 0; 

	//private Score ScoreManager;
	private AudioManager audioManager;

	void Awake(){
		//ScoreManager = GameObject.FindObjectOfType<Score> () ;
		audioManager = GameObject.FindObjectOfType<AudioManager> ();
	}

	// Use this for initialization
	void Start () {		
		panelesDeHistoria [index].SetActive (true);
	}

	//activa el panel siguiente de texto desde el panel actual
	public void OnClickNext(){
		panelesDeHistoria [index].SetActive (false);
		index += 1;
		panelesDeHistoria [index].SetActive (true);
	}


	public void OnClickGoBackToMainMenu(){
		/*Destroy (ScoreManager.gameObject);
		Destroy (audioManager.gameObject);
		SceneManager.LoadScene (0);*/
	}

	//arranca el juego 
	public void OnClickStartGame(){
		//DontDestroyOnLoad (ScoreManager.gameObject);
		//DontDestroyOnLoad (audioManager.gameObject);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex +1);
	}

	//avanza hacia la proxima escena
	public void OnClickContinue(){
		//DontDestroyOnLoad (ScoreManager.gameObject);
		//DontDestroyOnLoad (audioManager.gameObject);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	//recarga el mainmenu cuando esta en la ultima scena
	public void onClickFinishedHistory(){
		//Destroy (ScoreManager.gameObject);
		//Destroy (audioManager.gameObject);
		SceneManager.LoadScene (0);
	}
}
