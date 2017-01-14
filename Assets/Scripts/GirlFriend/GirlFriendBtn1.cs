using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GirlFriendBtn1 : MonoBehaviour {

    public UnityEngine.UI.Button btn;
    public GameObject GirlFriend = null;
    public Text btn_text;

	// Use this for initialization
	void Start () {
		if(btn==null)
        {
            btn = gameObject.GetComponent<UnityEngine.UI.Button>();

        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ShowImage()
    {
        GirlFriend.active = true;

    }
}
