using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public bool backgroundsound = true;
	public bool effectsound = true;

	public Camera cam;

	public Moneyupdate moneysound;

	public GameObject backOnbutton;
	public GameObject backOffbuton;
	public GameObject effectOnbutton;
	public GameObject effectOffbuton;

	void Start(){
		if (backgroundsound == false) {
			cam.GetComponent<AudioSource> ().Stop ();
			backOffbuton.SetActive (false);
			backOnbutton.SetActive (true);
		}
		if (effectsound == false) {
			moneysound.effectsound = false;
			effectOffbuton.SetActive (false);
			effectOnbutton.SetActive (true);
		}
	}

	public void Backgroundbutton(){
		if (backgroundsound == true) {
			backgroundsound = false;
		} else {
			backgroundsound = true;
		}
	}

	public void Effectsoundbutton(){
		if (effectsound == true) {
			effectsound = false;
		} else {
			effectsound = true;
		}
	}

}
