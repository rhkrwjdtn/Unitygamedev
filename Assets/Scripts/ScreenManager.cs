using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour {

	void Start(){
		Screen.SetResolution(Screen.width, (Screen.width / 2) * 3 ,true); 
	}
	
	// Update is called once per frame
	public void OnclickBack () {
		Debug.Log ("스크린!@@@@@");
		Screen.SetResolution(Screen.width, (Screen.width / 2) * 3 ,true); 
	}
}
