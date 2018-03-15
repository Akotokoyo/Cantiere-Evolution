using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScript : MonoBehaviour {

    public GameObject creditpanel;

    public void ShowCredit()//Mostra il pannello dei crediti
    {
        creditpanel.transform.position= new Vector3(360, 540, 0);
    }
    public void HideCredit()//Nasconde il pannello dei crediti
    {
        creditpanel.transform.position = new Vector3(-750, 0, 0);
    }
}
