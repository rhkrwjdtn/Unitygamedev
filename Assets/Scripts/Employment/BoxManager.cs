using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxManager : MonoBehaviour {

    public bool waren_ex=false;
    public float timespa;
    public float checkTi;
	// Use this for initialization
	void Start () {
        timespa = 0.0f;
        checkTi = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {

        ButtonEnable be = GameObject.Find("EmployManager").GetComponent<ButtonEnable>();
        waren_ex = be.waren_exist;
        timespa = be.timespan;
        checkTi = be.checkTime;
        if(waren_ex==true)
        {
            if (timespa > checkTi)
            {
                be.eventbox();
                timespa = 0;
            }
        }
	}
}
