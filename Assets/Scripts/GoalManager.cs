using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalManager : MonoBehaviour {

	//connect managers
	public IconManager myItem;
	public Moneyupdate MU;
	public TransMoney myTransMoney;
	public EmploymentManager myEmp;
	public CharacterInfo myqudtls;
	public RebirthManager myRebirth;

	public const int LevelSize = 5;
	public const int SIZE = 8;

	public GameObject goal_Popup; //connect goalpopup
	/*
	public GameObject goal_SpoonObj;
	public int goal_Spoon_Lv = 0; //업적 완료처리한 Spoon_Lv, SpoonManager의 스푼과 다름.

	public GameObject goal_TotalGoldObj;
	public int goal_TotalGold_Lv = 0;
	public GameObject goal_ClickGoldObj;
	public int goal_ClickGold_Lv = 0;

	public GameObject goal_PotionObj;
	public int goal_Potion_Lv = 0; 
	public GameObject goal_PizzaPieceObj;
	public int goal_PizzaPiece_Lv = 0; 

	public GameObject goal_qudtlsLVObj;
	public int goal_qudtlsLV_Lv = 0; 
	public GameObject goal_TotalEmpObj;
	public int goal_TotalEmp_Lv = 0;

	public GameObject goal_RebirthObj;
	public int goal_Rebirth_Lv = 0;
	*/
	public GameObject[] GoalObj = new GameObject[SIZE];
	public int[] Goal_LV = new int[SIZE] {0,0,0,0,0,0,0,0};

	public ulong[] MoneyTmp;
	public int EmployeesLvTmp;
	public string[] Spoon_Text;
	/*
	업적
5단계(?)
1. 클릭당 돈 N=1만, 10만,100만, 1000만, 1억
----2. 수저 단계마다 녹동은금다 
3. 캐릭터 레벨 100, 200 ,300 ,500 ,800
4. 누적 환생 횟수 5, 10, 20 ,40 ,80
6. 보유 드링크 5, 10, 20, 40, 80
7. 보유 한조 각 5, 10, 20, 40, 80
8. 보유 파워D 5, 10, 15, 20, 25
9. 보유 피자 5, 10, 15, 20, 25
12. 알바 레벨 총 합 100, 200 ,400 ,800 ,1600

	*/
	public void Start(){
		MoneyTmp = new ulong[LevelSize] {100000, 500000, 1000000, 5000000, 10000000}; //10만 :녹수저
		Spoon_Text = new string[LevelSize] {"녹","동","은","금","다이아"};
		for (int i = 0; i < SIZE; i++)
			GoalObj[i] = null;
	}

	public void Goal_Update(int i){
		GoalObj[i] = GameObject.Find ("Goal ("+i+")").gameObject;
		GoalObj[i].transform.FindChild("Button").GetComponent<Button> ().interactable = false;

		if (Goal_LV[i] == LevelSize) {
			GoalObj[i].transform.FindChild ("Text").GetComponent<Text> ().text = "완료";
		} else {
				
			switch(i){
			case 0:
				{
					//레벨에 따른 이미지, 텍스트로 변환
					GoalObj[i].transform.FindChild ("Image").GetComponent<Image>().sprite = Resources.Load<Sprite> ("Goal_Img/spoon" + Goal_LV[i]) as Sprite;
					GoalObj[i].transform.FindChild ("Text").GetComponent<Text> ().text = Spoon_Text [Goal_LV[i]] + "수저 달성";
					//goal에서의 Spoon_Lv은 0인데, 금수저인 경우, 여러번 보상을 받아야 한다. 
					if (MU.moneyspeed >= MoneyTmp [Goal_LV[i]]) 
						GoalObj[i].transform.FindChild("Button").GetComponent<Button> ().interactable = true;
				}
				break;
			case 1:
				{
					GoalObj[i].transform.FindChild ("Text").GetComponent<Text> ().text = "클릭당 골드 "+ myTransMoney.strTransMoney((ulong)((int)Mathf.Pow(10f,(float)Goal_LV[i])*10000)) +" 달성";	
					if (MU.touchspeed >= (ulong)((int)Mathf.Pow(10f,(float)Goal_LV[i])*10000)) {
						GoalObj[i].transform.FindChild("Button").GetComponent<Button> ().interactable = true;
					}	
				}
				break;
			case 2:
				{
					GoalObj[i].transform.FindChild ("Text").GetComponent<Text> ().text = "보유 골드 "+ myTransMoney.strTransMoney((ulong)((int)Mathf.Pow(100f,(float)Goal_LV[i])*1000000)) +" 달성";
					if (MU.money >= (ulong)((int)Mathf.Pow(100f,(float)Goal_LV[i])*1000000) ) 
						GoalObj[i].transform.FindChild("Button").GetComponent<Button> ().interactable = true;
					
				}
				break;
			case 3:
				{
					GoalObj[i].transform.FindChild ("Text").GetComponent<Text> ().text = "보유 에너지드링크 "+ ((int)Mathf.Pow(2f,(float)Goal_LV[i])*5) +"개 달성";	
					if (myItem.redbullcnt >= ((int)Mathf.Pow(2f,(float)Goal_LV[i])*5)) {
						GoalObj[i].transform.FindChild("Button").GetComponent<Button> ().interactable = true;
					}
				}
				break;
			case 4:
				{
					GoalObj[i].transform.FindChild ("Text").GetComponent<Text> ().text = "보유 한조 각 "+ ((int)Mathf.Pow(2f,(float)Goal_LV[i])*5) +"개 달성";	
					if (myItem.smallpizzacnt >= ((int)Mathf.Pow(2f,(float)Goal_LV[i])*5)) {
						GoalObj[i].transform.FindChild("Button").GetComponent<Button> ().interactable = true;
					}
				}
				break;
			case 5:
				{
					GoalObj[i].transform.FindChild ("Text").GetComponent<Text> ().text = "둥신 "+ ((int)Mathf.Pow(2f,(float)Goal_LV[i])*50) +"LV 달성";	
					if ((int)myqudtls.JugallumLev >= ((int)Mathf.Pow(2f,(float)Goal_LV[i])*50)) {
						GoalObj[i].transform.FindChild("Button").GetComponent<Button> ().interactable = true;
					}
				}
				break;
			case 6:
				{
					GoalObj[i].transform.FindChild ("Text").GetComponent<Text> ().text = "알바생 총 "+ ((int)Mathf.Pow(2f,(float)Goal_LV[i])*100) +"LV 달성";	
					if (EmployeesLvTmp >= ((int)Mathf.Pow(2f,(float)Goal_LV[i])*100)) {
						GoalObj[i].transform.FindChild("Button").GetComponent<Button> ().interactable = true;
					}
				}
				break;
			case 7:
				{
					GoalObj[i].transform.FindChild ("Text").GetComponent<Text> ().text = "누적 환생 " + ((int)Mathf.Pow(2f,(float)Goal_LV[i])*10) + "회 달성";	
					if (myRebirth.RebirthCount >= ((int)Mathf.Pow(2f,(float)Goal_LV[i])*10)) {
						GoalObj[i].transform.FindChild ("Button").GetComponent<Button> ().interactable = true;
					}
				}
				break;
			default:
				Debug.Log ("defaultVALUE");
				break;
			}
		}
	}

	//Start Spoon_Popup
	public void goal_Initiate () {
		if (goal_Popup.activeSelf == true) {
			EmployeesLvTmp = 0;
			for (int i = 0; i < 11; i++) 
				EmployeesLvTmp += (int)myEmp.EmployerLevel [i];
			Debug.Log ("알바총레벨 :" + EmployeesLvTmp);

			for (int i = 0; i < SIZE; i++) {
				Goal_Update (i);
			}
			/*
			Spoon_Update (goal_Spoon_Lv);

			ClickGold_Update (goal_ClickGold_Lv);
			TotalGold_Update (goal_TotalGold_Lv);
		
			Potion_Update (goal_Potion_Lv);
			PizzaPiece_Update (goal_PizzaPiece_Lv);

			qudtlsLV_Update (goal_qudtlsLV_Lv);
			TotalEmp_Update (goal_TotalEmp_Lv);
			*/
		}
	}

	public void GoalOnClick(int i){
		myItem.redbullcnt++;
		Goal_LV[i]++;
		Goal_Update (i);
	}

}

/*		
	//수저
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

//click당 돈
public void ClickGold_Update(int i){
	goal_PotionObj = GameObject.Find ("Goal (1)").gameObject;
	goal_PotionObj.transform.FindChild("Button").GetComponent<Button> ().interactable = false;

	if (goal_Potion_Lv == LevelSize) {
		goal_PotionObj.transform.FindChild ("Text").GetComponent<Text> ().text = "완료";
	} else {
		goal_PotionObj.transform.FindChild ("Text").GetComponent<Text> ().text = "클릭당 골드 "+ myTransMoney.strTransMoney((ulong)(10^i)*10000) +"원 달성";	
		if (MU.touchspeed >= (ulong)(10^i)*10000) {
			goal_PotionObj.transform.FindChild("Button").GetComponent<Button> ().interactable = true;
		}
	}
}

//총 자산
public void TotalGold_Update(int i){
	goal_TotalGoldObj = GameObject.Find ("Goal (2)").gameObject;
	goal_TotalGoldObj.transform.FindChild("Button").GetComponent<Button> ().interactable = false;

	if (goal_TotalGold_Lv == LevelSize) {
		goal_TotalGoldObj.transform.FindChild ("Text").GetComponent<Text> ().text = "완료";
	} else {
		goal_TotalGoldObj.transform.FindChild ("Text").GetComponent<Text> ().text = "(미완)총 자산 "+ myTransMoney.strTransMoney((ulong)(100^i)*1000000) +"원 달성";
		if (MU.money >= (ulong)(100^i)*1000000) {
			goal_PotionObj.transform.FindChild("Button").GetComponent<Button> ().interactable = true;
		}
	}
}

//redbull
public void Potion_Update(int i){
	goal_PotionObj = GameObject.Find ("Goal (3)").gameObject;
	goal_PotionObj.transform.FindChild("Button").GetComponent<Button> ().interactable = false;

	if (goal_Potion_Lv == LevelSize) {
		goal_PotionObj.transform.FindChild ("Text").GetComponent<Text> ().text = "완료";
	} else {
		goal_PotionObj.transform.FindChild ("Text").GetComponent<Text> ().text = "보유 에너지드링크 "+ (2^(i))*5 +"개 달성";	
		if (myItem.redbullcnt >= (2^(i))*5) {
			goal_PotionObj.transform.FindChild("Button").GetComponent<Button> ().interactable = true;
		}
	}
}

//Pizza 1piece
public void PizzaPiece_Update(int i){
	goal_PizzaPieceObj = GameObject.Find ("Goal (4)").gameObject;
	goal_PizzaPieceObj.transform.FindChild("Button").GetComponent<Button> ().interactable = false;

	if (goal_PizzaPiece_Lv == LevelSize) {
		goal_PizzaPieceObj.transform.FindChild ("Text").GetComponent<Text> ().text = "완료";
	} else {
		goal_PizzaPieceObj.transform.FindChild ("Text").GetComponent<Text> ().text = "보유 한조 각 "+ (2^(i))*5 +"개 달성";	
		if (myItem.smallpizzacnt >= (2^(i))*5) {
			goal_PizzaPieceObj.transform.FindChild("Button").GetComponent<Button> ().interactable = true;
		}
	}
}

//qudtlsLV
public void qudtlsLV_Update(int i){
	goal_qudtlsLVObj = GameObject.Find ("Goal (5)").gameObject;
	goal_qudtlsLVObj.transform.FindChild("Button").GetComponent<Button> ().interactable = false;

	if (goal_qudtlsLV_Lv == LevelSize) {
		goal_qudtlsLVObj.transform.FindChild ("Text").GetComponent<Text> ().text = "완료";
	} else {
		goal_qudtlsLVObj.transform.FindChild ("Text").GetComponent<Text> ().text = "둥신 "+ (2^(i))*50 +"LV 달성";	
		if ((int)myqudtls.JugallumLev >= (2^(i))*50) {
			goal_qudtlsLVObj.transform.FindChild("Button").GetComponent<Button> ().interactable = true;
		}
	}
}

//total Employees LV
public void TotalEmp_Update(int i){
	goal_TotalEmpObj = GameObject.Find ("Goal (6)").gameObject;
	goal_TotalEmpObj.transform.FindChild("Button").GetComponent<Button> ().interactable = false;

	if (goal_TotalEmp_Lv == LevelSize) {
		goal_TotalEmpObj.transform.FindChild ("Text").GetComponent<Text> ().text = "완료";
	} else {
		goal_TotalEmpObj.transform.FindChild ("Text").GetComponent<Text> ().text = "알바생 총 "+ (2^(i))*100 +"LV 달성";	
		if (EmployeesLvTmp >= (2^(i))*100) {
			goal_TotalEmpObj.transform.FindChild("Button").GetComponent<Button> ().interactable = true;
		}
	}
}

//REbirth
public void Rebirth_Update(int i){
	goal_RebirthObj = GameObject.Find ("Goal (7)").gameObject;
	goal_RebirthObj.transform.FindChild("Button").GetComponent<Button> ().interactable = false;

	if (goal_Rebirth_Lv == LevelSize) {
		goal_RebirthObj.transform.FindChild ("Text").GetComponent<Text> ().text = "완료";
	} else {
		goal_RebirthObj.transform.FindChild ("Text").GetComponent<Text> ().text = "(미완)누적 환생 "+ (2^(i))*10 +"회 달성";	
		if (myRebirth.RebirthCount >= (2^(i))*10) {
			goal_RebirthObj.transform.FindChild("Button").GetComponent<Button> ().interactable = true;
		}
	}
}


public void SpoonOnClick(int i){	//item,LV +1
	myItem.redbullcnt++;
	goal_Spoon_Lv++;
	Spoon_Update (i);
}
public void ClickGoldOnClick(int i){
	myItem.redbullcnt++;
	goal_ClickGold_Lv++;
	ClickGold_Update (i);
}
public void TotalGoldOnClick(int i){
	myItem.redbullcnt++;
	goal_TotalGold_Lv++;
	TotalGold_Update (i);
}
public void PotionOnClick(int i){
	myItem.redbullcnt++;
	goal_Potion_Lv++;
	Potion_Update (i);
}
public void PizzaPieceOnClick(int i){
	myItem.redbullcnt++;
	goal_PizzaPiece_Lv++;
	PizzaPiece_Update (i);
}
public void qudtlsLVOnClick(int i){
	myItem.redbullcnt++;
	goal_qudtlsLV_Lv++;
	qudtlsLV_Update (i);
}
public void TotalEmpOnClick(int i){
	myItem.redbullcnt++;
	goal_TotalEmp_Lv++;
	TotalEmp_Update (i);
}

*/