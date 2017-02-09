using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPopup : MonoBehaviour {

    public int checkin = 0;
    public GameObject[] popup = new GameObject[8];
    public GameObject Thankspopup;
    public GameObject StartPopup2;
    public Button Prev;
    public Button Next;
    public bool Firstpopup=false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(checkin==0)
        {
            Prev.interactable = false;
        }
        else if(checkin!=0)
        {
            Prev.interactable = true;
        }

	}
    public void NextbtnClick()
    {
        IconManager icon = GameObject.Find("IconManager").GetComponent<IconManager>();
        checkin++;
        if (checkin == 8)
        {
            StartPopup2.active = false;
            if(Firstpopup==false)
            {
                Thankspopup.active = true;
                icon.rebirthpotion++;
                Firstpopup = true;
            }

            for(int i=0;i<8;i++)
            {
                popup[i].active = false;
            }
            popup[0].active = true;
            checkin = 0;
           
        }
        else if (checkin != 8)
        {
            popup[checkin].active = true;
        }
    }
    public void PrevbtnClick()
    {

        popup[checkin].active = false;
        popup[checkin-1].active = true;
        checkin--;
    }
}
