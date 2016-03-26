/// Ant-Based Modeling
/// 
/// Developed and Designed by Poseidon Ho at MIT Media Lab 
/// 
/// Script for switching between different scenes
/// 

using UnityEngine;
using System.Collections;

public class SceneSelector : MonoBehaviour {

	public string levelName; 

	public void LoadMainScene(){
		Application.LoadLevel(0);
	}

	public void LoadLibraryScene(){
		Application.LoadLevel(1);
	}
}