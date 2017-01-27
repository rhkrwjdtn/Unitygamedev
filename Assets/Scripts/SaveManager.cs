using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : MonoBehaviour {
	const int BG_SIZE = 7;
	const int FLAG_SIZE = 13;
	const int STOCK_SIZE = 9;
	const int CHAR_SIZE = 7;

	public Moneyupdate myMoney;    //connect Moneyupdate
	public ShopScrollList myStockList;       //connect MyStockList
	public HouseButtonEvent myBGList; //connect HouseManager
	public CountryButtonEvent myFlagList; //connect CountryManager
	public ShopScrollList StockList; //connect StockList
	public GameObject EndPanel;


	public GameObject dog = null;
	public GameObject myulchi = null;
	public GameObject yapsap = null;
	public GameObject dungchi = null;
	public GameObject myungsasu = null;
	public GameObject skate = null;
	public GameObject godh = null;

	public ButtonEnable employment;

	public int loadlen;
	/// <summary>
	/// //////////////////////////////////////////////////////////////////////////////////////////
	/// 
	/// 

	public static int money = 0;  //A2 일반변수

	[Serializable] //B 직렬화가능한 클래스
	public class PlayerData
	{

		public ulong money;
		public int selected_BG;
		public bool[] BG_BuyList = new bool[BG_SIZE];
		public bool[] FLAG_BuyList = new bool[FLAG_SIZE];

		public ulong[] stockprice = new ulong[STOCK_SIZE];
		public ulong[] stockcount = new ulong[STOCK_SIZE];
		public ulong[] stockaverage = new ulong[STOCK_SIZE];

		public bool dogis = new bool();
		public bool myulchiis = new bool();
		public bool yapsapis = new bool();
		public bool dungchiis = new bool();
		public bool myungsasuis = new bool();
		public bool skateis = new bool();
		public bool godhis = new bool();

		public int doglevel = new int ();
		public int myulchilevel = new int ();
		public int yapsapLevel = new int ();
		public int dungchilevel = new int ();
		public int myungsasulevel = new int ();
		public int skatelevel = new int ();
		public int godhlevel = new int ();
	}

	[Serializable] //B 직렬화가능한 클래스
	public class StockData
	{
		public int len;
		public int stockNum;

	}







	void Awake () {
		LoadData();       //시작시 실행, 가장늦게되게끔 셋팅하기


	}


		void Update () {
			if(Input.GetKeyDown(KeyCode.Escape))
			{
			if (!EndPanel.activeSelf) {
				EndPanel.SetActive (true);
			} else {
				EndPanel.SetActive (false);
			}
			}
		}

	public void EndGame(){
		Application.Quit();
	}

	void OnApplicationQuit()
	{
		SaveData ();
	}

	void OnApplicationPause(bool pauseStatus)    //강제종료시
	{
		if(pauseStatus)
		{
			SaveData ();
		}
	}

	public void SaveData(){           //저장버튼누르면 

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData ();

		//A --> B에 할당
		data.money = myMoney.money;

		data.selected_BG = myBGList.Selected_BG;
			
		for (int k = 0; k < BG_SIZE; k++)//BG_LIST
			data.BG_BuyList [k] = myBGList.BG_BuyList [k];

		for (int k = 0; k < FLAG_SIZE; k++)//FLAG_LIST
			data.FLAG_BuyList [k] = myFlagList.BuyList [k];
		
	
		for (int i = 0; i < StockList.itemList.Count; i++){                          //stock save
			Debug.Log ("stock 현재가 @@@@@@"+StockList.itemList [i].price);
			data.stockprice [i] = StockList.itemList [i].price;
			data.stockcount [i] = StockList.itemList [i].count;
			data.stockaverage [i] = StockList.itemList [i].Average;

	}

		data.dogis = dog.activeSelf;
		data.myulchiis = myulchi.activeSelf;
		data.yapsapis = yapsap.activeSelf;
		data.dungchiis = dungchi.activeSelf;
		data.myungsasuis = myungsasu.activeSelf;
		data.skateis = skate.activeSelf;
		data.godhis = godh.activeSelf;

		data.doglevel = employment.dogLevel;
		data.myulchilevel = employment.myulchiLevel;
		data.yapsapLevel = employment.yapsapLevel;
		data.dungchilevel = employment.dungchiLevel;
		data.myungsasulevel = employment.myungsasuLevel;
		data.skatelevel = employment.skateLevel;
		data.godhlevel = employment.godhLevel;



		//B 직렬화하여 파일에 담기
		bf.Serialize(file, data);
		file.Close();


		////////////////////////////stockdata
		for (int i = 0; i < myStockList.itemList.Count; i++) {
			BinaryFormatter bf2 = new BinaryFormatter ();
			FileStream file2 = File.Create (Application.persistentDataPath + "/stockInfo"+i+".dat");

			StockData data2 = new StockData ();
		


			//A --> B에 할당

			data2.len = myStockList.itemList.Count;
			data2.stockNum = myStockList.itemList [i].stockNum;


		

			//B 직렬화하여 파일에 담기
			bf2.Serialize (file2, data2);
			file2.Close ();
		}
	}




	public void LoadData(){                   //시작시 실행

		BinaryFormatter bf = new BinaryFormatter ();
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

			if (file != null && file.Length > 0) {
				//파일 역직렬화하여 B에 담기
				PlayerData data = (PlayerData)bf.Deserialize (file);

				//B --> A에 할당
				try{
					myMoney.money = data.money;

					myBGList.Selected_BG = data.selected_BG;

					for(int k = 0; k < BG_SIZE; k++)//BG_LIST
						myBGList.BG_BuyList[k] = data.BG_BuyList [k];
					
					for(int k = 0; k < FLAG_SIZE; k++)//FLAG_LIST
						myFlagList.BuyList[k] = data.FLAG_BuyList [k];

					for(int i=0; i<StockList.itemList.Count;i++){
						StockList.itemList [i].price = data.stockprice [i];
						StockList.itemList [i].count = data.stockcount [i];
						StockList.itemList [i].Average = data.stockaverage [i];
					}
					Debug.Log (money);

					dog.SetActive(data.dogis);
					myulchi.SetActive( data.myulchiis);
					yapsap.SetActive(data.yapsapis);
					dungchi.SetActive(data.dungchiis);
					myungsasu.SetActive(data.myungsasuis);
					skate.SetActive(data.skateis);
					godh.SetActive(data.godhis);


					employment.dogLevel = data.doglevel;
					employment.myulchiLevel = data.myulchilevel ;
					employment.yapsapLevel = data.yapsapLevel ;
					employment.dungchiLevel = data.dungchilevel ;
					employment.myungsasuLevel =data.myungsasulevel;
					employment.skateLevel = data.skatelevel;
					employment.godhLevel = data.godhlevel;

		


				}
				catch(NullReferenceException NE){
					Debug.Log ("저장된 값이 없는 항목이 있으므로 초기화 합니다.\n"+NE);
					if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
						file.Close ();
						SaveData ();
					}
				}
			}

			file.Close ();
		} else
			SaveData ();	
		//////////////////////////////////////////stock
		/// 
		BinaryFormatter bf2 = new BinaryFormatter ();
		if (File.Exists (Application.persistentDataPath + "/stockInfo0.dat")) {
			FileStream file2 = File.Open (Application.persistentDataPath + "/stockInfo0.dat", FileMode.Open);

			if (file2 != null && file2.Length > 0) {
				//파일 역직렬화하여 B에 담기
				StockData listdata = (StockData)bf2.Deserialize (file2);

				loadlen = listdata.len;





			}

			file2.Close ();
		} else {
			SaveData ();
		}
		////////////////////////////////////////////////////////////////////////////////////////

		for (int i = 0; i < loadlen ; i++) {

			BinaryFormatter bf3 = new BinaryFormatter ();
			if (File.Exists (Application.persistentDataPath + "/stockInfo" + i + ".dat")) {
				FileStream file3 = File.Open (Application.persistentDataPath + "/stockInfo" + i + ".dat", FileMode.Open);

				if (file3 != null && file3.Length > 0) {
					//파일 역직렬화하여 B에 담기
					StockData listdata = (StockData)bf3.Deserialize (file3);

					StockData saveitem = new StockData ();

					saveitem.stockNum = listdata.stockNum;

					if (StockList.itemList [saveitem.stockNum].count > 0) {
						myStockList.AddItem (StockList.itemList [saveitem.stockNum], myStockList);

						myStockList.MyRemoveButtons ();
						myStockList.MyAddButtons ();
					}


				}

				file3.Close ();
			} else {
				SaveData ();
			}
		}
	

	}



}
