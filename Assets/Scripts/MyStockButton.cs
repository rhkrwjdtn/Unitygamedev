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
		//priceText.text = item.price.ToString ();
		if (item.Average < item.price) {
			nameLabel.text = "<color=#ff0000>" +item.stockName + "</color>";
			countText.text = "<color=#ff0000>" +item.count.ToString ()+ "</color>";
			averageText.text = "<color=#ff0000>" +item.Average.ToString ()+ "</color>";
		} else if (item.Average == item.price) {
			nameLabel.text = item.stockName;
			countText.text = item.count.ToString ();
			averageText.text = item.Average.ToString ();
		} else if (item.Average > item.price) {
			nameLabel.text = "<color=#0000ff>"+item.stockName + "</color>";
			countText.text = "<color=#0000ff>" +item.count.ToString ()+ "</color>";
			averageText.text = "<color=#0000ff>"+item.Average.ToString ()+ "</color>";
		}
		scrollList = currentScrollList;

	}

	public void HandleClick()
	{
		scrollList.ViewInfo (item);
	}

}
