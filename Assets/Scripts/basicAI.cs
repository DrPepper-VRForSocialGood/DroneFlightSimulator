using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	public class basicAI : MonoBehaviour {

		public UnityEngine.AI.NavMeshAgent agent;
		public ThirdPersonCharacter character;

		public enum State{
			PATROL,
			CHASE
		}

		public State state;
		private bool alive;

		// Variables for Patrolling
		public GameObject[] waypoints;
		private int waypointInd = 0;
		public float patrolSpeed = 0.5f;

		//Variables for Chase
		public float chaseSpeed = 1f;
		public GameObject target;

		// Use this for initialization
		void Start () {
			agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
			character = GetComponent<ThirdPersonCharacter> ();

			agent.updatePosition = true;
			agent.updateRotation = false;

			state = basicAI.State.PATROL;

			alive = true;

			//STAR Finate State Machine
			StartCoroutine("FSM");
		}

		IEnumerator FSM()
		{
			while (alive) 
			{
				switch (state) 
				{
				case State.PATROL:
					Patrol ();
					break;
				case State.CHASE:
					Chase ();
					break;
				}
				yield return null;
			}
		}

		void Patrol()
		{
			agent.speed = patrolSpeed;
				if (Vector3.Distance (this.transform.position, waypoints[waypointInd].transform.position) >= 2)
				{
					agent.SetDestination(waypoints[waypointInd].transform.position);
					character.Move(agent.desiredVelocity, false,false);
					

				}
				else if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) <= 2)
				{
					waypointInd +=1;
					if(waypointInd >= waypoints.Length)
					{
						waypointInd = 0;
					}
				}
				else
				{
					character.Move(Vector3.zero, false, false);
				}
		}
		void Chase()
		{
			agent.speed = chaseSpeed;
			agent.SetDestination (target.transform.position);
			character.Move (agent.desiredVelocity, false, false);
		}

		void OnTriggerEnter (Collider coll)
		{
			if (coll.tag == "Player")
			{
				state = basicAI.State.CHASE;
				target = coll.gameObject;
			}
			
		}
	}
}
