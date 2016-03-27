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
	public GameObject AntCamera;

	void Start() {
		UICamera.SetActive(true);
		ARCamera.SetActive(false);
		ARCamera.SetActive(false);
	}

	public void SwitchAR() {
		if (UICamera.activeSelf == true) {
			UICamera.SetActive (false);
			ARCamera.SetActive (true);
		} else {
			UICamera.SetActive (true);
			ARCamera.SetActive (false);
		}
	}

	public void SwitchAnt() {
		if (UICamera.activeSelf == true) {
			UICamera.SetActive (false);
			AntCamera.SetActive (true);
		} else {
			UICamera.SetActive (true);
			AntCamera.SetActive (false);
		}
	}
}