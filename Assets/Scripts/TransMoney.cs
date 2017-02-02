using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransMoney : MonoBehaviour {

	public string strMoney;

	public ulong won;
	public ulong man;
	public ulong uck;
	public ulong jo;
	public ulong kyung;

	public string strTransMoney(ulong moneytransform){
		
		kyung = moneytransform / 10000000000000000;
		moneytransform = moneytransform % 10000000000000000;
		jo = moneytransform / 1000000000000;
		moneytransform = moneytransform % 1000000000000;
		uck = moneytransform / 100000000;
		moneytransform = moneytransform % 100000000;
		man = moneytransform / 10000;
		won = moneytransform % 10000;


		if (won > 0 && man == 0 && uck == 0 && jo == 0 && kyung == 0)
			strMoney = System.Convert.ToString (won);
		else if (won == 0 && man > 0 && uck == 0 && jo == 0 && kyung == 0)
			strMoney = System.Convert.ToString (man) + "만";
		else if (won >= 0 && man > 0 && uck == 0 && jo == 0 && kyung == 0)
			strMoney = System.Convert.ToString (man) + "만" + System.Convert.ToString (won);
		else if (won == 0 && man == 0 && uck > 0 && jo == 0 && kyung == 0)
			strMoney = System.Convert.ToString (uck) + "억";
		else if (won == 0 && man >= 0 && uck > 0 && jo == 0 && kyung == 0)
			strMoney = System.Convert.ToString (uck) + "억" + System.Convert.ToString (man) + "만";
		else if (won >= 0 && man >= 0 && uck > 0 && jo == 0 && kyung == 0)
			strMoney = System.Convert.ToString (uck) + "억" + System.Convert.ToString (man) + "만" + System.Convert.ToString (won);
		else if (won >= 0 && man == 0 && uck == 0 && jo > 0 && kyung == 0)
			strMoney = System.Convert.ToString (jo) + "조";
		else if (won >= 0 && man == 0 && uck >= 0 && jo > 0 && kyung == 0)
			strMoney = System.Convert.ToString (jo) + "조" + System.Convert.ToString (uck) + "억";
		else if (won >= 0 && man >= 0 && uck >= 0 && jo > 0 && kyung == 0)
			strMoney = System.Convert.ToString (jo) + "조" + System.Convert.ToString (uck) + "억" + System.Convert.ToString (man) + "만";
		else if (won >= 0 && man == 0 && uck == 0 && jo == 0 && kyung > 0)
			strMoney = System.Convert.ToString (kyung) + "경";
		else if (won >= 0 && man >= 0 && uck == 0 && jo >= 0 && kyung > 0)
			strMoney = System.Convert.ToString (kyung) + "경" + System.Convert.ToString (jo) + "조";
		else if (won >= 0 && man >= 0 && uck >= 0 && jo >= 0 && kyung > 0)
			strMoney = System.Convert.ToString (kyung) + "경" + System.Convert.ToString (jo) + "조" + System.Convert.ToString (uck) + "억";

		return strMoney+"원";
	}
}
