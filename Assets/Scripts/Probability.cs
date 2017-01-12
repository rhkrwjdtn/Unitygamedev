using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Probability : MonoBehaviour {

	GameObject soil, plastic, bronze, silver, gold, diamond, platinum;
	GameObject rank1;
	// Use this for initialization

	void Start(){
		soil = GameObject.Find ("Panel").transform.FindChild ("Soil").gameObject;
		plastic = GameObject.Find ("Panel").transform.FindChild ("Plastic").gameObject;
		bronze = GameObject.Find ("Panel").transform.FindChild ("Bronze").gameObject;
		silver = GameObject.Find ("Panel").transform.FindChild ("Silver").gameObject;
		gold = GameObject.Find ("Panel").transform.FindChild ("Gold").gameObject;
		diamond = GameObject.Find ("Panel").transform.FindChild ("Diamond").gameObject;
		platinum = GameObject.Find ("Panel").transform.FindChild ("Platinum").gameObject;
	}

	public void ButtonClick () {


		if (soil.activeSelf || plastic.activeSelf|| bronze.activeSelf || silver.activeSelf || gold.activeSelf || platinum.activeSelf) {
			soil.SetActive (false);
			plastic.SetActive (false);
			bronze.SetActive (false);
			silver.SetActive (false);
			gold.SetActive (false);
			diamond.SetActive (false);
			platinum.SetActive (false);
		}
		
		int itemTypeRate = Random.Range(0, 100000);
	
	

		if (itemTypeRate <= 60000) {
			
			soil.SetActive (true);

		}else if (itemTypeRate <= 85000) {

			plastic.SetActive (true);

		}else if (itemTypeRate <= 92500) {


			bronze.SetActive (true);

		} else if (itemTypeRate <= 97000) {


			silver.SetActive (true);

		} else if (itemTypeRate <= 99000) {
			
			gold.SetActive (true);

		} else if (itemTypeRate <= 99990) {    
			
			diamond.SetActive (true);

		}else if (itemTypeRate <= 100000) {    

			platinum.SetActive (true);
		}

	}

}
/*

if (itemTypeRate <= 80000) {

	soil.SetActive (true);

}else if (itemTypeRate <= 92000) {

	plastic.SetActive (true);

}else if (itemTypeRate <= 97000) {


	bronze.SetActive (true);

} else if (itemTypeRate <= 99000) {


	silver.SetActive (true);

} else if (itemTypeRate <= 99900) {

	gold.SetActive (true);

} else if (itemTypeRate <= 99990) {    

	diamond.SetActive (true);

}else {    

	platinum.SetActive (true);
}
*/