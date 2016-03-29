/// Ant-Based Modeling
/// 
/// Developed and Designed by Poseidon Ho at MIT Media Lab 
/// 
/// Script for switching between UICamera and ARCamera
/// 

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraSwap : MonoBehaviour
{
	public GameObject UICamera;
	public GameObject ARCamera;

	void Start() {
		UICamera.SetActive(false);
		ARCamera.SetActive(true);
	}

	public void SwitchAR() {
		if (ARCamera.activeSelf == true) {
			UICamera.SetActive (true);
			ARCamera.SetActive (false);
		} else {
			UICamera.SetActive (false);
			ARCamera.SetActive (true);
		}
	}
}