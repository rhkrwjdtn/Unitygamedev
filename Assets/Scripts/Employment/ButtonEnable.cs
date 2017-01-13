using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEnable : MonoBehaviour {
    public UnityEngine.UI.Button btn;
    public int money=30;
	// Use this for initialization
	void Start () {
        if (btn == null)
        {
            btn = gameObject.GetComponent<UnityEngine.UI.Button>();
        }
            	
	}
	
	// Update is called once per frame
	void Update () {
	if(money>15)
        {
            btn.enabled = false;
            ColorBlock cd = btn.colors;
            cd.normalColor = Color.blue;
            btn.colors = cd;

        }	
	}
}
