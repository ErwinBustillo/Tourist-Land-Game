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


	public void OnClickButtonBuy(){
		//Descontar la plata del jugador
	}
}
