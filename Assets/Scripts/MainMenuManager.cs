using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour {

	public GameObject panelMain; 
	public GameObject panelCharacterSelector;
	public GameObject panelShop;

	// Use this for initialization
	void Start () {
		panelMain.SetActive (true);
		panelCharacterSelector.SetActive (false);
		panelShop.SetActive (false);
	}



	public void OnClickButtonPanelCharacterSelector(){
		panelMain.SetActive (false);
		panelCharacterSelector.SetActive (true);
		FindObjectOfType<CharacterSelector> ().enabled = true;

	}

    public void OnClickButtonPanelShop() {
		panelMain.SetActive (false);
		panelShop.SetActive (true);
	}

	public void OnClickButtonPanelExit(){
        print("Click on exit");
        Application.Quit ();
	}

	public void OnClickExitPanelCharacterSelector(){
		FindObjectOfType<CharacterSelector> ().enabled = false;
		panelCharacterSelector.SetActive (false);
		panelMain.SetActive (true);
	}

	public void OnClickExitPanelShop(){
		panelShop.SetActive (false);
		panelMain.SetActive (true);
	}
}
