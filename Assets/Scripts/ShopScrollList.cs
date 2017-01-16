using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


[System.Serializable]
public class Item
{
	public string stockName;
	//public Sprite icon;
	public float price = 0f;
	public float count = 0f;
}

public class ShopScrollList : MonoBehaviour {


	public List<Item> itemList;
	public Transform contentPanel;
	public ShopScrollList otherShop;
	public Text NameDisplay;
	public Text PriceDisplay;
	public SimpleObjectPool buttonObjectPool;
	public Item thisitem;

	public InputField buyField;
	public InputField sellField;

	public string Stock = "종목을 선택해주세요";
	public float gold = 0.0f;


	// Use this for initialization
	void Start () 
	{
		RefreshDisplay ();
	}

	public void RefreshDisplay()
	{

		RemoveButtons ();       
		AddButtons ();
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


	private void MyRemoveButtons()
	{
		while (contentPanel.childCount > 0) 
		{
			GameObject toRemove = transform.GetChild(0).gameObject;
			buttonObjectPool.ReturnObject(toRemove);
		}
	}

	private void MyAddButtons()
	{
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
		int num = System.Convert.ToInt32 (buyField.text);
		thisitem.count += num;

		AddItem(thisitem, otherShop);
		otherShop.MyRemoveButtons();
		otherShop.MyAddButtons();
		Debug.Log (thisitem.stockName);
	}

	public void Sellbuttonclick(){

		//if()      count가 0이되면 지워지기
		RemoveItem(thisitem, this);

		MyRemoveButtons ();
		MyAddButtons();
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

	void AddItem(Item itemToAdd, ShopScrollList shopList)
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
