using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseButtonEvent : MonoBehaviour {

	//Image bgimg;
	public Sprite bg;
	//각 배경에 해당하는 가격
	ulong[] BG_Price = new ulong[6] { 3000, 13000, 30000, 230000, 1500000, 9000000 };
	public ulong money=0;

	/*
	1. 집을 살 만큼의 돈 유무
		a.유 : BUY 버튼 활성화, 아이콘 컬러,  해당 항목(행) 배경색상 밝음
			-- BUY 버튼 onClick,
				>> BUY 글씨 색상 흐리게 변경,
				>> 아이템(인벤토리)의 집 탭에 구매한 집으로 변경,
		b.무 : 아이콘 흑백, BUY 글씨 색상 흐리게, BUY 버튼 비활성화

	2. 아이템(인벤토리)
		a. 집, 땅, 국가 3가지를 탭 형식으로 구성
			ㄱ. 구매한 것 : SELL 버튼 활성화, 아이콘 컬러,  해당 항목(행) 배경 색 밝음,  초기 구매가와 현재 판매가 표기(비교를 위해)
				-- SELL 버튼 onClinck, 
					>> 현재 배경을 기본 배경(0원)으로 변경, 현재 판매가 만큼 +money, 해당 집을 미구매한 집으로 변경
			ㄴ. 미구매한 것 : 아이콘 흑백, SELL 글씨 색상 흐리게, SELL 버튼 비활성화
	*/
	// Use this for initialization
	void Start () {

	}

	void Update () {
		Moneyupdate MU = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
		money = MU.money;

	}
	public void setBG (int btn){
		HouseMoneyEvent (btn);
		HouseChangeBG (btn);
		//배경 오브젝트의 스프라이트를 변경
		GameObject.Find ("Background").GetComponent<Image> ().sprite = bg;

		/*
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

		}*/
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
