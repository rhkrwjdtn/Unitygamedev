using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalManager : MonoBehaviour {

	public bool[] getcheck;

	public IconManager itemplus;
	public Moneyupdate moneycheck;

	public GameObject soilbutton;
	public GameObject prasticbutton;
	public GameObject nuckbutton;
	public GameObject dongbutton;
	public GameObject silverbutton;
	public GameObject goldbutton;
	public GameObject diamondbutton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (getcheck [0] != true && moneycheck.moneyspeed >= 10000) {       //흙수저 체크

			soilbutton.GetComponent<Button> ().interactable = true;

		} else if (getcheck [0] == true) {
			soilbutton.GetComponent<Transform> ().FindChild ("Text").GetComponent<Text> ().text = "완료";
		}

		if (getcheck [1] != true && moneycheck.moneyspeed >= 50000) {       //플라스틱수저 체크
			prasticbutton.GetComponent<Button> ().interactable = true;
		} else if (getcheck [1] == true) {
			prasticbutton.GetComponent<Transform> ().FindChild ("Text").GetComponent<Text> ().text = "완료";
		}

		if (getcheck [2] != true && moneycheck.moneyspeed >= 100000) {       //녹수저 체크
			nuckbutton.GetComponent<Button> ().interactable = true;
		} else if (getcheck [2] == true) {
			nuckbutton.GetComponent<Transform> ().FindChild ("Text").GetComponent<Text> ().text = "완료";
		}

		if (getcheck [3] != true && moneycheck.moneyspeed >= 500000) {       //동수저 체크
			dongbutton.GetComponent<Button> ().interactable = true;
		} else if (getcheck [3] ==true) {
			dongbutton.GetComponent<Transform> ().FindChild ("Text").GetComponent<Text> ().text = "완료";
		}

		if (getcheck [4] != true && moneycheck.moneyspeed >= 1000000) {       //동수저 체크
			silverbutton.GetComponent<Button> ().interactable = true;
		} else if (getcheck [4] == true) {
			silverbutton.GetComponent<Transform> ().FindChild ("Text").GetComponent<Text> ().text = "완료";
		}

		if (getcheck [5] != true && moneycheck.moneyspeed >= 5000000) {       //동수저 체크
			goldbutton.GetComponent<Button> ().interactable = true;
		} else if (getcheck [5] == true) {
			goldbutton.GetComponent<Transform> ().FindChild ("Text").GetComponent<Text> ().text = "완료";
		}

		if (getcheck [6] != true && moneycheck.moneyspeed >= 10000000) {       //동수저 체크
			diamondbutton.GetComponent<Button> ().interactable = true;
		} else if (getcheck [6] == true) {
			diamondbutton.GetComponent<Transform> ().FindChild ("Text").GetComponent<Text> ().text = "완료";
		}


	}

	public void Soilbutton(){

		itemplus.redbullcnt += 1;
		getcheck [0] = true;
		soilbutton.GetComponent<Button> ().interactable = false;
		soilbutton.GetComponent<Transform> ().FindChild ("Text").GetComponent<Text> ().text = "완료";

	}

	public void Prasticbutton(){

		itemplus.redbullcnt += 1;
		getcheck [1] = true;
		prasticbutton.GetComponent<Button> ().interactable = false;
		prasticbutton.GetComponent<Transform> ().FindChild ("Text").GetComponent<Text> ().text = "완료";
	}

	public void Nuckbutton(){

		itemplus.redbullcnt += 1;
		getcheck [2] = true;
		nuckbutton.GetComponent<Button> ().interactable = false;
		nuckbutton.GetComponent<Transform> ().FindChild ("Text").GetComponent<Text> ().text = "완료";
	}

	public void Dongbutton(){

		itemplus.redbullcnt += 1;
		getcheck [3] = true;
		dongbutton.GetComponent<Button> ().interactable = false;
		dongbutton.GetComponent<Transform> ().FindChild ("Text").GetComponent<Text> ().text = "완료";
	}

	public void Silverbutton(){

		itemplus.redbullcnt += 1;
		getcheck [4] = true;
		silverbutton.GetComponent<Button> ().interactable = false;
		silverbutton.GetComponent<Transform> ().FindChild ("Text").GetComponent<Text> ().text = "완료";
	}

	public void Goldbutton(){

		itemplus.redbullcnt += 1;
		getcheck [5] = true;
		goldbutton.GetComponent<Button> ().interactable = false;
		goldbutton.GetComponent<Transform> ().FindChild ("Text").GetComponent<Text> ().text = "완료";
	}

	public void Diamondbutton(){

		itemplus.redbullcnt += 1;
		getcheck [6] = true;
		diamondbutton.GetComponent<Button> ().interactable = false;
		diamondbutton.GetComponent<Transform> ().FindChild ("Text").GetComponent<Text> ().text = "완료";
	}
}
