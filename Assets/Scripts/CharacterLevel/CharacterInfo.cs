using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour {

    public UnityEngine.UI.Button btn;
	public ulong ClickMoney = 0;
    public ulong JugallumLev = 1;

    public ulong NextLevelPrice = 0;
    public ulong TwoNextLevelPrice = 0;
    public ulong TouchMoney = 5;
    public ulong TouchMoneyGobhagiBonusPersent = 1;

    public ulong BonusgobTouchmoney = 0;

    public float bntcm = 0;
    public float GFBonus = 1;
    public float totalClickmoney = 0;
    public int sosoodelete = 0;
    public int noretry = 0;
    
    public Text LevelText = null;
    public Text LevelupbtnText = null;
    public Text NowClickWonTx = null;
    public Text EmployBonusTx = null;
    public Text StockBonusTx = null;
    public Text GFBonusTx = null;

    public bool[] GFTruetoFalse = new bool[6];

    public int[] GFbg = new int[6] { 30, 50, 100, 300, 500, 800 };
    public float[] GFgob = new float[6] { 1.3f, 1.5f, 2.0f, 3.0f, 5.0f, 8.0f };
    public float[] GFnonugi = new float[6] {10/13f, 10/15f, 1/2f, 1/3f, 1/5f, 1/8f };

    public string GFTransform = null;
    public string ToTalTransform = null;
	// Use this for initialization

	void Start () {
	if(btn==null)
        {
            btn = gameObject.GetComponent<UnityEngine.UI.Button>();

        }

    }
	
	// Update is called once per frame
	void Update () {

        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
        GrilFriendManager gf = GameObject.Find("GirlFriendManager").GetComponent<GrilFriendManager>();
        for (int i = 0; i < 6; i++)
        {
            if(gf.GFExist[i] == true&&noretry==0)
            {

                bntcm = (float)moneyu.touchspeed * GFgob[i];
                GFBonus = GFgob[i];
                sosoodelete =(int) bntcm;
                GFTransform = sosoodelete.ToString();
                moneyu.touchspeed = ulong.Parse(GFTransform);
                GFTruetoFalse[i] = true;
                noretry++;
                GFBonusTx.text =""+GFbg[i]+"%";
            }
            else if(gf.GFExist[i]==false && GFTruetoFalse[i]==true)
            {
                bntcm = (float)moneyu.touchspeed * GFnonugi[i];
                Debug.Log(GFnonugi[0]);
                GFBonus = 1;
                sosoodelete = (int)bntcm;
                GFTransform = sosoodelete.ToString();
                moneyu.touchspeed = ulong.Parse(GFTransform);
                GFTruetoFalse[i] = false;
                noretry--;
                GFBonusTx.text = "0%";
            }
        }
        NowClickWonTx.text = TouchMoney + "원 ->" + moneyu.touchspeed + "원";


    }
    public void btnClick()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();

        TouchMoney = TouchMoney + 100;

        NextLevelPrice = (JugallumLev * JugallumLev * JugallumLev * JugallumLev) * 6;
        TwoNextLevelPrice = ((JugallumLev + 1) * (JugallumLev + 1) * (JugallumLev + 1) * (JugallumLev + 1)) * 6;
        if (moneyu.money > NextLevelPrice)
        {
            moneyu.money=moneyu.money - NextLevelPrice;
            JugallumLev++;
            totalClickmoney = (float)TouchMoney * GFBonus;//기업 인수 보너스 알바 보너스 추가 하기
            sosoodelete = (int)totalClickmoney;
            ToTalTransform = sosoodelete.ToString();
            moneyu.touchspeed = ulong.Parse(ToTalTransform);
            LevelText.text = "둥신 LV" + JugallumLev;
            LevelupbtnText.fontSize = 8;
            LevelupbtnText.text = "비용:" + TwoNextLevelPrice + "\n" + "+" + "100" + "/클릭";
            NowClickWonTx.text = TouchMoney+"원 ->"+moneyu.touchspeed+"원";
        }
        else if(moneyu.money<NextLevelPrice)
        {
            TouchMoney = TouchMoney - 100;

        }

    }

}
