using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class spoonmanager : MonoBehaviour {

    public Image spoonimage;
    public Sprite gmfrspoon;
    public Sprite plasticspoon;
    public Sprite nokspoon;
    public Sprite dongspoon;
    public Sprite silverspoon;
    public Sprite goldspoon;
    public Sprite diaspoon;
    public GameObject popup;

	// Use this for initialization
	void Start () {


    }

    // Update is called once per frame
    void Update () {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();

        if (moneyu.moneyspeed <= 10000)
		{ spoonimage.GetComponent<Image>().sprite = gmfrspoon;}
        if (moneyu.moneyspeed <= 100000 && moneyu.moneyspeed > 10000)
		{ spoonimage.GetComponent<Image>().sprite = plasticspoon;}
        if(moneyu.moneyspeed<= 1000000 &&moneyu.moneyspeed>100000)
		{ spoonimage.GetComponent<Image>().sprite = nokspoon;}
        if(moneyu.moneyspeed<=10000000 && moneyu.moneyspeed>1000000)
		{ spoonimage.GetComponent<Image>().sprite = dongspoon;}
        if(moneyu.moneyspeed<=100000000&&moneyu.moneyspeed>10000000)
		{ spoonimage.GetComponent<Image>().sprite = silverspoon;}
        if(moneyu.moneyspeed<=1000000000&&moneyu.moneyspeed>100000000)
		{ spoonimage.GetComponent<Image>().sprite = goldspoon;}
        if(moneyu.moneyspeed<=10000000000&&moneyu.moneyspeed>1000000000)
		{ spoonimage.GetComponent<Image>().sprite = diaspoon;}

    }
    public void spoonClick()
    {
        popup.active = true;
    }
}
