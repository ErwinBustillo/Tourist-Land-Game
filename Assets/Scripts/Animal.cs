using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent (typeof (Animator))]
public class Animal : MonoBehaviour {

	private Animator anim; 

	private NavMeshAgent agent;

	[SerializeField]
	private GameObject [] waypoints;
	private int destPoint = 0;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
		waypoints = GameObject.FindGameObjectsWithTag ("Waypoint");
		agent.autoBraking = false;
		GotoNextPoint ();
	}
	
	// Update is called once per frame
	void Update () {
		//ANIMATOR 
		anim.SetFloat ("Vertical", agent.velocity.z);
		if (Vector3.Distance(transform.position,waypoints[destPoint].transform.position)< 0.5f)
			GotoNextPoint();
	}

	void OnAnimatorMove ()
	{
		// Update position to agent position
		transform.position = agent.nextPosition;
	}

	void GotoNextPoint() {
		// Returns if no points have been set up
		if (waypoints.Length == 0)
			return;

		// Set the agent to go to the currently selected destination.
		agent.SetDestination(waypoints[destPoint].transform.position); 

		// Choose the next point in the array as the destination,
		// cycling to the start if necessary.
		destPoint = (destPoint + 1) % waypoints.Length;
	}


}
