/// Ant-Based Modeling
/// 
/// Developed and Designed by Poseidon Ho at MIT Media Lab 
/// 
/// Script allows for simulating completely random agent movement using NavMesh
/// 

using UnityEngine;
using System.Collections;

public class AgentNavMesh : MonoBehaviour 
{
	
	public Transform destination;
	
	private NavMeshAgent agent;

	bool walking = false;
	bool run = false;
	bool idle = true;
	bool sit = false;
	bool wave = false;
	
	void Start () 
	{
		agent = gameObject.GetComponent<NavMeshAgent>();
		agent.SetDestination(destination.position);
	}

	Vector3 direction;


	Vector3 getRandomPoint(){

		float walkRadius = 400.0f;

		Vector3 randomDirection = Random.insideUnitSphere * walkRadius;

		randomDirection += transform.position;
		NavMeshHit hit;
		NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
		Vector3 finalPosition = hit.position;

		return finalPosition;
	}



	Vector3 getRandomPointOffMesh(){
			
		// 470 is the bounds of the city walking area
		Vector3 finalPosition = new Vector3(Random.Range(0.0f, 470.0f),0,Random.Range(0.0f, 470.0f));
		
		return finalPosition;
	}




	float turnTimer = 4.0f;

	void Update(){

		turnTimer = turnTimer - Time.deltaTime;
		
		if (turnTimer < 0) {
			agent.SetDestination(getRandomPoint());

			turnTimer = System.Convert.ToSingle( Random.Range(4.0f, 20.0f));  
		}

		//Debug.Log (turnTimer);




		foreach (Transform child in gameObject.transform)
		{
			Animator animator = child.gameObject.GetComponent<Animator>();

			if(animator == null)
			{
				//abandon all hope
			}
			else
			{


			//	Debug.Log(agent.velocity.magnitude);


				if (agent.velocity.magnitude < 0.7f && !idle ) {
					 walking = false;
					 run = false;
					 idle = true;
					 sit = false;
					 wave = false;
					animator.SetTrigger("StopWalking");
					animator.SetBool("isIdle",true);
					animator.SetBool("isWalking",false);
					animator.SetBool("isRunning",false);

					
				//	Debug.Log(agent.velocity.magnitude);
				//	Debug.Log("IDLE");


				}
				
				if (agent.velocity.magnitude > 0.7f && agent.velocity.magnitude < 6.5f && !walking) {
					 walking = true;
					 run = false;
					 idle = false;
					 sit = false;
					 wave = false;
					animator.SetTrigger("StartWalking");
					animator.SetBool("isIdle",false);
					animator.SetBool("isWalking",true);
					animator.SetBool("isRunning",false);

				//	Debug.Log(agent.velocity.magnitude);
				//	Debug.Log("WALKING");
					
				}
				
				if (agent.velocity.magnitude > 6.8f && ! run) {
					 walking = false;
					 run = true;
					 idle = false;
					 sit = false;
					 wave = false;
					animator.SetTrigger("StartRunning");
						animator.SetBool("isRunning",true);
					animator.SetBool("isIdle",false);
					animator.SetBool("isWalking",false);

				//	Debug.Log(agent.velocity.magnitude);
				//	Debug.Log("RUNNING");
					
				}

			}


		}

	
	

	}
	
}