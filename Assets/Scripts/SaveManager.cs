using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {

	public Moneyupdate myMoney;    //connect Moneyupdate
	public ShopScrollList myStockList;       //connect MyStockList

	public void OnClickSaveManager(){       //when click save button


		//PlayerPrefs.SetInt("Player Money", myMoney.money);         //save Money


		for (int i = 0; i < myStockList.itemList.Count; i++) {          //save myStockList
			PlayerPrefs.SetString("StockName"+i, myStockList.itemList[i].stockName);     //stockName
			//PlayerPrefs.SetInt("StockPrice"+i, myStockList.itemList[i].price);           //stockPrice
			//PlayerPrefs.SetInt("StockCount"+i, myStockList.itemList[i].count);             //stockCount
			//PlayerPrefs.SetInt("StockAverage"+i, myStockList.itemList[i].Average);        //stockAverage
		}





	}

}
