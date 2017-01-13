using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Probability : MonoBehaviour {

	GameObject soil, plastic, bronze, silver, gold, diamond, platinum;
	GameObject rank1;
	// Use this for initialization



	public void ButtonClick () {
		soil = GameObject.Find ("ProbabilityPopup").transform.FindChild ("Soil").gameObject;
		plastic = GameObject.Find ("ProbabilityPopup").transform.FindChild ("Plastic").gameObject;
		bronze = GameObject.Find ("ProbabilityPopup").transform.FindChild ("Bronze").gameObject;
		silver = GameObject.Find ("ProbabilityPopup").transform.FindChild ("Silver").gameObject;
		gold = GameObject.Find ("ProbabilityPopup").transform.FindChild ("Gold").gameObject;
		diamond = GameObject.Find ("ProbabilityPopup").transform.FindChild ("Diamond").gameObject;
		platinum = GameObject.Find ("ProbabilityPopup").transform.FindChild ("Platinum").gameObject;

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