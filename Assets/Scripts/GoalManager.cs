using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalManager : MonoBehaviour {

	//connect managers
	public IconManager Item;
	public Moneyupdate MU;

	public const int LevelSize = 5;

	public GameObject goal_Popup; //connect goalpopup

	public GameObject goal_SpoonObj;
	public int goal_Spoon_Lv = 0; //업적 완료처리한 Spoon_Lv, SpoonManager의 스푼과 다름.

	public ulong[] MoneyTmp;
	public string[] Spoon_Text;

	public void Start(){
		MoneyTmp = new ulong[LevelSize] {100000, 500000, 1000000, 5000000, 10000000}; //10만 :녹수저
		Spoon_Text = new string[LevelSize] {"녹","동","은","금","다이아"};

	}
		

	public void Spoon_Update(int i){//Level에 따른, UI setting
		//goal_obj load
		goal_SpoonObj = GameObject.Find ("Goal (0)").gameObject;
		//일단 비활성화
		goal_SpoonObj.transform.FindChild("Button").GetComponent<Button> ().interactable = false;

		if (goal_Spoon_Lv == LevelSize) {//complete : LV4
			//만렙 >> 버튼 비활성화, 완료표시
			goal_SpoonObj.transform.FindChild ("Text").GetComponent<Text> ().text = "완료";
		} else {
			//레벨에 따른 이미지, 텍스트로 변환
			goal_SpoonObj.transform.FindChild ("Image").GetComponent<Image>().sprite = Resources.Load<Sprite> ("Goal_Img/spoon" + goal_Spoon_Lv) as Sprite;
			goal_SpoonObj.transform.FindChild ("Text").GetComponent<Text> ().text = Spoon_Text [goal_Spoon_Lv] + "수저 달성";
			//goal에서의 Spoon_Lv은 0인데, 금수저인 경우, 여러번 보상을 받아야 한다. 
			if (MU.moneyspeed >= MoneyTmp [goal_Spoon_Lv]) {
				goal_SpoonObj.transform.FindChild("Button").GetComponent<Button> ().interactable = true;
			}
		}
	}

	//Start Spoon_Popup
	public void goal_Initiate () {
		if (goal_Popup.activeSelf == true) {
			Spoon_Update (goal_Spoon_Lv);
		}
	}

	public void SpoonOnClick(int i){
		//item,LV +1
		Item.redbullcnt++;
		goal_Spoon_Lv++;
		Spoon_Update (i);
	}
}