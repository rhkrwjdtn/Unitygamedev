using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class SaveManager : MonoBehaviour {

	public Moneyupdate myMoney;    //connect Moneyupdate
	public ShopScrollList myStockList;       //connect MyStockList

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


	}

	[Serializable] //B 직렬화가능한 클래스
	public class StockData
	{
		public int len;
		public string stockName;
		public ulong price = 0;
		public ulong count = 0;
		public ulong Average = 0;

	}







	void Start () {
		LoadData();       //시작시 실행, 가장늦게되게끔 셋팅하기
	}




	public void SaveData(){           //저장버튼누르면 

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData();

		//A --> B에 할당
		data.money = myMoney.money;


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
			data2.stockName = myStockList.itemList [i].stockName;
			data2.price = myStockList.itemList [i].price;
			data2.Average = myStockList.itemList [i].Average;
			data2.count = myStockList.itemList [i].count;

		
			Debug.Log ("이거저장한다" +myStockList.itemList [i].stockName);

			//B 직렬화하여 파일에 담기
			bf2.Serialize (file2, data2);
			file2.Close ();
		}
	}




	public void LoadData(){                   //시작시 실행

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

		if (file != null && file.Length > 0) {
			//파일 역직렬화하여 B에 담기
			PlayerData data = (PlayerData)bf.Deserialize (file);

			//B --> A에 할당
			myMoney.money = data.money;


			Debug.Log (money);

		}

		file.Close ();


		//////////////////////////////////////////stock
		/// 
		BinaryFormatter bf2 = new BinaryFormatter ();
		FileStream file2 = File.Open(Application.persistentDataPath + "/stockInfo0.dat", FileMode.Open);

		if (file2 != null && file2.Length > 0) {
			//파일 역직렬화하여 B에 담기
			StockData listdata= (StockData)bf2.Deserialize (file2);

			loadlen = listdata.len;


			Debug.Log ("@@@@@@@@@@@@@@@@@"+loadlen+"개이다");

		}

		file2.Close ();
		////////////////////////////////////////////////////////////////////////////////////////

		for (int i = 0; i < loadlen; i++) {

			BinaryFormatter bf3 = new BinaryFormatter ();
			FileStream file3 = File.Open(Application.persistentDataPath + "/stockInfo"+i+".dat", FileMode.Open);

			if (file3 != null && file3.Length > 0) {
				//파일 역직렬화하여 B에 담기
				StockData listdata= (StockData)bf3.Deserialize (file3);

				Item saveitem = new Item();

				saveitem.stockName = listdata.stockName;
				saveitem.price = listdata.price;
				saveitem.Average = listdata.Average;
				saveitem.count = listdata.count;

				myStockList.AddItem (saveitem, myStockList);
				myStockList.MyRemoveButtons ();
				myStockList.MyAddButtons ();

				Debug.Log ("@@@@@@@@@@@@@@@@@"+listdata.stockName);

			}

			file3.Close ();



		}
	


	}



}
