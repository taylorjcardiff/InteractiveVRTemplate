using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 
using UnityEngine.UI;

public class GVRTimeScript : MonoBehaviour {
    public Button btn;
    public Image circularprogressimage;
    public float eventTime = 3;
    bool gvrstatus;
    float gvrtimer;
    public UnityEvent GvrClick;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(gvrstatus == true) {
            gvrtimer = gvrtimer + Time.deltaTime;
            circularprogressimage.fillAmount = gvrtimer / eventTime;

            if(gvrtimer >= eventTime) 
            {
                GvrClick.Invoke();
            }
        }
	}

    public void GvrOnButton()
    {
        gvrstatus = true;
    }

    public void GvrOffButton()
    {
        gvrstatus = false;
        circularprogressimage.fillAmount = 0;
        gvrtimer = 0;
    }

}
