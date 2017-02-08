using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class spoonmanager : MonoBehaviour {

	public Image spoonimage;
	public Sprite[] SpoonImg = new Sprite[7];
    public GameObject popup;

	private ulong myPow(ulong Money, ulong ul, int n){
		for(int i=0; i < n; i++){
			Money *= ul;
		}
		return Money;
	}
	void Start(){
	}
    void Update () {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
		//0~10만 : 0 흙
		//10~100만 : 1 플
		//100~1000만 : 2 녹
		if (moneyu.moneyspeed <= myPow (100000, 10, 0)) 
			spoonimage.GetComponent<Image> ().sprite = SpoonImg [0];
		else if ((moneyu.moneyspeed >= myPow (100000, 10, 7))) //diamond
			spoonimage.GetComponent<Image> ().sprite = SpoonImg [6];
		else if ((moneyu.moneyspeed >= myPow (100000, 10, 6)))
			spoonimage.GetComponent<Image> ().sprite = SpoonImg [5];
		else if ((moneyu.moneyspeed >= myPow (100000, 10, 4)))
			spoonimage.GetComponent<Image> ().sprite = SpoonImg [4];
		else if ((moneyu.moneyspeed >= myPow (100000, 10, 2)))
			spoonimage.GetComponent<Image> ().sprite = SpoonImg [3];
		else if ((moneyu.moneyspeed >= myPow (100000, 10, 1)))
			spoonimage.GetComponent<Image> ().sprite = SpoonImg [2];
		else if ((moneyu.moneyspeed >= myPow (100000, 10, 0))) //plastic
			spoonimage.GetComponent<Image> ().sprite = SpoonImg [1];
		
    }
    public void spoonClick()
    {
        popup.active = true;
    }
}
