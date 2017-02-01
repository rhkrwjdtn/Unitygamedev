using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxManager : MonoBehaviour {

    public float timespa;
    public float checkTi;
    public float delaytime;
    public float delaychecktime;
    public int touchcnt=0;

    public GameObject boxClickPopup = null;
    public GameObject box=null;

	// Use this for initialization
	void Start () {
        timespa = 0.0f;
        checkTi = 30.0f;
        delaytime = 0.0f;
        delaychecktime = 10.0f;

	}
	
	// Update is called once per frame
	void Update () {
        EmploymentManager employ = GameObject.Find("EmployManager").GetComponent<EmploymentManager>();
        if(employ.chunsooruExist==true)
        {
            timespa += Time.deltaTime;
            if(timespa>checkTi)
            {
                eventbox();
               

                delaytime += Time.deltaTime;
                if(delaytime>delaychecktime)
                {
                    box.active = false;
                    timespa = 0;
                    delaytime = 0;
                }
            }
            if(touchcnt>5)
            {
                box.active = false;
                touchcnt = 0;
                boxClickPopup.active = true;


            }
        }

	}

    public void eventbox()
    {
        box.active = true;
        
           
    }
    public void Touchbox()
    {
        if(Input.GetMouseButtonDown(0))
        {
            touchcnt++;
        }
    }
}
