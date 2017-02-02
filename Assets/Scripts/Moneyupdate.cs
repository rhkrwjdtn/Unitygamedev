using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moneyupdate : MonoBehaviour {

	public Text moneytext;
	public Text secondtext;
	public Text touchtext;

	public ulong money = 0;

	public bool effectsound = true;

	public ulong won;
	public ulong man;
	public ulong uck;
	public ulong jo;
	public ulong kuyng;

	public ulong touchspeed ;
	public ulong moneyspeed ;

	public AudioSource coinAudio;
	public AudioClip coinSound;


	void Start() {
		coinAudio = GetComponent<AudioSource> ();

		StartCoroutine ("CountTime", 1);
	}


	IEnumerator CountTime(float delayTime) {


		money += moneyspeed;

		ulong moneytransform = money;

			kuyng = moneytransform / 10000000000000000;
			moneytransform = moneytransform % 10000000000000000;
			jo = moneytransform / 1000000000000;
			moneytransform = moneytransform % 1000000000000;
			uck = moneytransform / 100000000;
			moneytransform = moneytransform % 100000000;
			man = moneytransform / 10000;
			won = moneytransform % 10000;



		yield return new WaitForSeconds(delayTime);
		StartCoroutine("CountTime", 1);
	}

	void Update(){

		touchtext.text = System.Convert.ToUInt64 (touchspeed) + "원/클릭";
		secondtext.text = System.Convert.ToUInt64 (moneyspeed) + "원/초";

		if (won >0  && man == 0 &&  uck ==0 && jo == 0 && kuyng == 0) {
			moneytext.text =  System.Convert.ToString (won) + "원";

		} else if (won >= 0  && man > 0 &&  uck ==0 && jo == 0 && kuyng == 0) {

			moneytext.text =  System.Convert.ToString (man) + "만" + System.Convert.ToString (won) + "원";

		} else if (won >= 0 && man >= 0 &&  uck > 0 && jo == 0 && kuyng == 0) {

			moneytext.text =  System.Convert.ToString (uck) + "억"+ System.Convert.ToString (man) + "만" + System.Convert.ToString (won) + "원";

		} else if (won >= 0 && man >= 0 &&  uck >=0 && jo > 0 && kuyng == 0) {

			moneytext.text =  System.Convert.ToString (jo) + "조"+System.Convert.ToString (uck) + "억"+ System.Convert.ToString (man) + "만";


		} else if (won >= 0 && man >= 0 &&  uck>=0 && jo >= 0 && kuyng > 0) {

			moneytext.text =  System.Convert.ToString (kuyng) + "경" + System.Convert.ToString (jo) + "조"+System.Convert.ToString (uck) + "억";


		}

	}


	public void OnClickBackground () {

		if (effectsound) {
			coinAudio.clip = coinSound;
			coinAudio.Play ();                  //coinsound play

		}

		money += touchspeed;

		ulong moneytransform = money;

			kuyng = moneytransform / 10000000000000000;
			moneytransform = moneytransform % 10000000000000000;
			jo = moneytransform / 1000000000000;
			moneytransform = moneytransform % 1000000000000;
			uck = moneytransform / 100000000;
			moneytransform = moneytransform % 100000000;
			man = moneytransform / 10000;
			won = moneytransform % 10000;



	}

	public void EffectSoundChange(){
		if (effectsound == true) {
			effectsound = false;
		} else {
			effectsound = true;
		}
	}
}





