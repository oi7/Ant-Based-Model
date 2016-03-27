/// Ant-Based Modeling
/// 
/// Developed and Designed by Poseidon Ho at MIT Media Lab 
/// 
/// Script for controlling agent's movements
/// 

using UnityEngine;
using System.Collections;

public class AgentController : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A))
		{
			animator.SetTrigger("Walking");
			Debug.Log("walk");
		}
	}
}
