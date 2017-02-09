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
            Thankspopup.active = true;
            StartPopup2.active = false;
            icon.rebirthpotion++;

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
