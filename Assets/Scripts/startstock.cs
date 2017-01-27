using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startstock : MonoBehaviour {

	public ShopScrollList stocklist;
	// Use this for initialization
	void Start () {
		stocklist.RefreshDisplay ();
	}
	

}
