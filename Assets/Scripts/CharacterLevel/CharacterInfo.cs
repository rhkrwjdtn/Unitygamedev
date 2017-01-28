using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour {

    public UnityEngine.UI.Button btn;
	public ulong ClickMoney = 0;
    public int JugallumLev = 0;
    public Text LevelupbtnText = null;
    public Text NowClickWonTx = null;
    public Text EmployBonusTx = null;
    public Text StockBonusTx = null;
    public Text GFBonusTx = null;

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
		ClickMoney = moneyu.touchspeed;
        	
	}
    public void btnClick()
    {

    }

}
