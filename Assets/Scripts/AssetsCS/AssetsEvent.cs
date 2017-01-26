using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssetsEvent : MonoBehaviour {

	//houseAssets
	public const int houseSIZE=7;
	public Sprite bg;
	public GameObject Asset_housePopup;//connect tab0
	public GameObject[] Asset_houseObj = new GameObject[houseSIZE];
	public GameObject[] Asset_houseImgObj = new GameObject[houseSIZE];
	public GameObject[] Asset_houseBtnObj = new GameObject[houseSIZE];
	//countryAssets
	public const int countrySIZE=13;
	public GameObject Asset_countryPopup;//connect tab1
	public GameObject[] Asset_countryObj = new GameObject[countrySIZE];
	public GameObject[] Asset_countryImgObj = new GameObject[countrySIZE];
	public GameObject[] Asset_countryBtnObj = new GameObject[countrySIZE];


	//AssetsManager에서 이 두 cs를 묶어줘야함.
	public Moneyupdate MU;
	public HouseButtonEvent myBGList; //connect HouseManager
	public CountryButtonEvent myFlagList; //connect CountryManager
	/*
	2. 아이템(인벤토리)
		a. 집, 땅, 국가 3가지를 탭 형식으로 구성
			ㄱ. 구매한 것 : SELL 버튼 활성화, 아이콘 컬러,  해당 항목(행) 배경 색 밝음,  초기 구매가와 현재 판매가 표기(비교를 위해)
				-- SELL 버튼 onClinck, 
					>> 현재 배경을 기본 배경(0원)으로 변경, 현재 판매가 만큼 +money, 해당 집을 미구매한 집으로 변경
			ㄴ. 미구매한 것 : 아이콘 흑백, SELL 글씨 색상 흐리게, SELL 버튼 비활성화
	*/

	void Awake(){
		for (int i = 0; i < houseSIZE; i++) {
			Asset_houseObj[i] = null;
			Asset_houseImgObj[i] = null;
			Asset_houseBtnObj[i] = null;
		}
		for (int i = 0; i < countrySIZE; i++) {
			Asset_countryObj[i] = null;
			Asset_countryImgObj[i] = null;
			Asset_countryBtnObj[i] = null;
		}
	}
	//connect tabbutton0
	public void Asset_HouseInitiate(){
		if (Asset_housePopup.activeSelf == true) {
			for (int i = 0; i < houseSIZE; i++) {
				//House,iconimg,btn오브젝트
				Asset_houseObj [i] = GameObject.Find ("House"+i).gameObject;
				Asset_houseObj [i].transform.GetChild (1).GetComponent<Text> ().fontSize = 10;
				Asset_houseImgObj [i] = Asset_houseObj [i].transform.FindChild ("Image").gameObject;
				Asset_houseBtnObj [i] = Asset_houseObj [i].transform.FindChild ("Button").gameObject;
				Asset_houseBtnObj [i].transform.GetChild(0).GetComponent<Text> ().text = "SELL";
			}
		}
	}
	//connect tabbutton1
	public void Asset_CountryInitiate(){
		if (Asset_countryPopup.activeSelf == true) {
			for (int i = 0; i < countrySIZE; i++) {
				//Country,iconimg,btn오브젝트
				Asset_countryObj [i] = GameObject.Find ("Country ("+i+")").gameObject;
				Asset_countryObj [i].transform.GetChild (1).GetComponent<Text> ().fontSize = 10;
				Asset_countryImgObj [i] = Asset_countryObj [i].transform.FindChild ("Image").gameObject;
				Asset_countryBtnObj [i] = Asset_countryObj [i].transform.FindChild ("Button").gameObject;
				Asset_countryBtnObj [i].transform.GetChild(0).GetComponent<Text> ().text = "SELL";
			}
		}
	}

	void Update () {
		if(Asset_housePopup.activeSelf==true)
			Asset_HouseCheck ();
		if(Asset_countryPopup.activeSelf==true)
			Asset_CountryCheck ();
	}

	public void Asset_HouseCheck(){
		for (int i = 0; i < houseSIZE; i++) {
			//이미 구매한 경우
			if (myBGList.BG_BuyList [i] == false) {
				Asset_houseObj [i].transform.GetChild (1).GetComponent<Text> ().text = "구매가:"+myBGList.BG_Price[i]+"원\n임시...:"+myBGList.BG_Price[i]*2+"원";
				//밝게
				Asset_houseObj[i].GetComponent<Image> ().color = new Color (154 / 255, 154 / 255, 154 / 255, 154 / 255);
				//컬러아이콘
				Asset_houseImgObj[i].GetComponent<Image> ().sprite = Resources.Load<Sprite> ("bg_img/bg"+i) as Sprite;//("bg_icon/bg_icon_" + i) as Sprite;
				//버튼 활성화
				Asset_houseBtnObj[i].SetActive(true);

			}
			else {
				Asset_houseObj [i].transform.GetChild (1).GetComponent<Text> ().text = "미구매";
				//어둡게
				Asset_houseObj [i].GetComponent<Image> ().color = new Color (0.6f, 0.6f, 0.6f, 1);
				//흑백
				Asset_houseImgObj [i].GetComponent<Image> ().sprite = Resources.Load<Sprite> ("bg_img/gray_bg"+i) as Sprite;//bg_icon/sel_bg_icon_" + i) as Sprite;
				//버튼 비활성화
				Asset_houseBtnObj [i].SetActive (false);

			}

		}
	}
	public void Asset_CountryCheck(){
		for (int i = 0; i < countrySIZE; i++) {
			//이미 구매한 경우
			if (myFlagList.BuyList [i] == false) {
				//구매가, 밝게, 컬러아이콘, 버튼활성화 
				Asset_countryObj[i].transform.GetChild(1).GetComponent<Text>().text =  "구매가:"+(i+1)*5+"조 원\n(임시)가:"+myFlagList.Price[i]*2+"원";
				Asset_countryObj [i].GetComponent<Image> ().color = new Color (154 / 255, 154 / 255, 154 / 255, 154 / 255);
				Asset_countryImgObj[i].GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Flag/flag ("+i+")") as Sprite;
				Asset_countryBtnObj[i].SetActive(true);

			}
			//돈도 있고, 안샀다면,
			else {
				//미구매 , 어둡게, 흑백아이콘, 버튼비활성화
				Asset_countryObj [i].transform.GetChild (1).GetComponent<Text> ().text = "미구매";
				Asset_countryObj[i].GetComponent<Image> ().color = new Color (0.6f, 0.6f, 0.6f, 1);
				Asset_countryImgObj[i].GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Flag/gray_flag ("+i+")") as Sprite;
				Asset_countryBtnObj[i].SetActive(false);


			}
		}
	}

	//connect Button onClick event
	public void Asset_setBG (int btn){
		Moneyupdate MU= GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
		HouseButtonEvent HE= GameObject.Find("HouseManager").GetComponent<HouseButtonEvent>();
		MU.money += HE.BG_Price[btn]*2;
		HE.changeBGBuyEnable (btn);
		//기본배경으로 초기화
		GameObject.Find ("Background").GetComponent<Image> ().sprite = Resources.Load<Sprite> ("bg_img/bg99") as Sprite;
		HE.Selected_BG = (int)99;
	}
	//connect Button onClick event
	public void Asset_CountryOnClick (int btn){
		Moneyupdate MU= GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
		CountryButtonEvent CE= GameObject.Find("CountryManager").GetComponent<CountryButtonEvent>();
		MU.money += CE.Price[btn]*2;
		CE.countryDel (btn);
		CE.changeBuyEnable (btn);
	}
}	
