using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class qudtls_Animator : MonoBehaviour {
	
	public GameObject qudtls;
	public Sprite[] qudtlsAni;


	private int i;

	// Use this for initialization
	void Start()
	{	
		i = 0;
		qudtls.GetComponent<Image> ().sprite = qudtlsAni[0];

		StartCoroutine ("QudtlsAnimation", 0.7);
	}

	IEnumerator QudtlsAnimation(float delayTime) {


	
		if (i == 7) {
			i=0;
		} else if (i < 7) {
			i++;
		}

		qudtls.GetComponent<Image> ().sprite = qudtlsAni [i];

		yield return new WaitForSeconds(delayTime);
		StartCoroutine("QudtlsAnimation", 0.7);
	}


}
