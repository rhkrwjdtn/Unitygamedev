using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyStockButton : MonoBehaviour {

	public Button buttonComponent;
	public Text nameLabel;
	public Text priceText;
	public Text countText;
	public Text averageText;

	private Item item;
	private ShopScrollList scrollList;


	// Use this for initialization
	void Start () 
	{
		//Screen.SetResolution(Screen.width, (Screen.width / 10) * 16 ,true);
		//Screen.SetResolution(Screen.width, (Screen.width / 2) * 3,true ); 
		//Screen.SetResolution( 300, 480, true );
		buttonComponent.onClick.AddListener (HandleClick);
	}

	public void Setup(Item currentItem, ShopScrollList currentScrollList)
	{
		item = currentItem;
		nameLabel.text = item.stockName;
		priceText.text = item.price.ToString ();
		countText.text = item.count.ToString ();
		averageText.text = item.Average.ToString ();
		scrollList = currentScrollList;

	}

	public void HandleClick()
	{
		scrollList.ViewInfo (item);
	}

}
