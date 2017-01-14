using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEnable : MonoBehaviour {
    public UnityEngine.UI.Button btn;
    public int money=30;
    public int JugallumLevel;
    public GameObject Jugallum = null;
    public Text btn_text;

	// Use this for initialization
	void Start () {
        if (btn == null)
        {
            btn = gameObject.GetComponent<UnityEngine.UI.Button>();

        }
        JugallumLevel = 0;
        PlayerPrefs.SetInt("FirstJugallumLevel", JugallumLevel);
        //btn_text.text = "test";
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
    public void ShowImage()
    {
        JugallumLevel = PlayerPrefs.GetInt("FirstJugallumLevel", 0);
        Jugallum.active = true;
        JugallumLevel++;
        PlayerPrefs.SetInt("FirstJugallumLevel", JugallumLevel);

        btn_text.text= "레벨:"+JugallumLevel;

        

    }   

}
