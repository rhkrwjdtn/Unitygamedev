using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moneyupdate : MonoBehaviour {

	public Text moneytext;
	public int money = 0;
	public int moneytouchspeed = 3000;
	public int moneyspeed = 500;

	public AudioSource coinAudio;
	public AudioClip coinSound;

	void Start() {
		coinAudio = GetComponent<AudioSource> ();

		StartCoroutine ("CountTime", 1);
	}

	IEnumerator CountTime(float delayTime) {

		money += moneyspeed;
		moneytext.text = "Money : " + System.Convert.ToString (money) + "원";

		yield return new WaitForSeconds(delayTime);
		StartCoroutine("CountTime", 1);
	}

	void Update () {

		if (Input.GetMouseButtonDown (0)) {

			coinAudio.clip = coinSound;
			coinAudio.Play ();                  //coinsound play


	
				money += moneytouchspeed;
				moneytext.text = "Money : " + System.Convert.ToString (money) + "원";

		}
	}




}
