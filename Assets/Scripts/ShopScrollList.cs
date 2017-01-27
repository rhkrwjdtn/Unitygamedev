using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


[System.Serializable]
public class Item
{
	public string stockName;
	public ulong price = 0;
	public ulong count = 0;
	public ulong Average = 0;
	public int stockNum;
}

public class ShopScrollList : MonoBehaviour {
	const int STOCK_SIZE = 9;

	public List<Item> itemList;
	public Transform contentPanel;
	public ShopScrollList otherShop;
	public Text NameDisplay;
	public Text PriceDisplay;
	public SimpleObjectPool buttonObjectPool;
	public Item thisitem;
	public Moneyupdate moneyManager;

	public ulong[] stockassetprice;
	public float[] stockassetpercent;

	public InputField buyField;
	public InputField sellField;

	public string Stock = "종목을 선택해주세요";
	public float gold = 0.0f;


	// Use this for initialization
	void Start () 
	{
		
		//Debug.Log ("회사의 개수는@@@@@@@@@@@@@@@@@@@@@@"+itemList.Count);
		//Screen.SetResolution(Screen.width, (Screen.width / 10) * 16 ,true); 
		//Screen.SetResolution(Screen.width, (Screen.width / 2) * 3 ,true); 
		//Screen.SetResolution( 300, 480, true );
		//RefreshDisplay ();
		/*for(int i=0; i<itemList.Count; i++){
			if (otherShop.itemList.Contains (itemList[i])){

				stockassetprice [i] = itemList [i].price * itemList[i].count;
				stockassetpercent[i] = (float)((itemList [i].count / 100000000)*100f);

				Debug.Log ("i번째 회사의 내 총자산가격은"+stockassetprice [i]+"i번째 회사의 내 %은"+stockassetpercent[i]);
			}else {
				stockassetprice [i] = 0;
				stockassetpercent [i] = 0f;
			}
		}*/
	}

	public void RefreshDisplay()
	{

		RemoveButtons ();       
		AddButtons ();


		for(int i=0; i<itemList.Count; i++){
			stockassetprice = new ulong[STOCK_SIZE];
			stockassetpercent = new float[STOCK_SIZE];

			if (otherShop.itemList.Contains (itemList[i])){
				
				stockassetprice [i] = itemList [i].price * itemList[i].count;
				stockassetpercent[i] = ((float)itemList [i].count / 1000000);

				Debug.Log (i+"번째 회사의 내 총자산가격은"+stockassetprice [i]+i+"번째 회사의 내 %은"+stockassetpercent[i].ToString("N2"));
			}else {
				stockassetprice [i] = 0;
				stockassetpercent [i] = 0f;
			}
		}
	
	}


	private void RemoveButtons()
	{
		while (contentPanel.childCount > 0) 
		{
			GameObject toRemove = transform.GetChild(0).gameObject;
			buttonObjectPool.ReturnObject(toRemove);
		}
	}

	private void AddButtons()
	{
		for (int i = 0; i < itemList.Count; i++) 
		{
			Item item = itemList[i];
			GameObject newButton = buttonObjectPool.GetObject();
			newButton.transform.SetParent(contentPanel);


			StockButton sampleButton = newButton.GetComponent<StockButton>();
			sampleButton.Setup(item, this);
		}
	}


	public void MyRemoveButtons()
	{
		Debug.Log ("리무부버튼!@@@@@@@@@@@@@@@@@@@@@@@");
		while (contentPanel.childCount > 0) 
		{
			GameObject toRemove = transform.GetChild(0).gameObject;
			buttonObjectPool.ReturnObject(toRemove);
		}
	}

	public void MyAddButtons()
	{
		Debug.Log ("애드버튼!@@@@@@@@@@@@@@@@@@@@@@@"+itemList.Count);
		for (int i = 0; i < itemList.Count; i++) 
		{
			Item item = itemList[i];
			GameObject newButton = buttonObjectPool.GetObject();
			newButton.transform.SetParent(contentPanel);


			MyStockButton sampleButton = newButton.GetComponent<MyStockButton>();
			sampleButton.Setup(item, this);
		}
	}

	public void ViewInfo(Item item){

		/*
		 float stockRate = (float)Random.Range(-30, 30)/100;
		item.price = (int)(item.price + item.price * stockRate);

		Debug.Log ("rate는"+stockRate+"현재가는"+item.price);
*/

		thisitem = item;

		Stock = item.stockName;
		gold = item.price;

		NameDisplay.text = "종목명 : " + Stock;
		PriceDisplay.text = "현재가 : " + gold.ToString ();
		//AddItem(item, otherShop);
		//RemoveItem(item, this);

		//RefreshDisplay();
		//otherShop.RefreshDisplay();
	}

	public void Buybuttonclick(){
		ulong num = System.Convert.ToUInt64 (buyField.text);

		Debug.Log ("현재돈은"+moneyManager.money);
		if (thisitem.count < 100000000&& thisitem.count>= 0) {

			if (thisitem.price != 0 && num > 0 && num <= 100000000 && (thisitem.count+num) <= 100000000) {


				if (moneyManager.money >= (num * thisitem.price)) {

					thisitem.Average = (ulong)((thisitem.Average * thisitem.count) + (num * thisitem.price)) / (num + thisitem.count);

					thisitem.count += num;
					moneyManager.money -= num * thisitem.price;     //sub stock price

					if (otherShop.itemList.Contains (thisitem)) {         //if exist other shop
						otherShop.MyRemoveButtons ();
						otherShop.MyAddButtons ();

					} else {
						thisitem.Average = thisitem.price;

						AddItem (thisitem, otherShop);
						otherShop.MyRemoveButtons ();
						otherShop.MyAddButtons ();

					}

				} else {

					// lack money
				}

			}
		}
	}

	public void Sellbuttonclick(){
		ulong num = (ulong)System.Convert.ToUInt64 (sellField.text);


		if (thisitem.count < num ) {
			Debug.Log ("여기가 실ㅇ되야!@@@@@@@@@@");
			//popup error message

		} else if (thisitem.count > num ) {
			Debug.Log ("여기가 실행되면안되야!@@@@@@@@@@"+thisitem.count);
			moneyManager.money += num * thisitem.price;       //add stock price

			thisitem.count -= num;
			MyRemoveButtons ();
			MyAddButtons ();

		} else if (thisitem.count - num == 0) {

			moneyManager.money += num * thisitem.price;   //add stock price

			thisitem.count -= num;
			RemoveItem (thisitem, this);
			MyRemoveButtons ();
			MyAddButtons ();
		}



		//RefreshDisplay();
		Debug.Log (thisitem.stockName);
	}

	/*public void TryTransferItemToOtherShop(Item item)
	{
		
			Stock = item.stockName;
			gold = item.price;
			//otherShop.gold -= item.price;

			AddItem(item, otherShop);
			RemoveItem(item, this);

			RefreshDisplay();
			otherShop.RefreshDisplay();
			Debug.Log ("enough gold");

	}*/

	public void AddItem(Item itemToAdd, ShopScrollList shopList)
	{
		Debug.Log (thisitem.stockName+"추가하기");
		shopList.itemList.Add (itemToAdd);
	}

	private void RemoveItem(Item itemToRemove, ShopScrollList shopList)
	{
		for (int i = shopList.itemList.Count - 1; i >= 0; i--) 
		{
			if (shopList.itemList[i] == itemToRemove)
			{
				shopList.itemList.RemoveAt(i);
			}
		}
	}
}
