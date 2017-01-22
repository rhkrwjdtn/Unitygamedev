using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GirlFriendBtn1 : MonoBehaviour {

    public UnityEngine.UI.Button Handbtn;
    public UnityEngine.UI.Button Imaginebtn;
    public UnityEngine.UI.Button dollbtn;
    public UnityEngine.UI.Button UnivGFbtn;
    public UnityEngine.UI.Button Foreignbtn;
    public UnityEngine.UI.Button Trainnerbtn;
    public GameObject GirlFriend = null;
    public GameObject GFHand = null;
    public GameObject GFImagine = null;
    public GameObject GFDOll = null;
    public GameObject GFForeign = null;
    public GameObject GFTrainner = null;
    public Text Handbtn_text;
    public bool HandExist=false;
    public bool ImagineExist = false;
    public bool dollExist = false;
    public bool UnivExist = false;
    public bool ForeignExist = false;
    public bool TrainnerExist = false;

	// Use this for initialization
	void Start () {
		if(Handbtn==null)
        {
            Handbtn = gameObject.GetComponent<UnityEngine.UI.Button>();

        }
        if(Imaginebtn==null)
        {
            Imaginebtn = gameObject.GetComponent<UnityEngine.UI.Button>();
        }
        if (dollbtn == null)
        {
            dollbtn = gameObject.GetComponent<UnityEngine.UI.Button>();
        }
        if (UnivGFbtn == null)
        {
            UnivGFbtn = gameObject.GetComponent<UnityEngine.UI.Button>();
        }
        if (Foreignbtn == null)
        {
            Foreignbtn = gameObject.GetComponent<UnityEngine.UI.Button>();
        }
        if (Trainnerbtn == null)
        {
            Trainnerbtn = gameObject.GetComponent<UnityEngine.UI.Button>();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
    public void HandbtnClick()
    {
        if (HandExist == false)
        {
            GFHand.active = true;
            HandExist = true;
            //Handbtn_text.text = "헤어지기";
        }
        
        else if(HandExist==true)
        {
            GFHand.active = false;
            HandExist = false;
            //Handbtn_text.text = "사귀기";
        }
        
    }
    public void ImaginebtnClick()
    {
        if (ImagineExist == false)
        {
            GFImagine.active = true;
            ImagineExist = true;
        }
        else if(ImagineExist==true)
        {
            GFImagine.active = false;
            ImagineExist = false;
        }
    }
    public void DollbtnClick()
    {
        if (dollExist == false)
        {
            GFDOll.active = true;
            dollExist = true;
        }
        else if(dollExist==true)
        {
            GFDOll.active = false;
            dollExist = false;
        }
    }
    public void UnivbtnClick()
    {
        if (UnivExist == false)
        {
            GirlFriend.active = true;
            UnivExist = true;
        }
        else if(UnivExist==true)
        {
            GirlFriend.active = false;
            UnivExist = false;
        }
    }
    public void ForeignbtnClick()
    {
        if (ForeignExist == false)
        {
            GFForeign.active = true;
            ForeignExist = true;
        }
        else if(ForeignExist==true)
        {
            GFForeign.active = false;
            ForeignExist = false;
        }
    }
    public void TrainnerbtnClick()
    {
        if (TrainnerExist == false)
        {
            GFTrainner.active = true;
            TrainnerExist = true;
        }
        else if(TrainnerExist==true)
        {
            GFTrainner.active = false;
            TrainnerExist = false;
        }
    }

}
