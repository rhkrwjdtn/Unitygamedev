using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RebirthManager : MonoBehaviour {
   
    public int msrandomnum = 0;
    public int ckrandomnum = 0;
    public int totalrandum = 0;
    public string msstring = null;
    public string ckstring = null;
    public ulong msmoneyspeed = 0;
    public ulong cktouchmoney = 0;
    public GameObject popup = null;
    public Button rebirthbtn = null;
    public Text potcnt_text = null;
    public GameObject[] Alramspoon = new GameObject[7];
    public GameObject AlramPopup = null;
  
	public int RebirthCount=0;  //업적에 쓰임
	// Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        IconManager potioncnt = GameObject.Find("IconManager").GetComponent<IconManager>();
        potcnt_text.text = "환생물약:" + potioncnt.rebirthpotion + "개";
        if (potioncnt.rebirthpotion == 0)
        {
            rebirthbtn.interactable = false;
        }
        if(potioncnt.rebirthpotion!=0)
        {
            rebirthbtn.interactable = true;
        }

    }
    public void rebirthbtnClick()
    {
        IconManager potioncnt = GameObject.Find("IconManager").GetComponent<IconManager>();
		RebirthCount++;
        if (potioncnt.rebirthpotion != 0)
        {
            totalrandum = Random.Range(0, 10000);
            if (totalrandum <= 4000)
            {
                gmfrrebirth();
                Alramspoon[0].active = true;

            }
            else if (totalrandum <= 6500 && totalrandum > 4000)
            {
                plasticrebirth();
                Alramspoon[1].active = true;
            }
            else if (totalrandum <= 8000 && totalrandum > 6500)
            {
                nokrebirth();
                Alramspoon[2].active = true;
            }
            else if (totalrandum <= 9000 && totalrandum > 8000)
            {
                dongrebirth();
                Alramspoon[3].active = true;
            }
            else if (totalrandum <= 9500 && totalrandum > 9000)
            {
                silverrebirth();
                Alramspoon[4].active = true;
            }
            else if (totalrandum <= 9800 && totalrandum > 9500)
            {
                goldrebirth();
                Alramspoon[5].active = true;
            }
            else if (totalrandum <= 10000 && totalrandum > 9800)
            {
                diarebirth();
                Alramspoon[6].active = true;
            }
            popup.active = false;
            potioncnt.rebirthpotion -= 1;
            AlramPopup.active = true;


        }

    }
    public void gmfrrebirth()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
        msrandomnum = Random.Range(0, 10000);
        ckrandomnum = Random.Range(0, 1000);//2월3일 이건 정해야댈듯?
        msstring = msrandomnum.ToString();
        ckstring = ckrandomnum.ToString();
        msmoneyspeed = ulong.Parse(msstring);
        cktouchmoney = ulong.Parse(ckstring);
        moneyu.moneyspeed = msmoneyspeed;
        moneyu.touchspeed = cktouchmoney;
        allrebirth(cktouchmoney);

    }
    public void plasticrebirth()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
        msrandomnum = Random.Range(10001, 100000);
        ckrandomnum = Random.Range(1000, 5000);
        msstring = msrandomnum.ToString();
        ckstring = ckrandomnum.ToString();
        msmoneyspeed = ulong.Parse(msstring);
        cktouchmoney = ulong.Parse(ckstring);
        moneyu.moneyspeed = msmoneyspeed;
        moneyu.touchspeed = cktouchmoney;
        allrebirth(cktouchmoney);

    }
    public void nokrebirth()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
        msrandomnum = Random.Range(100001, 1000000);
        ckrandomnum = Random.Range(5000, 10000);
        msstring = msrandomnum.ToString();
        ckstring = ckrandomnum.ToString();
        msmoneyspeed = ulong.Parse(msstring);
        cktouchmoney = ulong.Parse(ckstring);
        moneyu.moneyspeed = msmoneyspeed;
        moneyu.touchspeed = cktouchmoney;
        allrebirth(cktouchmoney);
    }
    public void dongrebirth()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
        msrandomnum = Random.Range(1000001, 10000000);
        ckrandomnum = Random.Range(10000, 50000);
        msstring = msrandomnum.ToString();
        ckstring = ckrandomnum.ToString();
        msmoneyspeed = ulong.Parse(msstring);
        cktouchmoney = ulong.Parse(ckstring);
        moneyu.moneyspeed = msmoneyspeed;
        moneyu.touchspeed = cktouchmoney;
        allrebirth(cktouchmoney);
    }
    public void silverrebirth()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
        msrandomnum = Random.Range(10000001, 100000000);
        ckrandomnum = Random.Range(50000, 100000);
        msstring = msrandomnum.ToString();
        ckstring = ckrandomnum.ToString();
        msmoneyspeed = ulong.Parse(msstring);
        cktouchmoney = ulong.Parse(ckstring);
        moneyu.moneyspeed = msmoneyspeed;
        moneyu.touchspeed = cktouchmoney;
        allrebirth(cktouchmoney);
    }
    public void goldrebirth()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
        msrandomnum = Random.Range(100000000, 1000000000);
        ckrandomnum = Random.Range(100000, 500000);
        msstring = msrandomnum.ToString();
        ckstring = ckrandomnum.ToString();
        msmoneyspeed = ulong.Parse(msstring);
        cktouchmoney = ulong.Parse(ckstring);
        moneyu.moneyspeed = msmoneyspeed;
        moneyu.touchspeed = cktouchmoney;
        allrebirth(cktouchmoney);

    }
    public void diarebirth()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
        msrandomnum = Random.Range(1000000001, 2000000000);
        ckrandomnum = Random.Range(500000, 1000000);
        msstring = msrandomnum.ToString();
        ckstring = ckrandomnum.ToString();
        msmoneyspeed = ulong.Parse(msstring);
        cktouchmoney = ulong.Parse(ckstring);
        moneyu.moneyspeed = msmoneyspeed;
        moneyu.touchspeed = cktouchmoney;
        allrebirth(cktouchmoney);
    }
    public void allrebirth(ulong cktouchmoney)
    {
        CharacterInfo character = GameObject.Find("CharacterManager").GetComponent<CharacterInfo>();
        EmploymentManager employ = GameObject.Find("EmployManager").GetComponent<EmploymentManager>();
        GrilFriendManager girl = GameObject.Find("GirlFriendManager").GetComponent<GrilFriendManager>();

        //여자친구 초기화

        for (int i = 0; i < 6; i++)
        {
            girl.GirlFriend[i].active = false;
            girl.GFExist[i] = false;
            girl.ison[i] = false;
            girl.Backgroundcl[i].color = girl.open;
            girl.btn_text[i].text = "사귀기";
            if (i != 5)
            {
                girl.ClosePopup[i].active = true;
            }
            character.GFTruetoFalse[i] = false;

        }

        //캐릭터 레벨 초기화
        character.noretry = 0;
        character.JugallumLev = 0;
        character.BeforeLevelPrice = 0;
        character.NextLevelPrice = 0;
        character.TwoNextLevelPrice = 10;
        character.TouchMoneyPlus = 0;
        character.TouchMoney = cktouchmoney;

        //고용하기 초기화
        for(int i=0;i<11;i++)
        {
            employ.EmployerLevel[i] = 0;
            employ.Employer[i].active = false;
            employ.moneyspeed[i] = employ.speedplus[i];
            employ.NextLevelPrice[i] = employ.StartLevelPrice[i];
            employ.TwoNextLevelPrice[i] = employ.StartLevelPrice[i];
            employ.plusmoney[i] = 0;
            if(i!=10)
            { employ.ClosePopup[i].active = true;
            }
            employ.btn_text[i].fontSize = 8;
            employ.btn_text[i].text = "비용:" + employ.TwoNextLevelPrice[i] + "\n" + "초당:" + employ.moneyspeed[i] + "원";
            employ.name_text[i].text = "" + employ.EmployerLevel[i];
        }
       
       

    }

}
