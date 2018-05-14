using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
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
	
	// Update is called once per frame
	void Update () {
		//Aqui se maneja lo de las preguntas

	}
}
