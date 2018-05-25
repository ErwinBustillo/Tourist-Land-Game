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


	void Awake(){
		
		anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
		waypoints = GameObject.FindGameObjectsWithTag ("Waypoint");
	}


	// Use this for initialization
	void Start () {
		//agent.updatePosition = true;
		//agent.autoBraking = false;
		destPoint = Random.Range (0, waypoints.Length);
		GotoNextPoint ();
	}
	
	// Update is called once per frame
	void Update () {

		anim.SetFloat ("Vertical", agent.velocity.normalized.magnitude);

		if (agent.remainingDistance < 0.5f)
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
		//agent.SetDestination(waypoints[destPoint].transform.position);
		agent.destination = waypoints [destPoint].transform.position;

		// Choose the next point in the array as the destination,
		// cycling to the start if necessary.
		int nextPoint;
		do {
			nextPoint = Random.Range(0, waypoints.Length);
		} while (nextPoint == destPoint);
		destPoint = nextPoint;
	}


}
