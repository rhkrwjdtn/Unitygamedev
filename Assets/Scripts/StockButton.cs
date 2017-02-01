using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StockButton : MonoBehaviour {

	public Button buttonComponent;
	public Text nameLabel;
	public Text priceText;
	public Text countText;
	public Text averageText;

	private ulong minprice=2200;
	private ulong maxprice=7000000;
	private Item item;
	private ShopScrollList scrollList;


	// Use this for initialization
	void Start () 
	{
		//Screen.SetResolution(Screen.width, (Screen.width / 10) * 16 ,true);
		//Screen.SetResolution(Screen.width, (Screen.width / 2) * 3 ,true); 
		//Screen.SetResolution( 300, 480, true );
		buttonComponent.onClick.AddListener (HandleClick);
	}

	public void Setup(Item currentItem, ShopScrollList currentScrollList)
	{

		item = currentItem;
		if (item.stockNum == 0) {
			if (item.price > maxprice) {
				float stockRate = (float)Random.Range (-30, 0) / 100;
				item.price = (ulong)(item.price + item.price * stockRate);
				priceText.text = "<color=#0000ff>" + item.price.ToString () + " ▼ " + "</color>";    //blue

			} else if (item.price < minprice) {
				float stockRate = (float)Random.Range (0, 30) / 100;
				item.price = (ulong)(item.price + item.price * stockRate);
				priceText.text = "<color=#ff0000>" + item.price.ToString () + " ▲ " + "</color>";    //red

			} else if (item.price >= minprice) {

				float stockRate = (float)Random.Range (-13, 16) / 100;
				item.price = (ulong)(item.price + item.price * stockRate);
				if (stockRate > 0) {
					priceText.text = "<color=#ff0000>" + item.price.ToString () + " ▲ " + "</color>";    //red
				} else if (stockRate == 0) {
					priceText.text = item.price.ToString () + "  - ";
				} else if (stockRate < 0) {
					priceText.text = "<color=#0000ff>" + item.price.ToString () + " ▼ " + "</color>";    //blue
				}

			} 
		} else if (item.stockNum == 1 || item.stockNum == 2) {
			if (item.price > maxprice) {
				float stockRate = (float)Random.Range (-15, 0) / 100;
				item.price = (ulong)(item.price + item.price * stockRate);
				priceText.text = "<color=#0000ff>" + item.price.ToString () + " ▼ " + "</color>";    //blue

			} else if (item.price < minprice) {
				float stockRate = (float)Random.Range (0, 14) / 100;
				item.price = (ulong)(item.price + item.price * stockRate);
				priceText.text = "<color=#ff0000>" + item.price.ToString () + " ▲ " + "</color>";    //red

			} else if (item.price >= minprice) {

				float stockRate = (float)Random.Range (-28, 30) / 100;
				item.price = (ulong)(item.price + item.price * stockRate);
				if (stockRate > 0) {
					priceText.text = "<color=#ff0000>" + item.price.ToString () + " ▲ " + "</color>";    //red
				} else if (stockRate == 0) {
					priceText.text = item.price.ToString () + "  - ";
				} else if (stockRate < 0) {
					priceText.text = "<color=#0000ff>" + item.price.ToString () + " ▼ " + "</color>";    //blue
				}

			} 
		} else if (item.stockNum == 3) {
			if (item.price > maxprice) {
				float stockRate = (float)Random.Range (-30, 0) / 100;
				item.price = (ulong)(item.price + item.price * stockRate);
				priceText.text = "<color=#0000ff>" + item.price.ToString () + " ▼ " + "</color>";    //blue

			} else if (item.price < minprice) {
				float stockRate = (float)Random.Range (0, 30) / 100;
				item.price = (ulong)(item.price + item.price * stockRate);
				priceText.text = "<color=#ff0000>" + item.price.ToString () + " ▲ " + "</color>";    //red

			} else if (item.price >= minprice) {

				float stockRate = (float)Random.Range (-27, 30) / 100;
				item.price = (ulong)(item.price + item.price * stockRate);
				if (stockRate > 0) {
					priceText.text = "<color=#ff0000>" + item.price.ToString () + " ▲ " + "</color>";    //red
				} else if (stockRate == 0) {
					priceText.text = item.price.ToString () + "  - ";
				} else if (stockRate < 0) {
					priceText.text = "<color=#0000ff>" + item.price.ToString () + " ▼ " + "</color>";    //blue
				}

			} 
		} else if (item.stockNum == 4 || item.stockNum == 5 || item.stockNum == 6) {
			if (item.price > maxprice) {
				float stockRate = (float)Random.Range (-30, 0) / 100;
				item.price = (ulong)(item.price + item.price * stockRate);
				priceText.text = "<color=#0000ff>" + item.price.ToString () + " ▼ " + "</color>";    //blue

			} else if (item.price < minprice) {
				float stockRate = (float)Random.Range (0, 20) / 100;
				item.price = (ulong)(item.price + item.price * stockRate);
				priceText.text = "<color=#ff0000>" + item.price.ToString () + " ▲ " + "</color>";    //red

			} else if (item.price >= minprice) {

				float stockRate = (float)Random.Range (-17, 20) / 100;
				item.price = (ulong)(item.price + item.price * stockRate);
				if (stockRate > 0) {
					priceText.text = "<color=#ff0000>" + item.price.ToString () + " ▲ " + "</color>";    //red
				} else if (stockRate == 0) {
					priceText.text = item.price.ToString () + "  - ";
				} else if (stockRate < 0) {
					priceText.text = "<color=#0000ff>" + item.price.ToString () + " ▼ " + "</color>";    //blue
				}

			} 
		} else if (item.stockNum == 7 || item.stockNum == 8 ) {
			if (item.price > maxprice) {
				float stockRate = (float)Random.Range (-30, 0) / 100;
				item.price = (ulong)(item.price + item.price * stockRate);
				priceText.text = "<color=#0000ff>" + item.price.ToString () + " ▼ " + "</color>";    //blue

			} else if (item.price < minprice) {
				float stockRate = (float)Random.Range (0, 30) / 100;
				item.price = (ulong)(item.price + item.price * stockRate);
				priceText.text = "<color=#ff0000>" + item.price.ToString () + " ▲ " + "</color>";    //red

			} else if (item.price >= minprice) {

				float stockRate = (float)Random.Range (-6, 9) / 100;
				item.price = (ulong)(item.price + item.price * stockRate);
				if (stockRate > 0) {
					priceText.text = "<color=#ff0000>" + item.price.ToString () + " ▲ " + "</color>";    //red
				} else if (stockRate == 0) {
					priceText.text = item.price.ToString () + "  - ";
				} else if (stockRate < 0) {
					priceText.text = "<color=#0000ff>" + item.price.ToString () + " ▼ " + "</color>";    //blue
				}

			} 
		}


		nameLabel.text = item.stockName;

		//countText.text = item.count.ToString ();
		//averageText.text = item.Average.ToString ();
		scrollList = currentScrollList;

	}

	public void HandleClick()
	{
		scrollList.ViewInfo (item);
	}

}
