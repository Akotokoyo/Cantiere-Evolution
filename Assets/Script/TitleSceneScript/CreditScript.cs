using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScript : MonoBehaviour {

    public GameObject creditpanel;

    public void ShowCredit()//Show Credit Panel
    {
        creditpanel.transform.position= new Vector3(550, 980, 0);
    }
    public void HideCredit()//Hide Credit Panel
    {
        creditpanel.transform.position = new Vector3(-650, 0, 0);
    }
}
