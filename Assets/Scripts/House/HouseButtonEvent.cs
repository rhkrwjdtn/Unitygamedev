using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseButtonEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setBG (int btn){
		switch (btn) {
		case 0:
			Debug.Log ("btn0_onClick");
		break;
		case 1:
			Debug.Log ("btn1_onClick");
		break;
		}
	}
}
