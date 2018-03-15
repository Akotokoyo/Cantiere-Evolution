using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageScript : MonoBehaviour {

    public Image english;
    public Image italian;
    public Text Testo;

    public void Start()
    {
        italian.color = new Color(255, 255, 255, 1);
        english.color = new Color(255, 255, 255, 0.5f);
        Testo.text = "Tap to Play";
    }

    public void onclick(bool lan)
        //I Bottoni con le lingue, sono settati in modo che se lan(language) è:
        //TRUE La lingua settata è l'INGLESE
        //FALSE La lingua settata è l'ITALIANO
        {
            if (lan)
            {
                english.color = new Color(255,255,255,0.5f);
                italian.color = new Color(255, 255, 255, 1);
                Testo.text = "Tap to Play";
        }
        else
            {
                italian.color = new Color(255, 255, 255, 0.5f);
                english.color = new Color(255, 255, 255, 1);
                Testo.text = "Premi Per Giocare";
        }
    }
}
