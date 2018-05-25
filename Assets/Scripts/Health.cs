using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	[SerializeField]
	private float fillAmount; 

	public Image healthBar;

	public int maxHealth = 100; 
	private int currentHealth;

	public static Health singleton;
	// Use this for initialization
	void Start () {
		singleton = this;
		healthBar = GameObject.FindWithTag ("Health").GetComponent<Image>();
		currentHealth = maxHealth; 
		fillAmount = (float)currentHealth / maxHealth;
		handleBar ();
	}
	


	public void TakeDamage(int amount){

		if (Hungry.singleton.currentHungry >= 100) {
			currentHealth -= amount;
			fillAmount = (float)currentHealth / maxHealth;
			handleBar ();
		}

		if (currentHealth <=0) {
			Destroy (gameObject);
			GameDataManager.singleton.ReloadLevel ();
		}

	}

	public void AddLife(int amount) {


		if (currentHealth >= 100 )
		{
			currentHealth = maxHealth;
		}
		else {
			if (Hungry.singleton.currentHungry <= 100) {
				currentHealth += amount;
			}

		}
		fillAmount = (float)currentHealth / maxHealth;
		handleBar ();
	}



	void handleBar(){
		healthBar.fillAmount = fillAmount;
	}
}
