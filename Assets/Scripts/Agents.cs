/// Ant-Based Modeling
/// 
/// Developed and Designed by Poseidon Ho at MIT Media Lab 
/// 
/// Script allows for following and tracking of select agents in a model
/// 


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Net;


public class Agents : MonoBehaviour {

	GameObject AgentCam ;
	RaycastHit hit;

	public bool selectAgent = false;

	bool AgentCamActive = false;

	public bool thirdPerson = false;

	float camOffset = 0.18f;

//	public UILabel followAgent;

	public int numberOfAgents = 50;
	public float agentScale = 0.9f;

	public void setSelectAgent() {
		print("Turn selectAgent on-off");
		if (AgentCamActive) {
			AgentCam.GetComponent<Camera> ().enabled = false;
			AgentCamActive = false;

			selectAgent = false;
//			followAgent.text = "Follow Agent";
		}else if (selectAgent) {
				selectAgent = false;
//				followAgent.text = "Follow Agent";
			} else {
				selectAgent = true;
//				followAgent.text = "Stop Following";
		}
	}

	public void setThirdPerson() {
		print("Turn 3rdPerson on-off");
		
		if (thirdPerson) {
			thirdPerson = false;
		} else {
			thirdPerson = true;
		}
	}


	// Use this for initialization
	void Start () {
		AgentCam = GameObject.Find ("AgentCamera");



		for (int i = 0; i< numberOfAgents; i++) {


			//Rank the Calculate percentages between 0 and 100

			List<int> AgentIDs = new List<int>();


			int ManBlack = 70;
			int ManWhite = 70;
			int StreetBlack = 10;
			int StreetWhite = 10;
			int WomanBlack = 40;
			int WomanWhite = 40;
			int ManBrown = 40;
			int DoctorWhite = 3;
			int DoctorBlack = 3;
			int DoctorBrown = 3;


			int ManBlackID = 1;
			int ManWhiteID = 2;
			int StreetBlackID = 3;
			int StreetWhiteID = 4;
			int WomanBlackID = 5;
			int WomanWhiteID = 6;
			int ManBrownID = 7;
			int DoctorWhiteID = 8;
			int DoctorBlackID = 9;
			int DoctorBrownID = 10;


			for(int j = 0; j < ManBlack; j++){
				AgentIDs.Add(ManBlackID);
			}
			for(int j = 0; j < ManWhite; j++){
				AgentIDs.Add(ManWhiteID);
			}
			for(int j = 0; j < StreetBlack; j++){
				AgentIDs.Add(StreetBlackID);
			}
			for(int j = 0; j < StreetWhite; j++){
				AgentIDs.Add(StreetWhiteID);
			}
			for(int j = 0; j < WomanBlack; j++){
				AgentIDs.Add(WomanBlackID);
			}
			for(int j = 0; j < WomanWhite; j++){
				AgentIDs.Add(WomanWhiteID);
			}
			for(int j = 0; j < ManBrown; j++){
				AgentIDs.Add(ManBrownID);
			}
			for(int j = 0; j < DoctorWhite; j++){
				AgentIDs.Add(DoctorWhiteID);
			}
			for(int j = 0; j < DoctorBlack; j++){
				AgentIDs.Add(DoctorBlackID);
			}
			for(int j = 0; j < DoctorBrown; j++){
				AgentIDs.Add(DoctorBrownID);
			}


			int randomPick = (int)UnityEngine.Random.Range(0, AgentIDs.Count-1);
			Debug.Log("Create Agent: " + randomPick);
			randomPick = AgentIDs[randomPick];

			GameObject newAgent =  new GameObject();

			switch (randomPick)
			{
			case 1:
				 newAgent = Instantiate(GameObject.Find ("CSAgentSubjectBusinessManBlack"));
				break;
			case 2:
				newAgent = Instantiate(GameObject.Find ("CSAgentSubjectBusinessManWhite"));
				break;
			case 3:
				newAgent = Instantiate(GameObject.Find ("CSAgentSubjectStreetWhite"));
				break;
			case 4:
				newAgent = Instantiate(GameObject.Find ("CSAgentSubjectStreetBlack"));
				break;
			case 5:
				newAgent = Instantiate(GameObject.Find ("CSAgentSubjectWomanBlack"));
				break;
			case 6:
				newAgent = Instantiate(GameObject.Find ("CSAgentSubjectWomanWhite"));
				break;
			case 7:
				newAgent = Instantiate(GameObject.Find ("CSAgentSubjectBusinessManBrown"));
				break;
			case 8:
				newAgent = Instantiate(GameObject.Find ("CSAgentSubjectDoctorWhite"));
				break;
			case 9:
				newAgent = Instantiate(GameObject.Find ("CSAgentSubjectDoctorBlack"));
				break;
			case 10:
				newAgent = Instantiate(GameObject.Find ("CSAgentSubjectDoctorBrown"));
				break;
			default:
				Console.WriteLine("Default case");
				break;
			}

			newAgent.transform.localScale = new Vector3 (-agentScale, -agentScale, -agentScale);

			foreach (Transform child in newAgent.transform)
			{
				NavMeshAgent navMesh = child.gameObject.GetComponent<NavMeshAgent>();
				
				if(navMesh == null)
				{
					//abandon all hope
				}
				else
				{
					navMesh.radius = agentScale;

				}
			}

		}


		//Hide AgentType Holder

		GameObject agentTypeHolder = GameObject.Find ("AgentTypes");
		Destroy (agentTypeHolder);



	}




	// Update is called once per frame
	void Update () {


		if (AgentCamActive) {

			if(thirdPerson){

				Vector3 tempV = new Vector3(hit.transform.position.x - 4.2f,hit.transform.position.y+5.09f,hit.transform.position.z);
				AgentCam.GetComponent<Camera> ().transform.position = tempV;

				Vector3 tempHitPosition =  new Vector3(hit.transform.position.x,hit.transform.position.y+3.11f,hit.transform.position.z);


				Vector3 relativePos = tempHitPosition - tempV;
				
				Quaternion rotation = Quaternion.LookRotation(relativePos);
				
				AgentCam.GetComponent<Camera> ().transform.rotation = rotation;
				AgentCam.GetComponent<Camera> ().transform.RotateAround (tempHitPosition, Vector3.up, hit.transform.rotation.eulerAngles.y-90.0f);

				
			}else{


				Vector3 tempV = new Vector3(hit.transform.position.x - camOffset,hit.transform.position.y+30.0f,hit.transform.position.z);
				AgentCam.GetComponent<Camera> ().transform.position = tempV;

				Vector3 relativePos = hit.transform.position - tempV;

				Quaternion rotation = Quaternion.LookRotation(relativePos);

				AgentCam.GetComponent<Camera> ().transform.rotation = rotation;
				AgentCam.GetComponent<Camera> ().transform.RotateAround (hit.transform.position, Vector3.up, hit.transform.rotation.eulerAngles.y-90.0f);

			}
		}

		if(selectAgent){

		if (Input.GetMouseButton(0)) {

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)) {

				if(Input.GetMouseButtonDown(0))
				{
					
					if(hit.collider.tag == "CSAgent"){
							selectAgent = false;
							AgentCamActive = true;
							AgentCam.GetComponent<Camera>().enabled = true;

						//hit.collider.gameObject now refers to the 
						//cube under the mouse cursor if present
						print("Hit Agent: " + hit.collider.gameObject.name);
						//hit.collider.gameObject.renderer.enabled = false; //Only disables preview , object is still there
						

							//hit.collider.gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Self-Illumin/Diffuse");
							//else renderer.material.shader = Shader.Find("Diffuse");
						}//end clickable
					}//end getmouse
					
				

			}//end raycast
			
			
			
		}
		}//end selectagent
	
	}
}