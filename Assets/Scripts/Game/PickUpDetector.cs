using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpDetector : MonoBehaviour {


	public int healthRecoverValue = 0;
	public int hungryRecoverValue = 0;
	// si entra el player en contacto con el objeto
	void OnTriggerEnter(Collider other){
		//Muestre un texto diciendole al jugador que lo puede recoger dependiendo del tipo de objeto
		
		GameUIManager.Instance.Brand.transform.Find("Text").GetComponent<Text>().text = "PRESS X TO PICKUP ITEMS";
		//Debug.Log("ENTRO " +other.gameObject.name);
	}

	void OnTriggerStay(Collider other){

		if (Input.GetKeyDown(KeyCode.X)) {
			FindObjectOfType<Hungry> ().SubstractHungry (hungryRecoverValue);
			FindObjectOfType<Health> ().AddLife (healthRecoverValue);
			Destroy (gameObject);
			GameUIManager.Instance.Brand.SetActive (false);
		}
	}

	void OnTriggerExit(Collider other){
		GameUIManager.Instance.Brand.transform.Find("Text").GetComponent<Text>().text = "";
		GameUIManager.Instance.Brand.SetActive (false);
		//Debug.Log("SALIO" + other.gameObject.name);
	}

}
