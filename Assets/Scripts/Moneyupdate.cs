using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moneyupdate : MonoBehaviour {

	public Text moneytext;
	public int money;
	public int moneytouchspeed = 500;
	public int moneyspeed = 6;




	void Start() {

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

				money += moneytouchspeed;
				moneytext.text = "Money : " + System.Convert.ToString (money) + "원";

		}
	}




}
