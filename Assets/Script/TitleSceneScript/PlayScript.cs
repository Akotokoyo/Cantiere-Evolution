using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour {

    public static string language ="English";
    public void PressPlay()
    {
        if (GameObject.Find("LanguageSettings").GetComponent<LanguageScript>().sendlanguage=="")
        {
            language = "English";
        }
        else
        {
            language = GameObject.Find("LanguageSettings").GetComponent<LanguageScript>().sendlanguage;
        }
        PlayerPrefs.SetString("Language", language);
        SceneManager.LoadScene("Cantiere Evolution");
    }
}
