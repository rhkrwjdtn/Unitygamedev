using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moneyupdate : MonoBehaviour {

	public Text moneytext;
	public int money = 0;

	public int touchwon = 3000;
	public int touchman;
	public int touchuck;
	public int touchjo;
	public int touchkuyng;

	public int won;
	public int man;
	public int uck;
	public int jo;
	public int kuyng;

	public int moneyspeed = 500;

	public AudioSource coinAudio;
	public AudioClip coinSound;

	RaycastHit hit;

	void Start() {
		coinAudio = GetComponent<AudioSource> ();

		StartCoroutine ("CountTime", 1);
	}

	IEnumerator CountTime(float delayTime) {

		won += moneyspeed;



		yield return new WaitForSeconds(delayTime);
		StartCoroutine("CountTime", 1);
	}

	void Update(){
		if (won > 10000) {

			man += won / 10000;
			won = won % 10000;

		} 

		if (man > 10000) {

			uck += man / 10000;
			man = man % 10000;
		}

		if (uck > 10000) {

			jo += uck / 10000;
			uck = uck % 10000;
		}

		if (jo > 10000) {

			kuyng += jo / 10000;
			jo = jo % 10000;

		}

		if (won >0  && man == 0 &&  uck ==0 && jo == 0 && kuyng == 0) {
			moneytext.text = "Money : " + System.Convert.ToString (won) + "원";

		} else if (won >= 0  && man > 0 &&  uck ==0 && jo == 0 && kuyng == 0) {
			
			moneytext.text = "Money : " + System.Convert.ToString (man) + "만" + System.Convert.ToString (won) + "원";

		} else if (won >= 0 && man >= 0 &&  uck > 0 && jo == 0 && kuyng == 0) {

			moneytext.text = "Money : " + System.Convert.ToString (uck) + "억"+ System.Convert.ToString (man) + "만" + System.Convert.ToString (won) + "원";

		} else if (won >= 0 && man >= 0 &&  uck >=0 && jo > 0 && kuyng == 0) {

			moneytext.text = "Money : " + System.Convert.ToString (jo) + "조"+System.Convert.ToString (uck) + "억"+ System.Convert.ToString (man) + "만";


		} else if (won >= 0 && man >= 0 &&  uck>=0 && jo >= 0 && kuyng > 0) {

			moneytext.text = "Money : " + System.Convert.ToString (kuyng) + "경" + System.Convert.ToString (jo) + "조"+System.Convert.ToString (uck) + "억";


		}

	}


	public void OnClickBackground () {

				coinAudio.clip = coinSound;
				coinAudio.Play ();                  //coinsound play


	
				won += touchwon;
				man += touchman;
				uck += touchuck;
				jo += touchjo;
				kuyng += touchkuyng;

							

		}
	}





