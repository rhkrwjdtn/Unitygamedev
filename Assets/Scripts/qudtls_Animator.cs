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
	

		StartCoroutine ("QudtlsAnimation", 0.2);
	}

	IEnumerator QudtlsAnimation(float delayTime) {


	
		if (qudcount == qudtlsAni.Length) {
			qudcount=0;
		} else if (qudcount < qudtlsAni.Length) {
			qudcount++;
		}


		if (dogcount == dogAni.Length) {
			dogcount=0;
		} else if (dogcount < dogAni.Length) {
			dogcount++;
		}


		if (chunsurucount == chunsuruAni.Length) {
			chunsurucount=0;
		} else if (chunsurucount < chunsuruAni.Length) {
			chunsurucount++;
		}


		if (hohyungcount == hohyungAni.Length) {
			hohyungcount=0;
		} else if (hohyungcount < hohyungAni.Length) {
			hohyungcount++;
		}


		if (yuSickcount == yuSickAni.Length) {
			yuSickcount=0;
		} else if (yuSickcount < yuSickAni.Length) {
			yuSickcount++;
		}


		if (myungsasucount == myungsasuAni.Length) {
			myungsasucount=0;
		} else if (myungsasucount < myungsasuAni.Length) {
			myungsasucount++;
		}


		if (yapsapcount == yapsapAni.Length) {
			yapsapcount=0;
		} else if (yapsapcount < yapsapAni.Length) {
			yapsapcount++;
		}
		if (myulchicount == myulchiAni.Length) {
			myulchicount=0;
		} else if (myulchicount < myulchiAni.Length) {
			myulchicount++;
		}
		if (dungchicount == dungchiAni.Length) {
			dungchicount=0;
		} else if (dungchicount < dungchiAni.Length) {
			dungchicount++;
		}

		if (byunghun2count == byunghun2Ani.Length) {
			byunghun2count=0;
		} else if (byunghun2count < byunghun2Ani.Length) {
			byunghun2count++;
		}


		if (hanicount == haniAni.Length) {
			hanicount=0;
		} else if (hanicount < haniAni.Length) {
			hanicount++;
		}

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

		yield return new WaitForSeconds(delayTime);
		StartCoroutine("QudtlsAnimation", 0.2);
	}


}
