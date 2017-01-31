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
	const int Goal_SIZE = 8;
	const int STOCK_SIZE = 9;
	const int CHAR_SIZE = 11;
    const int GIRL_SIZE = 6;


	public Moneyupdate myMoney;    //connect Moneyupdate
	public ShopScrollList myStockList;       //connect MyStockList
	public HouseButtonEvent myBGList; //connect HouseManager
	public CountryButtonEvent myFlagList; //connect CountryManager
	public GoalManager myGoalList; //connect GoalManager
	public RebirthManager myRebirth; //connect GoalManager
	public ShopScrollList StockList; //connect StockList
	public GameObject EndPanel;


	public GameObject dog = null;
	public GameObject myulchi = null;
	public GameObject yapsap = null;
	public GameObject dungchi = null;
	public GameObject myungsasu = null;
	public GameObject skate = null;
	public GameObject godh = null;
    public GameObject ramyun = null;
    public GameObject ho = null;
    public GameObject daejang = null;
    public GameObject chunsooru = null;

	public ButtonEnable employment;
    public EmploymentManager Realemployment;
    public GrilFriendManager girlf;
    public IconManager icon;
    public CharacterInfo character;

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
        public ulong moneyspeed;
        public ulong moneyTouch;

		public int selected_BG;
		public bool[] BG_BuyList = new bool[BG_SIZE];
		public bool[] FLAG_BuyList = new bool[FLAG_SIZE];
		public int[] Goal_LV = new int[Goal_SIZE];
		public int Goal_Rebirth_cnt;

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
        public bool ramyun = new bool();
        public bool ho = new bool();
        public bool daejang = new bool();
        public bool chunsooru = new bool();

        public ulong[] sEmployerLevel = new ulong[CHAR_SIZE];
        public ulong[] sTwoNextLevelPrice = new ulong[CHAR_SIZE];
        public ulong[] splusmoney = new ulong[CHAR_SIZE];
        public ulong[] smoneyspeed = new ulong[CHAR_SIZE];
        public ulong[] speedplus = new ulong[CHAR_SIZE];
        public ulong[] gobsem = new ulong[CHAR_SIZE];
        public ulong[] sstrartlevelprice = new ulong[CHAR_SIZE];

        public int redbullcnt;
        public int smallpizzacnt;
        public int burncnt;
        public int largepizzacnt;
        public int rebirthpotion;

        public bool[] GFExist = new bool[6];

        public ulong JugallumLev;
        public ulong TouchMoney;

        public int noretry;
        public int[] noretryhouse = new int[7];
        public int[] noretryNation = new int[13];

        public bool[] GFTruetoFalse = new bool[6];
        public bool[] HouseTruetoFalse = new bool[7];
        public bool[] NationTruetoFalse = new bool[13];

        public float GFBonus;
        public float HouseBonus;
        public float NationBonus;

        public int TotalHousePersent;
        public int TotalNationPersent;
        public int TotalgfPersent;
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
        data.moneyspeed = myMoney.moneyspeed;
        data.moneyTouch = myMoney.touchspeed;
		data.selected_BG = myBGList.Selected_BG;
		data.Goal_Rebirth_cnt = myRebirth.RebirthCount;
        

		for (int k = 0; k < BG_SIZE; k++)//BG_LIST
			data.BG_BuyList [k] = myBGList.BG_BuyList [k];

		for (int k = 0; k < FLAG_SIZE; k++)//FLAG_LIST
			data.FLAG_BuyList [k] = myFlagList.BuyList [k];

		for (int k = 0; k < Goal_SIZE; k++)//Goal_LV_LIST
			data.Goal_LV [k] = myGoalList.Goal_LV[k];
		

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
        data.ramyun = ramyun.activeSelf;
        data.ho = ramyun.activeSelf;
        data.daejang = daejang.activeSelf;
        data.chunsooru = chunsooru.activeSelf;

        for(int i=0; i<CHAR_SIZE;i++)
        {
            data.sEmployerLevel[i] = Realemployment.EmployerLevel[i];
            data.splusmoney[i] = Realemployment.plusmoney[i];
            data.smoneyspeed[i] = Realemployment.moneyspeed[i];
            data.sTwoNextLevelPrice[i] = Realemployment.TwoNextLevelPrice[i];
            data.gobsem[i] = Realemployment.gobsem[i];
            data.speedplus[i] = Realemployment.speedplus[i];
            data.sstrartlevelprice[i] = Realemployment.StartLevelPrice[i];
        }

        data.redbullcnt = icon.redbullcnt;
        data.smallpizzacnt = icon.smallpizzacnt;
        data.burncnt = icon.burncnt;
        data.largepizzacnt = icon.largepizzacnt;
        data.rebirthpotion = icon.rebirthpotion;

        
        for(int i=0;i<GIRL_SIZE;i++)
        {
            data.GFExist[i] = girlf.GFExist[i];
        }

        data.JugallumLev = character.JugallumLev;
        data.TouchMoney = character.TouchMoney;
        data.noretry = character.noretry;
        data.noretryhouse = character.noretryhouse;
        data.noretryNation = character.noretryNation;
        data.GFTruetoFalse = character.GFTruetoFalse;
        data.HouseTruetoFalse = character.HouseTruetoFalse;
        data.NationTruetoFalse = character.NationTruetoFalse;
        data.GFBonus = character.GFBonus;
        data.HouseBonus = character.HouseBonus;
        data.NationBonus = character.NationBonus;
        data.TotalgfPersent = character.TotalgfPersent;
        data.TotalHousePersent = character.TotalHousePersent;
        data.TotalNationPersent = character.TotalNationPersent;

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
                    myMoney.moneyspeed = data.moneyspeed;
                    myMoney.touchspeed = data.moneyTouch;
					myBGList.Selected_BG = data.selected_BG;
					myRebirth.RebirthCount = data.Goal_Rebirth_cnt;

					for(int k = 0; k < BG_SIZE; k++)//BG_LIST
						myBGList.BG_BuyList[k] = data.BG_BuyList [k];
					
					for(int k = 0; k < FLAG_SIZE; k++)//FLAG_LIST
						myFlagList.BuyList[k] = data.FLAG_BuyList [k];

					for (int k = 0; k < Goal_SIZE; k++)//Goal_LV_LIST
						myGoalList.Goal_LV[k] = data.Goal_LV [k];
					
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
                    ramyun.SetActive(data.ramyun);
                    ho.SetActive(data.ho);
                    daejang.SetActive(data.daejang);
                    chunsooru.SetActive(data.chunsooru);

                    myMoney.touchspeed = data.moneyTouch;

                    data.gobsem[0] = 1;
                    data.gobsem[1] = 5;

                    for(int i=0;i<CHAR_SIZE;i++)
                    {
                        Realemployment.TwoNextLevelPrice[i] = data.sTwoNextLevelPrice[i];
                        Realemployment.moneyspeed[i] = data.smoneyspeed[i];
                        Realemployment.plusmoney[i] = data.splusmoney[i];
                        Realemployment.EmployerLevel[i] = data.sEmployerLevel[i];
                        Realemployment.speedplus[i] = data.speedplus[i];
                        Realemployment.gobsem[i] = data.gobsem[i];
                        Realemployment.StartLevelPrice[i] = data.sstrartlevelprice[i];
                    }
                    icon.redbullcnt = data.redbullcnt;
                    icon.smallpizzacnt = data.smallpizzacnt;
                    icon.burncnt = data.burncnt;
                    icon.largepizzacnt = data.largepizzacnt;
                    icon.rebirthpotion = data.rebirthpotion;
		
                    for(int i=0;i<GIRL_SIZE;i++)
                    {
                        girlf.GFExist[i] = data.GFExist[i];
                    }

                    character.JugallumLev = data.JugallumLev;
                    character.TouchMoney = data.TouchMoney;
                    character.noretry = data.noretry;
                    character.noretryhouse = data.noretryhouse;
                    character.noretryNation = data.noretryNation;
                    character.GFTruetoFalse = data.GFTruetoFalse;
                    character.HouseTruetoFalse = data.HouseTruetoFalse;
                    character.NationTruetoFalse = data.NationTruetoFalse;
                    character.GFBonus = data.GFBonus;
                    character.HouseBonus = data.HouseBonus;
                    character.NationBonus = data.NationBonus;
                    character.TotalgfPersent = data.TotalgfPersent;
                    character.TotalHousePersent = data.TotalHousePersent;
                    character.TotalNationPersent = data.TotalNationPersent;


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
