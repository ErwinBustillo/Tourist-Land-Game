using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public enum ITEM_TYPE{
		Food, 
		Drink,
		Object
	}

	public ITEM_TYPE itemType;

	public string Name; 

	public int Price;


	void Start(){
		if (itemType == ITEM_TYPE.Food) {
			Name = gameObject.name;
			Price = 0;
		}
	}
	public void OnClickButtonBuy(){
		//Descontar la plata del jugador
	}
}
