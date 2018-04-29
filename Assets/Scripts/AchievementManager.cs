using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour {


	public string key1="";
	public string key2="";
	public string key3="";
	public string key4="";
	public string key5="";



	// limpia todas las llaves
	public void ResetAllProgress(){
		PlayerPrefs.DeleteAll ();
	}

	// guarda el estado del logro 
	public void SaveKey(string key,int value){
		if (!PlayerPrefs.HasKey(key)) {
			PlayerPrefs.SetInt (key, value);
			PlayerPrefs.Save ();
		}
	}
}
