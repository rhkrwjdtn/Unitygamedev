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
	public ulong[] Asset_houseNowPrice = new ulong[houseSIZE];

	//countryAssets
	public const int countrySIZE=13;
	public GameObject Asset_countryPopup;//connect tab1
	public GameObject[] Asset_countryObj = new GameObject[countrySIZE];
	public GameObject[] Asset_countryImgObj = new GameObject[countrySIZE];
	public GameObject[] Asset_countryBtnObj = new GameObject[countrySIZE];
	public ulong[] Asset_countryNowPrice = new ulong[countrySIZE];

	//StockAssets
	public const int StockSIZE=9;
	public GameObject Asset_StockPopup;//connect tab1
	public GameObject[] Asset_StockObj = new GameObject[StockSIZE];
	public GameObject[] Asset_StockImgObj = new GameObject[StockSIZE];
	public GameObject[] Asset_StockBtnObj = new GameObject[StockSIZE];
	public ulong[] Asset_StockNowPrice = new ulong[StockSIZE];


	//AssetsManager에서 묶어줘야함.
	public Moneyupdate MU;
	public HouseButtonEvent myBGList; //connect HouseManager
	public CountryButtonEvent myFlagList; //connect CountryManager
	public ShopScrollList myStockList; //connect StockList/viewport/content
	public TransMoney myTransMoney; //connect MoneyManager
	/*
	2. 아이템(인벤토리)
		a. 집, 땅, 국가 3가지를 탭 형식으로 구성
			ㄱ. 구매한 것 : SELL 버튼 활성화, 아이콘 컬러,  해당 항목(행) 배경 색 밝음,  초기 구매가와 현재 판매가 표기(비교를 위해)
				-- SELL 버튼 onClinck, 
					>> 현재 배경을 기본 배경(0원)으로 변경, 현재 판매가 만큼 +money, 해당 집을 미구매한 집으로 변경
			ㄴ. 미구매한 것 : 아이콘 흑백, SELL 글씨 색상 흐리게, SELL 버튼 비활성화
	*/

	void Awake(){
	}
	//connect tabbutton0
	public void Asset_HouseInitiate(){
		if (Asset_housePopup.activeSelf == true) {
			for (int i = 0; i < houseSIZE; i++) {
				//House,iconimg,btn오브젝트
				Asset_houseObj [i] = GameObject.Find ("House"+i).gameObject;
				Asset_houseObj [i].transform.GetChild (1).GetComponent<Text> ().fontSize = 10;
				Asset_houseImgObj [i] = Asset_houseObj [i].transform.FindChild ("Image").gameObject;
				//Asset_StockObj [i].transform.position = new Vector3((float)110, (float)(92.0f-(float)ItemN*40.0f));
				//Asset_houseImgObj [i].transform.position.y = 
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
	//connect tabbutton1
	public void Asset_StockInitiate(){
		if (Asset_StockPopup.activeSelf == true) {
			for (int i = 0; i < StockSIZE; i++) {
				//Stock,iconimg,btn오브젝트
				Asset_StockObj [i] = GameObject.Find ("Company ("+i+")").gameObject;
				Asset_StockObj [i].transform.GetChild (1).GetComponent<Text> ().fontSize = 10;
				Asset_StockImgObj [i] = Asset_StockObj [i].transform.FindChild ("Image").gameObject;
				Asset_StockBtnObj [i] = Asset_StockObj [i].transform.FindChild ("Button").gameObject;
				Asset_StockBtnObj [i].transform.GetChild(0).GetComponent<Text> ().text = "SELL";
			}
			//자산은 여기서 listUpdate함, 왜냐면, 집이랑 국가는 
			Asset_StockCheck ();/////1
		}
	}


	void Start() {

		for (int i = 0; i < houseSIZE; i++) {
			Asset_houseObj[i] = null;
			Asset_houseImgObj[i] = null;
			Asset_houseBtnObj[i] = null;
			Asset_houseNowPrice [i] = myBGList.BG_Price[i];
		}
		for (int i = 0; i < countrySIZE; i++) {
			Asset_countryObj[i] = null;
			Asset_countryImgObj[i] = null;
			Asset_countryBtnObj[i] = null;
			Asset_countryNowPrice [i] = myFlagList.Price[i];

		}
		for (int i = 0; i < StockSIZE; i++) {
			Asset_StockObj[i] = null;
			Asset_StockImgObj[i] = null;
			Asset_StockBtnObj[i] = null;
			Asset_StockNowPrice [i] = myStockList.stockassetprice[i];
		}
		//1초 주기
		StartCoroutine ("CountTime", 1);
	}


	IEnumerator CountTime(float delayTime) {
		//1초 마다 할 동작!
		//값이 비쌀수록 적은 비율로 오름
		ulong tempPrice;
		for (int i = 0; i < houseSIZE; i++) {
			if (i < houseSIZE / 2) {
				tempPrice = Asset_houseNowPrice [i];
				tempPrice /= 1000;
				tempPrice *= 1005;
				Asset_houseNowPrice [i] = tempPrice;
			} else {
				tempPrice = Asset_houseNowPrice [i];
				tempPrice /= 1000;
				tempPrice *= 1004;
				Asset_houseNowPrice [i] = tempPrice;
			}
		}
		/*
		for (int i = 0; i < StockSIZE; i++) {
			if (myStockList.stockassetpercent [i] > 100f) {
				tempPrice = Asset_StockNowPrice [i];
				tempPrice /= 1000;
				tempPrice *= 1003;
				Asset_StockNowPrice [i] = tempPrice;
			}
		}
		*/
		for (int i = 0; i < countrySIZE; i++) {
			if (i < countrySIZE / 2) {
				tempPrice = Asset_countryNowPrice [i];
				tempPrice /= 1000;
				tempPrice *= 1002;
				Asset_countryNowPrice [i] = tempPrice;
			} else {
				tempPrice = Asset_countryNowPrice [i];
				tempPrice /= 1000;
				tempPrice *= 1001;
				Asset_countryNowPrice [i] = tempPrice;				
			}
		}


		yield return new WaitForSeconds(delayTime);
		StartCoroutine("CountTime", 1);
	}

	void Update () {
		if(Asset_housePopup.activeSelf==true)
			Asset_HouseCheck ();
		if(Asset_countryPopup.activeSelf==true)
			Asset_CountryCheck ();
		//	if(Asset_StockPopup.activeSelf==true)
		//		Asset_StockCheck ();
	}

	public void Asset_HouseCheck(){
		for (int i = 0; i < houseSIZE; i++) {
			//이미 구매한 경우
			if (myBGList.BG_BuyList [i] == false) {
				Asset_houseObj [i].transform.GetChild (1).GetComponent<Text> ().text = "구매가:"+ myTransMoney.strTransMoney(myBGList.BG_Price[i])+"\n판매가:"+myTransMoney.strTransMoney(Asset_houseNowPrice[i]);
				//밝게
				Asset_houseObj[i].GetComponent<Image> ().color = new Color (154 / 255, 154 / 255, 154 / 255, 154 / 255);
				//컬러아이콘
				Asset_houseImgObj[i].GetComponent<Image> ().sprite = Resources.Load<Sprite> ("bg_img/bg"+i) as Sprite;//("bg_icon/bg_icon_" + i) as Sprite;
				//버튼 활성화
				Asset_houseBtnObj[i].SetActive(true);
				//배경 바꾸기 O
				Asset_houseImgObj[i].GetComponent<Button>().enabled = true;
			}
			else {
				Asset_houseObj [i].transform.GetChild (1).GetComponent<Text> ().text = "미구매";
				Asset_houseObj [i].transform.GetChild (1).GetComponent<Text> ().alignment = TextAnchor.MiddleCenter;
				//어둡게
				Asset_houseObj [i].GetComponent<Image> ().color = new Color (0.6f, 0.6f, 0.6f, 1);
				//흑백
				Asset_houseImgObj [i].GetComponent<Image> ().sprite = Resources.Load<Sprite> ("bg_img/gray_bg"+i) as Sprite;//bg_icon/sel_bg_icon_" + i) as Sprite;
				//버튼 비활성화
				Asset_houseBtnObj [i].SetActive (false);
				//배경 바꾸기 X
				Asset_houseImgObj[i].GetComponent<Button>().enabled = false;
			}

		}
	}
	public void Asset_CountryCheck(){
		for (int i = 0; i < countrySIZE; i++) {
			//이미 구매한 경우
			if (myFlagList.BuyList [i] == false) {
				//구매가, 밝게, 컬러아이콘, 버튼활성화 
				Asset_countryObj[i].transform.GetChild(1).GetComponent<Text>().text =  "구매가:"+ myTransMoney.strTransMoney(myFlagList.Price[i])+"\n판매가:"+ myTransMoney.strTransMoney(Asset_countryNowPrice[i]);
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
	public void Asset_StockCheck(){
		int ItemN = 0;
		int nonItemN = 0;
		for (int i = 0; i < StockSIZE; i++) {
			//주식 보유한 경우
			if (myStockList.stockassetpercent [i] > 0.0f) {
				Debug.Log("보유가:"+ myTransMoney.strTransMoney(myStockList.stockassetprice[i])+"\n지분율:"+ (myStockList.stockassetpercent[i]).ToString("N2")+"%");
				//구매가, 밝게, 컬러아이콘, 버튼활성화 
				Asset_StockObj[ItemN].transform.GetChild(1).GetComponent<Text>().text =  "보유가:"+ myTransMoney.strTransMoney(myStockList.stockassetprice[i])+"\n지분율:"+ (myStockList.stockassetpercent[i]).ToString("N2")+"%";
				Asset_StockObj [ItemN].GetComponent<Image> ().color = Color.white;
				Asset_StockImgObj[ItemN].GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Stock_logo/"+i) as Sprite;
				Asset_StockImgObj [ItemN].GetComponent<Image> ().color = Color.white;
				Asset_StockBtnObj[ItemN].SetActive(false);
				ItemN++;
				//Asset_StockObj [i].transform.position = new Vector3((float)110, (float)(92.0f-(float)ItemN*40.0f));

			}
			//보유하지 않은 경우
			else {
				//미구매 , 어둡게, 흑백아이콘, 버튼비활성화
				nonItemN++;
				Asset_StockObj [StockSIZE-nonItemN].transform.GetChild (1).GetComponent<Text> ().text = "미보유";
				Asset_StockObj[StockSIZE-nonItemN].GetComponent<Image> ().color = new Color (0.6f, 0.6f, 0.6f, 1);
				//Asset_StockImgObj[i].GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Stock_logo/"+i) as Sprite;
				Asset_StockImgObj[StockSIZE-nonItemN].GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Stock_logo/"+i) as Sprite;
				Asset_StockImgObj[StockSIZE-nonItemN].GetComponent<Image> ().color = new Color (0.6f, 0.6f, 0.6f, 1);
				Asset_StockBtnObj[StockSIZE-nonItemN].SetActive(false);

				//맨 밑에서 부터..
				//Asset_StockObj [i].transform.position = new Vector3((float)110, (float)(92.0f-(float)countrySIZE*40.0f)+(float)(nonItemN)*40.0f);
			}
			/*
			//주식 보유한 경우
			if (myStockList.stockassetpercent [i] > 0.0f) {
				//구매가, 밝게, 컬러아이콘, 버튼활성화 
				Asset_StockObj[i].transform.GetChild(1).GetComponent<Text>().text =  "보유가:"+ myTransMoney.strTransMoney(myStockList.stockassetprice[i])+"\n지분율:"+ (myStockList.stockassetpercent[i]).ToString("N2")+"%";
				Asset_StockObj [i].GetComponent<Image> ().color = new Color (154 / 255, 154 / 255, 154 / 255, 154 / 255);
				//Asset_StockImgObj[i].GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Flag/flag ("+i+")") as Sprite;
				Asset_StockBtnObj[i].SetActive(false);


				//Asset_StockObj [i].transform.position = new Vector3((float)110, (float)(92.0f-(float)ItemN*40.0f));
				//ItemN++;

			}
			//보유하지 않은 경우
			else {
				//미구매 , 어둡게, 흑백아이콘, 버튼비활성화
				Asset_StockObj [i].transform.GetChild (1).GetComponent<Text> ().text = "미보유";
				Asset_StockObj[i].GetComponent<Image> ().color = new Color (0.6f, 0.6f, 0.6f, 1);
				//Asset_StockImgObj[i].GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Flag/gray_flag ("+i+")") as Sprite;
				Asset_StockBtnObj[i].SetActive(false);

				//맨 밑에서 부터..
				//Asset_StockObj [i].transform.position = new Vector3((float)110, (float)(92.0f-(float)countrySIZE*40.0f)+(float)(nonItemN)*40.0f);
				//nonItemN++;
			}
			*/
		}
	}

	//connect Button onClick event
	public void Asset_HouseOnClick (int btn){
		Moneyupdate MU= GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
		HouseButtonEvent HE= GameObject.Find("HouseManager").GetComponent<HouseButtonEvent>();
		MU.money += HE.BG_Price[btn]*2;
		HE.changeBGBuyEnable (btn);
		//기본배경으로 초기화
		GameObject.Find ("Background").GetComponent<Image> ().sprite = Resources.Load<Sprite> ("bg_img/bg99") as Sprite;
		HE.Selected_BG = (int)99;
	}
	//connect Button onClick event
	public void Asset_changeHouse (int btn){
		HouseButtonEvent HE= GameObject.Find("HouseManager").GetComponent<HouseButtonEvent>();
		//기본배경으로 초기화
		GameObject.Find ("Background").GetComponent<Image> ().sprite = Resources.Load<Sprite> ("bg_img/bg99") as Sprite;
		HE.Selected_BG = (int)btn;
	}

	//connect Button onClick event
	public void Asset_CountryOnClick (int btn){
		Moneyupdate MU= GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
		CountryButtonEvent CE= GameObject.Find("CountryManager").GetComponent<CountryButtonEvent>();
		MU.money += CE.Price[btn]*2;
		CE.countryDel (btn);
		CE.changeBuyEnable (btn);
	}

	//connect Button onClick event
	public void Asset_StockOnClick (int btn){
		Moneyupdate MU= GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
		//ShopScrollList SE= GameObject.Find("CountryManager").GetComponent<ShopScrollList>();
		MU.money += myStockList.stockassetprice[btn];

		//CE.countryDel (btn);
		//CE.changeBuyEnable (btn);
	}
}	
