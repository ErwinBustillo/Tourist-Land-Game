using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour {


	private GameObject[] characters;

	int index = 0;

	// Use this for initialization
	void Start () {

		characters = new GameObject[transform.childCount];

		for (int i = 0; i < characters.Length; i++) {
			characters [i] = transform.GetChild (i).gameObject;
		}

		foreach (GameObject chara in characters) {
			chara.SetActive (false);
		}

		if (characters[0]) {
			characters [0].SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void OnClickBack(){
		characters [index].SetActive (false);
		index--;
		if (index < 0) {
			index = characters.Length - 1; 
		}
		characters [index].SetActive (true);
	}

	public void OnClickNext(){
		characters [index].SetActive (false);
		index++;
		if (index  == characters.Length) {
			index = 0; 
		}
		characters [index].SetActive (true);
	}


	public void OnClickButtonConfirm(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

}
