/// Ant-Based Modeling
/// 
/// Developed and Designed by Poseidon Ho at MIT Media Lab 
/// 
/// Script for switching between different environments
/// 

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeEnvironment : MonoBehaviour
{
	public GameObject meadow1;
	public GameObject meadow2;
	public GameObject meadow3;
	public GameObject meadow4;
	public GameObject meadow5;
	public GameObject desert1;
	public GameObject desert2;
	public GameObject desert3;
	public GameObject desert4;
	public GameObject desert5;

	public void Change() {
		if (meadow1.activeSelf == true) {
			desert1.SetActive (true);
			desert2.SetActive (true);
			desert3.SetActive (true);
			desert4.SetActive (true);
			desert5.SetActive (true);
			meadow1.SetActive (false);
			meadow2.SetActive (false);
			meadow3.SetActive (false);
			meadow4.SetActive (false);
			meadow5.SetActive (false);
		} else {
			desert1.SetActive (false);
			desert2.SetActive (false);
			desert3.SetActive (false);
			desert4.SetActive (false);
			desert5.SetActive (false);
			meadow1.SetActive (true);
			meadow2.SetActive (true);
			meadow3.SetActive (true);
			meadow4.SetActive (true);
			meadow5.SetActive (true);
		}
	}
}