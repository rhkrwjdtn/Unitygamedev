using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class qudtls_Animator : MonoBehaviour {
	

	public GameObject qudtls;
	public GameObject dog;
	public GameObject chunsuru;
	public GameObject hohyung;
	public GameObject yuSick;
	public GameObject myungsasu;
	public GameObject dungchi;
	public GameObject myulchi;
	public GameObject yapsap;
	public GameObject byunghun2;
	public GameObject hani;
	public GameObject hyungwook;

	public Sprite[] qudtlsAni;
	public Sprite[] dogAni;
	public Sprite[] chunsuruAni;
	public Sprite[] hohyungAni;
	public Sprite[] yuSickAni;
	public Sprite[] myungsasuAni;
	public Sprite[] dungchiAni;
	public Sprite[] myulchiAni;
	public Sprite[] yapsapAni;
	public Sprite[] byunghun2Ani;
	public Sprite[] haniAni;
	public Sprite[] hyungwookAni;

	private int qudcount;
	private int dogcount;
	private int chunsurucount;
	private int hohyungcount;
	private int yuSickcount;
	private int myungsasucount;
	private int dungchicount;
	private int myulchicount;
	private int yapsapcount;
	private int byunghun2count;
	private int hanicount;
	private int hyungwookcount;

	// Use this for initialization
	void Start()
	{	
		qudcount = 0;
		dogcount = 0;
		chunsurucount = 0;
		hohyungcount = 0;
		yuSickcount = 0;
		myungsasucount = 0;
		dungchicount = 0;
		myulchicount = 0;
		yapsapcount = 0;
		byunghun2count = 0;
		hanicount = 0;
		hyungwookcount = 0;

		qudtls.GetComponent<Image> ().sprite = qudtlsAni[qudcount];
		dog.GetComponent<Image> ().sprite = dogAni [dogcount];
		chunsuru.GetComponent<Image> ().sprite = chunsuruAni[chunsurucount];
		hohyung.GetComponent<Image> ().sprite = hohyungAni [hohyungcount];
		yuSick.GetComponent<Image> ().sprite = yuSickAni[yuSickcount];
		myungsasu.GetComponent<Image> ().sprite = myungsasuAni [myungsasucount];
		dungchi.GetComponent<Image> ().sprite = dungchiAni[dungchicount];
		myulchi.GetComponent<Image> ().sprite = myulchiAni[myulchicount];
		yapsap.GetComponent<Image> ().sprite = yapsapAni[yapsapcount];
		byunghun2.GetComponent<Image> ().sprite = byunghun2Ani [byunghun2count];
		hani.GetComponent<Image> ().sprite = haniAni[hanicount];
		hyungwook.GetComponent<Image> ().sprite = hyungwookAni[hyungwookcount];

		StartCoroutine ("QudtlsAnimation", 0.7);
	}

	IEnumerator QudtlsAnimation(float delayTime) {


	
		if (qudcount == qudtlsAni.Length-1) {
			qudcount=0;
		} else if (qudcount < qudtlsAni.Length-1) {
			qudcount++;
		}

		Debug.Log ("카운트 length@@@@@@@@@@@"+qudtlsAni.Length);
		if (dogcount == dogAni.Length-1) {
			dogcount=0;
		} else if (dogcount < dogAni.Length-1) {
			dogcount++;
		}


		if (chunsurucount == chunsuruAni.Length-1) {
			chunsurucount=0;
		} else if (chunsurucount < chunsuruAni.Length-1) {
			chunsurucount++;
		}


		if (hohyungcount == hohyungAni.Length-1) {
			hohyungcount=0;
		} else if (hohyungcount < hohyungAni.Length) {
			hohyungcount++;
		}


		if (yuSickcount == yuSickAni.Length-1) {
			yuSickcount=0;
		} else if (yuSickcount < yuSickAni.Length-1) {
			yuSickcount++;
		}


		if (myungsasucount == myungsasuAni.Length-1) {
			myungsasucount=0;
		} else if (myungsasucount < myungsasuAni.Length-1) {
			myungsasucount++;
		}


		if (yapsapcount == yapsapAni.Length-1) {
			yapsapcount=0;
		} else if (yapsapcount < yapsapAni.Length-1) {
			yapsapcount++;
		}
		if (myulchicount == myulchiAni.Length-1) {
			myulchicount=0;
		} else if (myulchicount < myulchiAni.Length-1) {
			myulchicount++;
		}
		if (dungchicount == dungchiAni.Length-1) {
			dungchicount=0;
		} else if (dungchicount < dungchiAni.Length-1) {
			dungchicount++;
		}

		if (byunghun2count == byunghun2Ani.Length-1) {
			byunghun2count=0;
		} else if (byunghun2count < byunghun2Ani.Length-1) {
			byunghun2count++;
		}


		if (hanicount == haniAni.Length-1) {
			hanicount=0;
		} else if (hanicount < haniAni.Length-1) {
			hanicount++;
		}

		if (hyungwookcount == hyungwookAni.Length-1) {
			hyungwookcount=0;
		} else if (hyungwookcount < hyungwookAni.Length-1) {
			hyungwookcount++;
		}

		if(qudtls.activeSelf==true)
		qudtls.GetComponent<Image> ().sprite = qudtlsAni[qudcount];

		if(dog.activeSelf==true)
		dog.GetComponent<Image> ().sprite = dogAni [dogcount];

		if(chunsuru.activeSelf==true)
		chunsuru.GetComponent<Image> ().sprite = chunsuruAni[chunsurucount];

		if(hohyung.activeSelf==true)
		hohyung.GetComponent<Image> ().sprite = hohyungAni [hohyungcount];

		if(yuSick.activeSelf==true)
			yuSick.GetComponent<Image> ().sprite = yuSickAni[yuSickcount];

		if(myungsasu.activeSelf==true)
			myungsasu.GetComponent<Image> ().sprite = myungsasuAni [myungsasucount];

		if(dungchi.activeSelf==true)
			dungchi.GetComponent<Image> ().sprite = dungchiAni[dungchicount];


		if(myulchi.activeSelf==true)
			myulchi.GetComponent<Image> ().sprite = myulchiAni[myulchicount];

		if(yapsap.activeSelf==true)
			yapsap.GetComponent<Image> ().sprite = yapsapAni[yapsapcount];

		if(byunghun2.activeSelf==true)
			byunghun2.GetComponent<Image> ().sprite = byunghun2Ani [byunghun2count];

		if(hani.activeSelf==true)
			hani.GetComponent<Image> ().sprite = haniAni[hanicount];

		if(hyungwook.activeSelf==true)
		hyungwook.GetComponent<Image> ().sprite = hyungwookAni[hyungwookcount];

		yield return new WaitForSeconds(delayTime);
		StartCoroutine("QudtlsAnimation", 0.7);
	}


}
