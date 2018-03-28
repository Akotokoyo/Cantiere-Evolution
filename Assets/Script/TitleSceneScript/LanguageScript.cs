using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageScript : MonoBehaviour {

    public Image english;
    public Image italian;
    public Text Testo;
    public string sendlanguage;

    public void Start()
    {
        italian.color = new Color(255, 255, 255, 1);
        english.color = new Color(255, 255, 255, 0.5f);
        Testo.text = "Tap to Play";
    }

    public void onclick(bool lan)
    //Buttons for the language, the variable lan is:
    //TRUE For ENGLISH language
    //FALSE For ITALIAN language
    {
        if (lan)
            {
                english.color = new Color(255,255,255,0.5f);
                italian.color = new Color(255, 255, 255, 1);
                Testo.text = "Tap to Play";
                sendlanguage = "English";
        }
        else
            {
                italian.color = new Color(255, 255, 255, 0.5f);
                english.color = new Color(255, 255, 255, 1);
                Testo.text = "Premi Per Giocare";
                sendlanguage = "Italian";
        }
    }
}
