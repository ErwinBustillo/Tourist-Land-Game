using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
[RequireComponent (typeof (Animator))]
public class Npc : MonoBehaviour {

	public enum STATES
	{
		idle, 
		walking,
	}

	public STATES defaultState;
	Animator anim;
	NavMeshAgent agent;

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
		agent.updatePosition = false;

		waypoints = GameObject.FindGameObjectsWithTag ("Waypoint");
		//agent.autoBraking = false;
		GotoNextPoint ();
	}

	void Update () {
		// Choose the next destination point when the agent gets
		// close to the current one.
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

		bool shouldMove = velocity.magnitude > 0.5f && agent.remainingDistance > agent.radius;

		// Update animation parameters
		//anim.SetBool("move", shouldMove);
		anim.SetFloat ("InputHorizontal", velocity.x);
		anim.SetFloat ("InputVertical", velocity.y);


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
		agent.destination = waypoints[destPoint].transform.position;

		// Choose the next point in the array as the destination,
		// cycling to the start if necessary.
		destPoint = (destPoint + 1) % waypoints.Length;
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
