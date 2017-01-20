using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseButtonEvent : MonoBehaviour {

	//Image bgimg;
	public Sprite bg;
	//각 배경에 해당하는 가격
	int[] BG_Price = new int[6] { 3000, 13000, 30000, 230000, 1500000, 9000000 };
	public int money=0;

	/*
	1. 집 살 돈의 유무
		a.유 : 버튼 활성화, 아이콘 컬러, HOUSEobj 배경색상 밝음
		b.무 : 버튼 비활성화, 아이콘 흑백

	2. 집을 구매 한 경우
		--> BUY --> 

	3. 
	*/
	// Use this for initialization
	void Start () {

	}

	void Update () {
		Moneyupdate MU = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
		money = MU.money;

	}
	public void setBG (int btn){
		switch (btn) {
		case 0:
			HouseMoneyEvent (btn);
			HouseChangeBG (btn);
			break;
		case 1:
			HouseMoneyEvent (btn);
			HouseChangeBG (btn);
			break;
		case 2:
			HouseMoneyEvent (btn);
			HouseChangeBG (btn);
			break;
		case 3:
			HouseMoneyEvent (btn);
			HouseChangeBG (btn);
			break;
		case 4:
			HouseMoneyEvent (btn);
			HouseChangeBG (btn);
			break;
		case 5:
			HouseMoneyEvent (btn);
			HouseChangeBG (btn);
			break;
		}
		//배경 오브젝트의 스프라이트를 변경
		GameObject.Find ("Background").GetComponent<Image> ().sprite = bg;
	}
	public void HouseCheck(){
	
	}
	public void HouseMoneyEvent(int sel_BG){
		//MoneyManager에서 House의 가격에 따라 MoneyUpdate
		Moneyupdate MU= GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
		MU.money -= BG_Price[sel_BG];
		Debug.Log (money);
	}
	public void HouseChangeBG(int sel_BG){
		//리소스에서 배경파일 로드
		bg = Resources.Load<Sprite> ("bg_img/bg_"+sel_BG) as Sprite;
		Debug.Log ("btn "+sel_BG+"_onClick");
	}
}
