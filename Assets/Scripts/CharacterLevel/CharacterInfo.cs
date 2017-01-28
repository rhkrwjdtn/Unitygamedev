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
    public ulong TouchMoney = 0;

    public ulong BonusgobTouchmoney = 0;

    public float bntcm = 0;

    public Text LevelText = null;
    public Text LevelupbtnText = null;
    public Text NowClickWonTx = null;
    public Text EmployBonusTx = null;
    public Text StockBonusTx = null;
    public Text GFBonusTx = null;

    public bool[] GFTruetoFalse = new bool[6];

    public float[] GFgob = new float[6] { 1.3f, 1.5f, 2.0f, 3.0f, 5.0f, 8.0f };

    public string GFTransform = null;

	// Use this for initialization
	void Start () {
	if(btn==null)
        {
            btn = gameObject.GetComponent<UnityEngine.UI.Button>();

        }
       // PlayerPrefs.SetInt("JugallumLevel", JugallumLev);
        LevelupbtnText.text = "레벨:" + JugallumLev;

        NowClickWonTx.text = "0원 -> 0원";
        EmployBonusTx.text = "0%";
        StockBonusTx.text = "0%";
        GFBonusTx.text = "0%";

	}
	
	// Update is called once per frame
	void Update () {

        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
        GrilFriendManager gf = GameObject.Find("GirlFriendManager").GetComponent<GrilFriendManager>();
        for (int i = 0; i < 6; i++)
        {
            if(gf.GFExist[i] == true)
            {
                bntcm = (float)moneyu.touchspeed * GFgob[i];
                GFTransform = bntcm.ToString();
                moneyu.touchspeed = ulong.Parse(GFTransform);
                GFTruetoFalse[i] = true;
            }
            else if(gf.GFExist[i]==false && GFTruetoFalse[i]==true)
            {

            }
        }
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
