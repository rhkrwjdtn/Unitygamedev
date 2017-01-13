using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEnable : MonoBehaviour {
    public UnityEngine.UI.Button btn=null;
    public Image image = null;
    public int money=30;
    public GameObject FirstJugall=null;
    

	// Use this for initialization
	void Start () {
        if (btn == null)
        {
            btn = gameObject.GetComponent<UnityEngine.UI.Button>();
            //Sprite newSprite = Resources.Load<Sprite>("jugall");
            //image.overrideSprite = newSprite;
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
        else
        {

        }
	}
    public void ShowImage()
    {
        FirstJugall.active = true;
        //image.enabled = true;
    }
}
