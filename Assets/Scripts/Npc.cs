using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
[RequireComponent (typeof (Animator))]
public class Npc : MonoBehaviour {


	Animator anim;
	[HideInInspector]
	public NavMeshAgent agent;

	[HideInInspector]
	public bool isMoving; 

	Vector2 smoothDeltaPosition = Vector2.zero;
	Vector2 velocity = Vector2.zero;


	[SerializeField]
	private GameObject[] waypoints;
	public int destPoint = 0;

	void Start ()
	{
		anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
		// Don’t update position automatically
		isMoving = true;
		agent.updatePosition = false;

		waypoints = GameObject.FindGameObjectsWithTag ("Waypoint");
		anim.SetBool ("IsMoving", true);
		destPoint = Random.Range (0, waypoints.Length);
		GotoNextPoint ();
	}

	void Update () {
		// Choose the next destination point when the agent gets
		// close to the current one.

		if (!isMoving) {
			anim.SetFloat ("Horizontal", 0);
			anim.SetFloat ("Vertical", 0);
			anim.SetBool ("IsMoving", false);
		} else {
			Vector3 worldDeltaPosition = agent.nextPosition - transform.position;

			// Map 'worldDeltaPosition' to local space
			float dx = Vector3.Dot (transform.right, worldDeltaPosition);
			float dy = Vector3.Dot (transform.forward, worldDeltaPosition);
			Vector2 deltaPosition = new Vector2 (dx, dy);

			// Low-pass filter the deltaMove
			float smooth = Mathf.Min(1.0f, Time.deltaTime/0.15f);
			smoothDeltaPosition = Vector2.Lerp (smoothDeltaPosition, deltaPosition, smooth);

			// Update velocity if time advances
			if (Time.deltaTime > 1e-5f)
				velocity = smoothDeltaPosition / Time.deltaTime;

			anim.SetFloat ("Horizontal", velocity.x);
			anim.SetFloat ("Vertical", velocity.y);
			anim.SetBool ("IsMoving", true);
			if (agent.remainingDistance < 0.5f)
				GotoNextPoint();
		}
	

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
		agent.destination = waypoints[destPoint].transform.position;

		// Choose the next point in the array as the destination,
		// cycling to the start if necessary.
		destPoint = (destPoint + 1) % waypoints.Length;
	}


	// TODO: CONDICIONAR AL NPC PARA QUE CUANDO VEA AL PLAYER DEJE DE PATRULLAR Y LO MIRE(lookat)
	void OnTriggerEnter(Collider other){
		
		if (other.gameObject.tag == "Player") {
			agent.isStopped = true;
			isMoving = false;
		
			transform.LookAt (other.gameObject.transform);
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			agent.isStopped = false;
			isMoving = true;

		}
	}

}
