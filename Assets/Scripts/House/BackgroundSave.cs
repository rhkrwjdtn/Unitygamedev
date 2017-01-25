using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSave : MonoBehaviour {
	public Sprite selectedBG;

	// Use this for initialization
	void Start () {
		selectedBG = GameObject.Find ("Background").GetComponent<Image> ().sprite;	
	}

}
