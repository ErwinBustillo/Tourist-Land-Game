using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Npc : MonoBehaviour {

	public enum STATES
	{
		idle, 
		walking,
	}

	public STATES defaultState;
	public Collider visorCollider;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			defaultState = STATES.idle;
			transform.LookAt (other.gameObject.transform);
		}
	}


	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			defaultState = STATES.walking;
		}
	}

}
