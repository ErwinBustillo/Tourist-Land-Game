﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpDetector : MonoBehaviour {


	public GameObject Brand; 

	void Start(){
		Brand = GameObject.FindGameObjectWithTag ("Brand");
	}
	// si entra el player en contacto con el objeto
	void OnTriggerEnter(Collider other){
		//Muestre un texto diciendole al jugador que lo puede recoger dependiendo del tipo de objeto
		if (Brand.activeInHierarchy == false) {
			Brand.SetActive (true);
		}
		Brand.transform.Find("Text").GetComponent<Text>().text = "PRESS X TO PICKUP ITEMS";
		//Debug.Log("ENTRO " +other.gameObject.name);
	}

	void OnTriggerStay(Collider other){
		if (Input.GetKeyDown(KeyCode.X)) {
			Destroy (gameObject);
			Brand.SetActive (false);
		}
	}

	void OnTriggerExit(Collider other){
		
		Brand.SetActive (false);
		//Debug.Log("SALIO" + other.gameObject.name);
	}

}
