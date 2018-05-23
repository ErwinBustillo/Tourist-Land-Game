using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hungry : MonoBehaviour {

	[SerializeField]
	private float fillAmount; 

	public Image hungryBar;

	public int maxHungry = 100; 
	[HideInInspector]
	public int currentHungry;

	public float delay = 5f; 
	private float currentDelay = 0;

	public static Hungry singleton;


	// Use this for initialization
	void Start () {
		singleton = this;

		hungryBar = GameObject.FindWithTag ("Hungry").GetComponent<Image>();
		currentHungry = 10;
		fillAmount = (float)currentHungry / maxHungry;
		handleBar ();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentDelay < delay) {
			//Debug.Log ("current del: "+ currentDelay);
			currentDelay += Time.deltaTime;
		} else {
			//Debug.Log ("TIME OUT");
			currentDelay = 0;
			if (currentHungry <= maxHungry) {
				currentHungry += 5;
				fillAmount = (float)currentHungry / maxHungry;
				handleBar ();
			} else {
				Health.singleton.TakeDamage (5);
				currentHungry = maxHungry;
			}

		}
	}

	public void SubstractHungry(int amount){
		currentHungry -= amount;
		fillAmount = (float)currentHungry / maxHungry;
		handleBar ();
	}

	void handleBar(){
		hungryBar.fillAmount = fillAmount;
	}
}
