using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEnable : MonoBehaviour {
    public UnityEngine.UI.Button btn;
    public UnityEngine.UI.Button secondbtn;
    public UnityEngine.UI.Button yapsapbtn;
    public UnityEngine.UI.Button Dungchibtn;
    public UnityEngine.UI.Button myungsasubtn;
    public UnityEngine.UI.Button skatebtn;
    public UnityEngine.UI.Button godhbtn;
    public ulong money=0;
    public ulong firstprice = 10000;
    public ulong secondprice = 50000;
    public ulong thirdprice = 100000;
    public ulong forthprice = 500000;
    public ulong fifthprice = 1000000;
    public ulong sixthprice = 5000000;
    public ulong seventhprice = 10000000;

    public ulong myulchmoneyspeed = 10;
    public ulong yapsapmoneyspeed = 20;
    public ulong dungchimoneyspeed = 50;
    public ulong myungsasumoneyspeed = 100;
    public ulong skatemoneyspeed = 500;
    public ulong godhmoneyspeed = 1000;

    public int randomnum = 0;
    public int dogLevel=0;
    public int myulchiLevel = 0;
    public int yapsapLevel = 0;
    public int dungchiLevel = 0;
    public int myungsasuLevel = 0;
    public int skateLevel = 0;
    public int godhLevel = 0;

    public int touchcnt = 0;
    public int firstplus = 0;
    public int myulchplus = 0;
    public int yapsapplus = 0;
    public int dungchiplus = 0;
    public int myungsasuplus = 0;
    public int skateplus = 0;
    public int godhplus = 0;

    public int dogpc = 0;
    public int myulchpc = 0;
    public int yapsappc = 0;
    public int dungchipc = 0;
    public int myungsasupc = 0;
    public int skatepc = 0;
    public int godhpc = 0;

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
    public Text myulchbtn_text = null;
    public Text yapsapbtn_text = null;
    public Text dungchibtn_text = null;
    public Text myungsasubtn_text = null;
    public Text skatebtn_text = null;
    public Text godhbtn_text = null;

    public bool waren_exist =false;
    public bool box_exist = false;
    public bool goldbox_exist = false;
    public float timespan;
    public float checkTime;
    public string dogprice;
    public string myulchprice;
    public string yapsapprice;
    public string dungchiprice;
    public string myungsasuprice;
    public string skateprice;
    public string godhprice;


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
        if(yapsapbtn==null)
        {
            yapsapbtn= gameObject.GetComponent<UnityEngine.UI.Button>();
        }
        if(Dungchibtn==null)
        {
            Dungchibtn= gameObject.GetComponent<UnityEngine.UI.Button>();
        }
        if(myungsasubtn==null)
        {
            myungsasubtn=gameObject.GetComponent<UnityEngine.UI.Button>();
        }
        if(skatebtn==null)
        {
            skatebtn= gameObject.GetComponent<UnityEngine.UI.Button>();
        }
        if(godhbtn==null)
        {
            godhbtn= gameObject.GetComponent<UnityEngine.UI.Button>();
        }

        dogLevel = 0;
        PlayerPrefs.SetInt("DogLevel", dogLevel);
        PlayerPrefs.SetInt("MyulchLevel", myulchiLevel);
        PlayerPrefs.SetInt("YapsapLevel", yapsapLevel);
        PlayerPrefs.SetInt("DungchiLevel", dungchiLevel);
        PlayerPrefs.SetInt("MyungsasuLevel", myungsasuLevel);
        PlayerPrefs.SetInt("SkateLevel", skateLevel);
        PlayerPrefs.SetInt("GodhLevel", godhLevel);
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

		dogpc = PlayerPrefs.GetInt("FirstPrice", 0);
        myulchpc = PlayerPrefs.GetInt("SecondPrice", 0);
        yapsappc = PlayerPrefs.GetInt("ThirdPrice", 0);
        dungchipc = PlayerPrefs.GetInt("ForthPrice", 0);
        myungsasupc = PlayerPrefs.GetInt("FifthPrice", 0);
        skatepc = PlayerPrefs.GetInt("SixthPrice", 0);
        godhpc = PlayerPrefs.GetInt("SeventhPrice", 0);

        dogprice = dogpc.ToString();
        myulchprice = myulchpc.ToString();
        yapsapprice = yapsappc.ToString();
        dungchiprice = dungchipc.ToString();
        myungsasuprice = myungsasupc.ToString();
        skateprice = skatepc.ToString();
        godhprice = godhpc.ToString();

        firstprice = ulong.Parse(dogprice);
        secondprice = ulong.Parse(myulchprice);
        thirdprice = ulong.Parse(yapsapprice);
        forthprice = ulong.Parse(dungchiprice);
        fifthprice = ulong.Parse(myungsasuprice);
        sixthprice = ulong.Parse(skateprice);
        seventhprice = ulong.Parse(godhprice);

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

        if(money>secondprice)
        {
            secondbtn.enabled = true;
            secondbtn.colors = dd;
        }
        else if(money<secondprice)
        {
            secondbtn.enabled = false;
            secondbtn.colors = cd;
        }

        if(money>thirdprice)
        {
            yapsapbtn.enabled = true;
            yapsapbtn.colors = dd;
        }
        else if(money<thirdprice)
        {
            yapsapbtn.enabled = false;
            yapsapbtn.colors = cd;
        }
        if(money>forthprice)
        {
            Dungchibtn.enabled = true;
            Dungchibtn.colors = dd;
        }
        else if(money<forthprice)
        {
            Dungchibtn.enabled = false;
            Dungchibtn.colors = cd;
        }
        if(money>fifthprice)
        {
            myungsasubtn.enabled = true;
            myungsasubtn.colors = dd;
        }
        else if(money<fifthprice)
        {
            myungsasubtn.enabled = false;
            myungsasubtn.colors = cd;
        }
        if(money>sixthprice)
        {
            skatebtn.enabled = true;
            skatebtn.colors = dd;
        }
        else if(money<sixthprice)
        {
            skatebtn.enabled = false;
            skatebtn.colors = cd;
        }
        if(money>seventhprice)
        {
            godhbtn.enabled = true;
            godhbtn.colors = dd;
        }
        else if(money<seventhprice)
        {
            godhbtn.enabled = false;
            godhbtn.colors = cd;
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
        dogLevel = PlayerPrefs.GetInt("DogLevel", 0);
        firstplus = firstplus + dogLevel;
        dogpc = 10000 + 200 * (firstplus);
        dogprice = dogpc.ToString();
        firstprice = ulong.Parse(dogprice);
        //스트링으로 바꿔서?
        dogLevel++;
        dog.active = true;
        PlayerPrefs.SetInt("FirstPrice", dogpc);
        PlayerPrefs.SetInt("DogLevel", dogLevel);
        moneyu.money = moneyu.money - firstprice;
		moneyu.moneyspeed += 2;
        btn_text.fontSize = 10;
        btn_text.text= "레벨:"+dogLevel+"\n"+"비용:"+dogprice;
    }   

    public void secondbtnClick()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
        myulchiLevel = PlayerPrefs.GetInt("MyulchLevel", 0);
        myulchplus = myulchplus + myulchiLevel;
        myulchpc = (10000 + 200 * (myulchplus))*5;
        myulchprice = myulchpc.ToString();
        secondprice = ulong.Parse(myulchprice);
        myulchiLevel++;
        myulchi.active = true;
        PlayerPrefs.SetInt("SecondPrice", myulchpc);
        PlayerPrefs.SetInt("MyulchLevel", myulchiLevel);
        myulchmoneyspeed += 10;
        moneyu.money = moneyu.money - secondprice;
        moneyu.moneyspeed = moneyu.moneyspeed + myulchmoneyspeed;
        myulchbtn_text.fontSize = 10;
        myulchbtn_text.text = "레벨:" + myulchiLevel + "\n" + "비용:" + myulchprice;
    }

    public void YapsapbtnClick()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
        yapsapLevel = PlayerPrefs.GetInt("YapsapLevel", 0);
        yapsapplus = yapsapplus + yapsapLevel;
        yapsappc = (10000 + 200 * (yapsapplus)) * 10;
        yapsapprice = yapsappc.ToString();
        thirdprice = ulong.Parse(yapsapprice);
        yapsapLevel++;
        yapsap.active = true;
        PlayerPrefs.SetInt("ThirdPrice", yapsappc);
        PlayerPrefs.SetInt("YapsapLevel", yapsapLevel);
        yapsapmoneyspeed += 20;
        moneyu.money = moneyu.money - thirdprice;
        moneyu.moneyspeed = moneyu.moneyspeed + yapsapmoneyspeed;
        yapsapbtn_text.fontSize = 10;
        yapsapbtn_text.text = "레벨:" + yapsapLevel + "\n" + "비용:" + yapsapprice;
    }
    public void dungchibtnClick()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
        dungchiLevel = PlayerPrefs.GetInt("DungchiLevel", 0);
        dungchiplus = dungchiplus + dungchiLevel;
        dungchipc = (10000 + 200 * (dungchiplus)) * 50;
        dungchiprice = dungchipc.ToString();
        forthprice = ulong.Parse(dungchiprice);
        dungchiLevel++;
        dungchi.active = true;
        PlayerPrefs.SetInt("ForthPrice", dungchipc);
        PlayerPrefs.SetInt("DungchiLevel", dungchiLevel);
        dungchimoneyspeed += 50;
        moneyu.money = moneyu.money - forthprice;
        moneyu.moneyspeed = moneyu.moneyspeed + dungchimoneyspeed;
        dungchibtn_text.fontSize = 10;
        dungchibtn_text.text = "레벨:" + dungchiLevel + "\n" + "비용:" + dungchiprice;
    }
    public void myungsasubtnClick()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
        myungsasuLevel = PlayerPrefs.GetInt("MyungsasuLevel", 0);
        myungsasuplus = myungsasuplus + myungsasuLevel;
        myungsasupc = (10000 + 200 * (myungsasuplus)) * 100;
        myungsasuprice = myungsasupc.ToString();
        fifthprice = ulong.Parse(myungsasuprice);
        myungsasuLevel++;
        myungsasu.active = true;
        PlayerPrefs.SetInt("FifthPrice", myungsasupc);
        PlayerPrefs.SetInt("MyungsasuLevel", myungsasuLevel);
        myungsasumoneyspeed += 100;
        moneyu.money = moneyu.money - fifthprice;
        moneyu.moneyspeed = moneyu.moneyspeed + myungsasumoneyspeed;
        myungsasubtn_text.fontSize = 10;
        myungsasubtn_text.text = "레벨:" + myungsasuLevel + "\n" + "비용:" + myungsasuprice;
    }
    public void skatebtnClick()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
        skateLevel = PlayerPrefs.GetInt("SkateLevel", 0);
        skateplus = skateplus + skateLevel;
        skatepc = (10000 + 200 * (skateplus)) * 500;
        skateprice = skatepc.ToString();
        sixthprice = ulong.Parse(skateprice);
        skateLevel++;
        skate.active = true;
        PlayerPrefs.SetInt("SixthPrice", skatepc);
        PlayerPrefs.SetInt("SkateLevel", skateLevel);
        skatemoneyspeed += 500;
        moneyu.money = moneyu.money - sixthprice;
        moneyu.moneyspeed = moneyu.moneyspeed + skatemoneyspeed;
        skatebtn_text.fontSize = 10;
        skatebtn_text.text = "레벨:" + skateLevel + "\n" + "비용:" + skateprice;
    }
    public void godhbtnClick()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
        godhLevel = PlayerPrefs.GetInt("GodhLevel", 0);
        godhplus = godhplus + godhLevel;
        godhpc = (10000 * 200 * (godhplus)) * 1000;
        godhprice = godhpc.ToString();
        seventhprice = ulong.Parse(godhprice);
        godhLevel++;
        godh.active = true;
        PlayerPrefs.SetInt("SeventhPrice", godhpc);
        PlayerPrefs.SetInt("GodhLevel", godhLevel);
        godhmoneyspeed += 1000;
        moneyu.money = moneyu.money - seventhprice;
        moneyu.moneyspeed = moneyu.moneyspeed + godhmoneyspeed;
        godhbtn_text.fontSize = 10;
        godhbtn_text.text = "레벨:" + godhLevel + "\n" + "비용:" + godhprice;

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
