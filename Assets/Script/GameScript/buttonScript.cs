using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonScript : MonoBehaviour {

   

	// Use this for initialization
	void Start () {
		
	}

    public Text testo;
    public void onclick() {
        if (testo.text == "Button")
        {
            testo.text = "New Text";
        }
        else if(testo.text == "New Text")
        {
            testo.text = "Button";
        }
    }
}
