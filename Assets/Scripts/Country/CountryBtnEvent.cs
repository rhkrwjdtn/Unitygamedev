using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseButtonEvent : MonoBehaviour {
	public const int SIZE=7;
	//house, icon img, btn obj
	public GameObject[] countryObj = new GameObject[SIZE];
	public GameObject[] imgObj = new GameObject[SIZE];
	public GameObject[] btnObj = new GameObject[SIZE];
	public GameObject countryPopup;

	//각각 에 해당하는 가격
    public ulong[] BG_Price = new ulong[SIZE];
    //구매 여부
    public bool[] BG_BuyList = new bool[SIZE];
	public ulong money=0;
	
    void Awake(){
		for (int i = 0; i < SIZE; i++) {
            countryObj[i] = null;
			imgObj[i] = null;
			btnObj[i] = null;
		}
	}

    public void houseInitiate()
    {
        if (countryPopup.activeSelf == true)
        {
            for (int i = 0; i < SIZE; i++) 
            {
                //House,iconimg,btn오브젝트
                houseObj[i] = GameObject.Find("House (" + i + ")").gameObject;
                imgObj[i] = houseObj[i].transform.FindChild("Image").gameObject;
                btnObj[i] = houseObj[i].transform.FindChild("HouseButton (" + i + ")").gameObject;
            }
        }
    }
	void Update () {
		Moneyupdate MU= GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
		money = MU.money;
		//if(GameObject.Find ("HousePopup").activeSelf == true)
		if(housepopup.activeSelf==true)
			HouseCheck (money);
	}

	public void HouseCheck(ulong money){
		for (int i = 0; i < SIZE; i++) {
			//돈 있을 때,
			if (money > BG_Price [i]) {
				//이미 구매한 경우
				if (BG_BuyList [i] == false) {
					//text-->구매완료 
					houseObj[i].transform.GetChild(1).GetComponent<Text>().text = "구매 완료";
					//어둡게
					houseObj[i].GetComponent<Image> ().color = new Color (0.6f, 0.6f, 0.6f, 1);
					//컬러
					imgObj[i].GetComponent<Image> ().sprite = Resources.Load<Sprite> ("bg_icon/bg_icon_" + i) as Sprite;
					//버튼 비활성화
					btnObj[i].SetActive(false);
				}
				//돈도 있고, 안샀다면,
				else {
					houseObj [i].transform.GetChild (1).GetComponent<Text> ().text = BG_Price[i]+"원";
					//밝게
					houseObj[i].GetComponent<Image> ().color = new Color (154 / 255, 154 / 255, 154 / 255, 154 / 255);
					//컬러아이콘
					imgObj[i].GetComponent<Image> ().sprite = Resources.Load<Sprite> ("bg_icon/bg_icon_" + i) as Sprite;
					//버튼 활성화
					btnObj[i].SetActive(true);

				}
			}
			//살 돈 없을 때,
			else {
				houseObj [i].transform.GetChild (1).GetComponent<Text> ().text = BG_Price[i]+"원";
				//어둡게
				houseObj[i].GetComponent<Image> ().color = new Color (0.6f, 0.6f, 0.6f, 1);
				//흑백아이콘
				imgObj[i].GetComponent<Image> ().sprite = Resources.Load<Sprite> ("bg_icon/sel_bg_icon_" + i) as Sprite;
				//살 돈 없고, 이미 구매한 경우
				if (BG_BuyList[i]==false) {
					//text-->구매완료 
					houseObj[i].transform.GetChild(1).GetComponent<Text>().text = "구매 완료";
					//어둡게
					houseObj[i].GetComponent<Image> ().color = new Color (0.6f, 0.6f, 0.6f, 1);
					//컬러
					imgObj[i].GetComponent<Image> ().sprite = Resources.Load<Sprite> ("bg_icon/bg_icon_" + i) as Sprite;
					//버튼 비활성화
					btnObj[i].SetActive(false);
				} 
				//아직 구매 안한 경우
				else {
					//버튼 비활성화
					btnObj[i].SetActive(false);
				}	
			}
		}
	}

	//Button onClick event
	public void setBG (int btn){
		//if (money > BG_Price [btn]) {
			HouseMoneyEvent (btn);
			HouseChangeBG (btn);
			changeBGBuyEnable (btn);
			//배경 오브젝트의 스프라이트를 변경
			GameObject.Find ("Background").GetComponent<Image> ().sprite = bg;
		//}
	}
	public void HouseMoneyEvent(int sel_BG){
		//MoneyManager에서 House의 가격에 따라 MoneyUpdate
		Moneyupdate MU= GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
		MU.money -= BG_Price[sel_BG];
		Debug.Log (money);
	}
	public void HouseChangeBG(int sel_BG){
		//리소스에서 배경파일 로드
		bg = Resources.Load<Sprite> ("bg_img/bg_"+sel_BG) as Sprite;
		Debug.Log ("btn "+sel_BG+"_onClick");
	}
	//구매한 경우 false로 표시 해줌
	public void changeBGBuyEnable(int sel_BG){
		BG_BuyList [sel_BG] = !BG_BuyList [sel_BG];
	}
	//나중에 판매할 경우 이 함수 사용
	public void btnEnable(int i){
		btnObj[i].SetActive(true);
	}
}	
