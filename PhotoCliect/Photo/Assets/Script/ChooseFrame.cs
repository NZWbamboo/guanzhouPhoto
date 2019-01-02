using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseFrame : MonoBehaviour {
    public AnimationClip aniClip;
    public int inta;
    Transform frame;
    private static int ChangeInt;
	// Use this for initialization
	void Start () {
        frame = transform.root.transform.Find("PhotoPanel/Photo/Frame");
        this.GetComponent<Toggle>().onValueChanged.AddListener(delegate (bool ison) { ToogleEvent(ison); });
	}
	// Update is called once per frame
	void ToogleEvent( bool Ison) {
        if (Ison)
        {
            ChangeInt = inta;
            SelectPanelController.Frameint = inta;
       
            Debug.Log(inta);
        }
      
	}
 

}
