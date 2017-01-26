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

    public ulong dogmoneyspeed = 2;
    public ulong myulchmoneyspeed = 10;
    public ulong yapsapmoneyspeed = 20;
    public ulong dungchimoneyspeed = 50;
    public ulong myungsasumoneyspeed = 100;
    public ulong skatemoneyspeed = 500;
    public ulong godhmoneyspeed = 1000;


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
	public GameObject imag = null;
	public GameObject myulchclose = null;
	public GameObject yapsapclose = null;
	public GameObject dungchclose = null;
	public GameObject myungsasuclose = null;
	public GameObject skateclose = null;
	public GameObject godhclose = null;

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

  

    public Image dogbackground;
    public Image myulchbackground;
    public Image yapsapbackground;
    public Image dungchbackground;
    public Image myungsasubackground;
    public Image skatebackground;
    public Image godhbackground;

    public Color close;
    public Color open;

    public Text btn_text=null;
    public Text myulchbtn_text = null;
    public Text yapsapbtn_text = null;
    public Text dungchibtn_text = null;
    public Text myungsasubtn_text = null;
    public Text skatebtn_text = null;
    public Text godhbtn_text = null;

    public Text dog_text = null;
    public Text myulch_text = null;
    public Text yapsap_text = null;
    public Text dungchi_text = null;
    public Text myungsasu_text = null;
    public Text skate_text = null;
    public Text godh_text = null;

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

        PlayerPrefs.SetInt("FirstPrice", 10000);
        PlayerPrefs.SetInt("SecondPrice", 50000);
        PlayerPrefs.SetInt("ThirdPrice", 100000);
        PlayerPrefs.SetInt("ForthPrice", 500000);
        PlayerPrefs.SetInt("FifthPrice", 1000000);
        PlayerPrefs.SetInt("SixthPrice", 5000000);
        PlayerPrefs.SetInt("SeventhPrice", 10000000);

        btn.enabled = true;
        secondbtn.enabled = false;

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
            dogbackground.color = open;

        }	
        if(money<firstprice)
        {
            btn.enabled = false;
            dogbackground.color = close;
        }

        if(money>secondprice)
        {
            secondbtn.enabled = true;
            myulchbackground.color = open;

        }
        else if(money<secondprice)
        {
            secondbtn.enabled = false;
            myulchbackground.color = close;
        }

        if(money>thirdprice)
        {
            yapsapbtn.enabled = true;
            yapsapbackground.color = open;
        }
        else if(money<thirdprice)
        {
            yapsapbtn.enabled = false;
            yapsapbackground.color = close;
        }
        if(money>forthprice)
        {
            Dungchibtn.enabled = true;
            dungchbackground.color = open;
        }
        else if(money<forthprice)
        {
            Dungchibtn.enabled = false;
            dungchbackground.color = close;
        }
        if(money>fifthprice)
        {
            myungsasubtn.enabled = true;
            myungsasubackground.color = open;
        }
        else if(money<fifthprice)
        {
            myungsasubtn.enabled = false;
            myungsasubackground.color = close;
        }
        if(money>sixthprice)
        {
            skatebtn.enabled = true;
            skatebackground.color = open;
        }
        else if(money<sixthprice)
        {
            skatebtn.enabled = false;
            skatebackground.color = close;
        }
        if(money>seventhprice)
        {
            godhbtn.enabled = true;
            godhbackground.color = open;
        }
        else if(money<seventhprice)
        {

            godhbtn.enabled = false;
            godhbackground.color = close;
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
        dogpc = 10000 + 200 * (firstplus+1);
        dogprice = dogpc.ToString();
        firstprice = ulong.Parse(dogprice);
        if(moneyu.money>=firstprice)
        {
			
            dogLevel++;
            PlayerPrefs.SetInt("FirstPrice", dogpc);
            PlayerPrefs.SetInt("DogLevel", dogLevel);

            moneyu.money = moneyu.money - firstprice;
            dogmoneyspeed += 2;
            moneyu.moneyspeed += dogmoneyspeed;

            btn_text.fontSize = 10;
            btn_text.text = "비용:" + dogprice + "\n" + "초당:" + dogmoneyspeed+"원";
            dog_text.text = "몽실이 LV" + dogLevel;

        }
        else if(moneyu.money<firstprice)
        {
            firstplus -= dogLevel;
        }
        //스트링으로 바꿔서?
        dog.active = true;

        if(dogLevel>=10)
        {
            myulchclose.active = false;

        }

    }   

    public void secondbtnClick()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
        myulchiLevel = PlayerPrefs.GetInt("MyulchLevel", 0);
        myulchplus = myulchplus + myulchiLevel;
        myulchpc = (10000 + 200 * (myulchplus))*5;
        myulchprice = myulchpc.ToString();
        secondprice = ulong.Parse(myulchprice);
        if (moneyu.money >= secondprice)
        {
            myulchiLevel++;
            PlayerPrefs.SetInt("SecondPrice", myulchpc);
            PlayerPrefs.SetInt("MyulchLevel", myulchiLevel);
            myulchmoneyspeed += 10;
            moneyu.money = moneyu.money - secondprice;
            moneyu.moneyspeed = moneyu.moneyspeed + myulchmoneyspeed;
            myulchbtn_text.fontSize = 10;
            myulchbtn_text.text = "비용:" + myulchprice + "\n" + "초당:" + myulchmoneyspeed+"원";
            myulch_text.text = "멸치 LV" + myulchiLevel;

        }
        else if (moneyu.money < secondprice)
        {
            myulchplus -= myulchiLevel;
        }

        myulchi.active = true;
        if(myulchiLevel>=10)
        {
            yapsapclose.active = false;
        }
    }

    public void YapsapbtnClick()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
        yapsapLevel = PlayerPrefs.GetInt("YapsapLevel", 0);
        yapsapplus = yapsapplus + yapsapLevel;
        yapsappc = (10000 + 200 * (yapsapplus)) * 10;
        yapsapprice = yapsappc.ToString();
        thirdprice = ulong.Parse(yapsapprice);
        if (moneyu.money >= thirdprice)
        {
            yapsapLevel++;
            PlayerPrefs.SetInt("ThirdPrice", yapsappc);
            PlayerPrefs.SetInt("YapsapLevel", yapsapLevel);
            yapsapmoneyspeed += 20;
            moneyu.money = moneyu.money - thirdprice;
            moneyu.moneyspeed = moneyu.moneyspeed + yapsapmoneyspeed;
            yapsapbtn_text.fontSize = 10;
            yapsapbtn_text.text = "비용:" + yapsapprice + "\n" + "초당:" + yapsapmoneyspeed+"원";
            yapsap_text.text = "얍삽이 LV" + yapsapLevel;

        }
        else if (moneyu.money < thirdprice)
        {
            yapsapplus -= yapsapLevel;
        }
        yapsap.active = true;
        if(yapsapLevel>=10)
        {
            dungchclose.active = false;
        }
    }
    public void dungchibtnClick()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
        dungchiLevel = PlayerPrefs.GetInt("DungchiLevel", 0);
        dungchiplus = dungchiplus + dungchiLevel;
        dungchipc = (10000 + 200 * (dungchiplus)) * 50;
        dungchiprice = dungchipc.ToString();
        forthprice = ulong.Parse(dungchiprice);
        if (moneyu.money >= forthprice)
        {
            dungchiLevel++;
            PlayerPrefs.SetInt("ForthPrice", dungchipc);
            PlayerPrefs.SetInt("DungchiLevel", dungchiLevel);
            dungchimoneyspeed += 50;
            moneyu.money = moneyu.money - forthprice;
            moneyu.moneyspeed = moneyu.moneyspeed + dungchimoneyspeed;
            dungchibtn_text.fontSize = 10;
            dungchibtn_text.text = "비용:" + dungchiprice + "\n" + "초당:" + dungchimoneyspeed+"원";
            dungchi_text.text = "덩치 LV" + dungchiLevel;
        }
        else if (moneyu.money < forthprice)
        {
          dungchiplus -= dungchiLevel;
        }
        dungchi.active = true;
        if(dungchiLevel>=10)
        {
            myungsasuclose.active = false;
        }
    }
    public void myungsasubtnClick()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
        myungsasuLevel = PlayerPrefs.GetInt("MyungsasuLevel", 0);
        myungsasuplus = myungsasuplus + myungsasuLevel;
        myungsasupc = (10000 + 200 * (myungsasuplus)) * 100;
        myungsasuprice = myungsasupc.ToString();
        fifthprice = ulong.Parse(myungsasuprice);
        if (moneyu.money >= fifthprice)
        {
            myungsasuLevel++;
            PlayerPrefs.SetInt("FifthPrice", myungsasupc);
            PlayerPrefs.SetInt("MyungsasuLevel", myungsasuLevel);
            myungsasumoneyspeed += 100;
            moneyu.money = moneyu.money - fifthprice;
            moneyu.moneyspeed = moneyu.moneyspeed + myungsasumoneyspeed;
            myungsasubtn_text.fontSize = 10;
            myungsasubtn_text.text = "비용:" + myungsasuprice + "\n" + "초당:" + myungsasumoneyspeed+"원";
            myungsasu_text.text = "명사수 LV" + myungsasuLevel;
        }
        else if (moneyu.money < fifthprice)
        {
            myungsasuplus -= myungsasuLevel;
        }
        myungsasu.active = true;
        if(myungsasuLevel>=10)
        {
            skateclose.active = false;
        }
    }
    public void skatebtnClick()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
        skateLevel = PlayerPrefs.GetInt("SkateLevel", 0);
        skateplus = skateplus + skateLevel;
        skatepc = (10000 + 200 * (skateplus)) * 500;
        skateprice = skatepc.ToString();
        sixthprice = ulong.Parse(skateprice);
        if (moneyu.money >= sixthprice)
        {
            skateLevel++;
            PlayerPrefs.SetInt("SixthPrice", skatepc);
            PlayerPrefs.SetInt("SkateLevel", skateLevel);
            skatemoneyspeed += 500;
            moneyu.money = moneyu.money - sixthprice;
            moneyu.moneyspeed = moneyu.moneyspeed + skatemoneyspeed;
            skatebtn_text.fontSize = 10;
            skatebtn_text.text = "비용:" + skateprice + "\n" + "초당:" + skatemoneyspeed+"원";
            skate_text.text = "스케이트녀 LV" + skateLevel;

        }
        else if (moneyu.money < sixthprice)
        {
            skateplus -= skateLevel;
        }
        skate.active = true;
        if(skateLevel>=10)
        {
            godhclose.active = false;
        }
    }
    public void godhbtnClick()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
        godhLevel = PlayerPrefs.GetInt("GodhLevel", 0);
        godhplus = godhplus + godhLevel;
        godhpc = (10000 * 200 * (godhplus)) * 1000;
        godhprice = godhpc.ToString();
        seventhprice = ulong.Parse(godhprice);
        if (moneyu.money >= seventhprice)
        {
            godhLevel++;
            PlayerPrefs.SetInt("SeventhPrice", godhpc);
            PlayerPrefs.SetInt("GodhLevel", godhLevel);
            godhmoneyspeed += 1000;
            moneyu.money = moneyu.money - seventhprice;
            moneyu.moneyspeed = moneyu.moneyspeed + godhmoneyspeed;
            godhbtn_text.fontSize = 10;
            godhbtn_text.text = "비용:" + godhprice + "\n" + "초당:" + godhmoneyspeed+"원";
            godh_text.text = "갓형욱 LV" + godhLevel;
        }
        else if (moneyu.money < seventhprice)
        {
            godhplus -= godhLevel;
        }
        godh.active = true;

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
