using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseButtonEvent : MonoBehaviour {
	//total size
	const int SIZE=7;
	//Image bgimg;
	public Sprite bg;
	//house, icon img, btn obj
	public GameObject[] houseObj = new GameObject[SIZE];
	public GameObject[] imgObj = new GameObject[SIZE];
	public GameObject[] btnObj = new GameObject[SIZE];
	//각 배경에 해당하는 가격
	ulong[] BG_Price = new ulong[SIZE] { 13000, 53000, 230000, 1330000, 7500000,
		29000000, 100000000 };
	//배경 구매 완료한 경우 false
	public bool[] BG_BuyEnable = new bool[SIZE] {true, true, true, true, true, 
		true, true}; 
	public ulong money=0;
	/*
	1. 집을 살 만큼의 돈 유무
		a.유 : BUY 버튼 활성화, 아이콘 컬러,  해당 항목(행) 배경색상 밝음  ok
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
	void Awake(){
		for (int i = 0; i < SIZE; i++) {
			//House오브젝트
			houseObj[i] = null;
			imgObj[i] = null;
		}

	}
	void Start () {
	//	for (int i = 0; i < 7; i++) {
	//		btnObj[i] = GameObject.Find ("HouseButton (" + i + ")").gameObject;
			//btnObj[i].SetActive (false);	
	//	}

		for (int i = 0; i < SIZE; i++) {
			//House,iconimg,btn오브젝트
			houseObj[i] = GameObject.Find ("House ("+i+")").gameObject;
			imgObj[i] = houseObj[i].transform.FindChild("Image").gameObject;
			btnObj[i] = houseObj[i].transform.FindChild("HouseButton ("+i+")").gameObject;
		}
	}

	void Update () {
		Moneyupdate MU= GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
		money = MU.money;
		HouseCheck (money);
	}
	public void HouseCheck(ulong money){
		for (int i = 0; i < SIZE; i++) {
			//돈 있을 때,
			if (money > BG_Price [i]) {
				//이미 구매한 경우
				if (BG_BuyEnable [i] == false) {
					//text-->구매완료 
					//houseObj[i].transform.FindChild
					//어둡게
					houseObj[i].GetComponent<Image> ().color = new Color (0.6f, 0.6f, 0.6f, 1);
					//흑백아이콘
					imgObj[i].GetComponent<Image> ().sprite = Resources.Load<Sprite> ("bg_icon/sel_bg_icon_" + i) as Sprite;
					//버튼 비활성화
					btnObj[i].SetActive(false);
				}
				//돈도 있고, 안샀다면,
				else {
					//밝게
					//GameObject.Find ("House (" + i + ")").GetComponent<Image> ().color = new Color (154 / 255, 154 / 255, 154 / 255, 154 / 255);
					houseObj[i].GetComponent<Image> ().color = new Color (154 / 255, 154 / 255, 154 / 255, 154 / 255);
					//컬러아이콘
					imgObj[i].GetComponent<Image> ().sprite = Resources.Load<Sprite> ("bg_icon/bg_icon_" + i) as Sprite;
					//버튼 활성화
					btnObj[i].SetActive(true);

				}
			}
			//살 돈 없을 때,
			else {
				//어둡게
				houseObj[i].GetComponent<Image> ().color = new Color (0.6f, 0.6f, 0.6f, 1);
				//흑백아이콘
				imgObj[i].GetComponent<Image> ().sprite = Resources.Load<Sprite> ("bg_icon/sel_bg_icon_" + i) as Sprite;
				//살 돈 없고, 이미 구매한 경우
				if (BG_BuyEnable[i]==false) {
					//버튼 비활성화
					btnObj[i].SetActive(false);
				} 
				//아직 구매 안한 경우
				else {
					//버튼 비활성화
					btnObj[i].SetActive(false);
				}	
			}
		}
	}

	//Button onClick event
	public void setBG (int btn){
		//if (money > BG_Price [btn]) {
			HouseMoneyEvent (btn);
			HouseChangeBG (btn);
			changeBGBuyEnable (btn);
			//배경 오브젝트의 스프라이트를 변경
			GameObject.Find ("Background").GetComponent<Image> ().sprite = bg;
		//}
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
	//구매한 경우 false로 표시 해줌
	public void changeBGBuyEnable(int sel_BG){
		BG_BuyEnable [sel_BG] = false;
	}
	//나중에 판매할 경우 이 함수 사용
	public void btnEnable(int i){
		btnObj[i].SetActive(true);
	}
}	
