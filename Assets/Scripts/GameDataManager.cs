using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDataManager : MonoBehaviour {

	public static GameDataManager singleton;

	public GameObject jail;
	// Use this for initialization
	void Start () {
		
		singleton = this;

		if (PlayerPrefs.HasKey("characterSelected")) {
			//Debug.Log ("SI EXISTE LA LLAVE");
			Transform t = GameObject.Find ("StartPoint").transform;
			GameObject go = Instantiate (Resources.Load<GameObject> (PlayerPrefs.GetString("characterSelected","Ezequiel")),t.position,t.rotation);
			go.GetComponent<vThirdPersonInput> ().enabled = true;
			go.AddComponent<Health> ();
			go.AddComponent<Hungry> ();

		} else {
			//Debug.Log ("NO EXISTE LA LLAVE");
		}
	}



	public void LoadNextScene(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void LoadMainMenu(){
		SceneManager.LoadScene (0);
	}

	public void ReloadLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void DisableJail(){
		jail.SetActive (false);
	}

}
