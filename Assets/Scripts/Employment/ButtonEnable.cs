using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEnable : MonoBehaviour {
    public UnityEngine.UI.Button btn;
    public UnityEngine.UI.Button secondbtn;
    public UnityEngine.UI.Button thirdbtn;
    public ulong money=0;
    public int randomnum = 0;
    public ulong JugallumLevel=0;
    public int touchcnt = 0;
    public ulong firstprice = 10000;
    public ulong firstplus = 0;
    public GameObject Jugallum = null;
    public GameObject waren = null;
    public GameObject dog = null;
    public GameObject myulchi = null;
    public GameObject yapsap = null;
    public GameObject dungchi = null;
    public GameObject myungsasu = null;
    public GameObject skate = null;
    public GameObject godh = null;
    public GameObject box = null;
    public GameObject goldbox = null;
    public Text btn_text=null;
    public bool waren_exist =false;
    public bool box_exist = false;
    public bool goldbox_exist = false;
    public float timespan;
    public float checkTime;

	// Use this for initialization
	void Start () {
        if (btn == null)
        {
            btn = gameObject.GetComponent<UnityEngine.UI.Button>();

        }
        if(secondbtn==null)
        {
            secondbtn = gameObject.GetComponent<UnityEngine.UI.Button>();
        }

        JugallumLevel = 0;
        //PlayerPrefs.SetInt("FirstJugallumLevel", JugallumLevel);
        //btn_text.text = "test";

        ColorBlock cd = btn.colors;
        ColorBlock dd = btn.colors;
        cd.normalColor = Color.blue;
        dd.normalColor = Color.white;

        btn.enabled = false;
        secondbtn.enabled = false;
        btn.colors = cd;
        secondbtn.colors = cd;

        timespan = 0.0f;
        checkTime = 5.0f;
    }
	
	// Update is called once per frame
	void Update () {

        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
        money = moneyu.money;

	//	firstprice = PlayerPrefs.GetInt("FirstPrice", 0);

        ColorBlock cd = btn.colors;
        ColorBlock dd = btn.colors;
        cd.normalColor = Color.blue;
        dd.normalColor = Color.white;


        if (money>firstprice)
        {
            btn.enabled = true;
            btn.colors = dd;
        }	
        if(money<firstprice)
        {
            btn.enabled = false;
            btn.colors = cd;
        }

        if(money>301)
        {
            secondbtn.enabled = true;
            secondbtn.colors = dd;
        }
        else if(money<300)
        {
            secondbtn.enabled = false;
            secondbtn.colors = cd;
        }

        if(waren_exist==true)
        {
            timespan += Time.deltaTime;
            if(timespan>checkTime)
            {
                eventbox();
                timespan = 0;
            }
            if (touchcnt > 5)
            {
                box.active = false;
                goldbox.active = false;
                touchcnt = 0;
            }

        }
        if(waren.active==true)
        {
            waren_exist = true;
        }
    }
    public void btnClick()
    {
        Moneyupdate moneyu= GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
      //  JugallumLevel = PlayerPrefs.GetInt("FirstJugallumLevel", 0);
        firstplus = firstplus + JugallumLevel;
        firstprice = 10000 + 200 * (firstplus);
        Jugallum.active = true;
        JugallumLevel++;
<<<<<<< HEAD
        dog.active = true;
        PlayerPrefs.SetInt("FirstPrice", firstprice);
        PlayerPrefs.SetInt("FirstJugallumLevel", JugallumLevel);
=======
     //   PlayerPrefs.SetInt("FirstPrice", firstprice);
      //  PlayerPrefs.SetInt("FirstJugallumLevel", JugallumLevel);
>>>>>>> 0a0aaddffef9946fec0ebc8a47df1cc38c65f12b
        moneyu.money = moneyu.money - firstprice;
		moneyu.moneyspeed += 2;
        btn_text.fontSize = 10;
        btn_text.text= "레벨:"+JugallumLevel+"\n"+"비용:"+firstprice;
        
    }   

    public void secondbtnClick()
    {

        waren.active = true;
        waren_exist = true;


    }
    public void eventbox()
    {
        randomnum = Random.Range(0, 10);
        if(randomnum<6)
        {
            box.active = true;
            box_exist = true;
        }
        else
        {
            goldbox.active = true;
            goldbox_exist = true;
        }


    }
    public void Touchbox()
    {
        if(Input.GetMouseButtonDown(0))
        {

            touchcnt++;

        }
    }
}
