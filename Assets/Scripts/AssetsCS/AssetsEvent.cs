using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssetsEvent : MonoBehaviour {
	public const int SIZE=7;
	public Sprite bg;
	public GameObject Asset_housepopup;
	public GameObject[] Asset_houseObj = new GameObject[SIZE];
	public GameObject[] Asset_imgObj = new GameObject[SIZE];
	public GameObject[] Asset_btnObj = new GameObject[SIZE];
	public bool[] Asset_BG_BuyList = new bool[SIZE];

	public Moneyupdate MU;
	public HouseButtonEvent myBGList; //connect myBGList
	/*
	2. 아이템(인벤토리)
		a. 집, 땅, 국가 3가지를 탭 형식으로 구성
			ㄱ. 구매한 것 : SELL 버튼 활성화, 아이콘 컬러,  해당 항목(행) 배경 색 밝음,  초기 구매가와 현재 판매가 표기(비교를 위해)
				-- SELL 버튼 onClinck, 
					>> 현재 배경을 기본 배경(0원)으로 변경, 현재 판매가 만큼 +money, 해당 집을 미구매한 집으로 변경
			ㄴ. 미구매한 것 : 아이콘 흑백, SELL 글씨 색상 흐리게, SELL 버튼 비활성화
	*/
	void Awake(){
		for (int i = 0; i < SIZE; i++) {
			Asset_houseObj[i] = null;
			Asset_imgObj[i] = null;
			Asset_btnObj[i] = null;
			Asset_BG_BuyList [i] = myBGList.BG_BuyList [i];
		}
	}

	public void Asset_HouseInitiate(){
		if (Asset_housepopup.activeSelf == true) {
			for (int i = 0; i < SIZE; i++) {
				//House,iconimg,btn오브젝트
				Asset_houseObj [i] = GameObject.Find ("House"+i).gameObject;
				Asset_imgObj [i] = Asset_houseObj [i].transform.FindChild ("Image").gameObject;
				Asset_btnObj [i] = Asset_houseObj [i].transform.FindChild ("Button").gameObject;
				Asset_btnObj [i].transform.GetChild(0).GetComponent<Text> ().text = "SELL";
			}
		}
	}

	void Update () {
		if(Asset_housepopup.activeSelf==true)
			Asset_HouseCheck ();
	}

	public void Asset_HouseCheck(){
		for (int i = 0; i < SIZE; i++) {
			//이미 구매한 경우
			if (myBGList.BG_BuyList [i] == false) {
				Asset_houseObj [i].transform.GetChild (1).GetComponent<Text> ().text = "구매가:"+myBGList.BG_Price[i]+"원\n임시...:"+myBGList.BG_Price;
				//밝게
				Asset_houseObj[i].GetComponent<Image> ().color = new Color (154 / 255, 154 / 255, 154 / 255, 154 / 255);
				//컬러아이콘
				Asset_imgObj[i].GetComponent<Image> ().sprite = Resources.Load<Sprite> ("bg_icon/bg_icon_" + i) as Sprite;
				//버튼 활성화
				Asset_btnObj[i].SetActive(true);

				}
			else {
				Asset_houseObj [i].transform.GetChild (1).GetComponent<Text> ().text = "미구매";
				//어둡게
				Asset_houseObj [i].GetComponent<Image> ().color = new Color (0.6f, 0.6f, 0.6f, 1);
				//컬러
				Asset_imgObj [i].GetComponent<Image> ().sprite = Resources.Load<Sprite> ("bg_icon/bg_icon_" + i) as Sprite;
				//버튼 비활성화
				Asset_btnObj [i].SetActive (false);

			}
			
		}
	}

	//Button onClick event
	public void Asset_setBG (int btn){
		//if (money > BG_Price [btn]) {
		Asset_HouseMoneyEvent (btn);
		Asset_HouseChangeBG ();
		Asset_changeBGBuyEnable (btn);
		//배경 오브젝트의 스프라이트를 변경
		GameObject.Find ("Background").GetComponent<Image> ().sprite = bg;
		//}
	}
	public void Asset_HouseMoneyEvent(int sel_BG){
		//MoneyManager에서 House의 가격에 따라 MoneyUpdate
		//Moneyupdate MU= GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
		MU.money += myBGList.BG_Price[sel_BG];
	}
	public void Asset_HouseChangeBG(){
		//리소스에서 배경파일 로드
		bg = Resources.Load<Sprite> ("bg_img/bg_default") as Sprite;
	}
	//구매한 경우 false로 표시 해줌
	public void Asset_changeBGBuyEnable(int sel_BG){
		myBGList.BG_BuyList [sel_BG] = !myBGList.BG_BuyList [sel_BG];
	}
	//나중에 판매할 경우 이 함수 사용
	public void Asset_btnEnable(int i){
		Asset_btnObj[i].SetActive(true);
	}
}	
