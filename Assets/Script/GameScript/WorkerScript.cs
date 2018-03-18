using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerScript : MonoBehaviour {

    public float nextTouch;
    public Text score;

    private int[] level = new int[9];
    private int levelindex;

	// Use this for initialization
	void Start () {
        level[0] = 30;
        level[1] = 60;
        level[2] = 100;
        level[3] = 200;
        level[4] = 400;
        level[5] = 500;
        level[6] = 650;
        level[7] = 800;
        level[8] = 1000;
        level[9] = 1200;
        levelindex = 0;
    }

    // Update is called once per frame
    void Update () {
        //Se clicchi, parte animazione di dialogo
		if(Input.GetButton("Fire1") && Time.time > nextTouch)
        {
            nextTouch = Time.time + 1.5f;
        //    score.text = ""+numero;
        }

        //Se punteggio raggiunge l'obiettivo, fai partire animazione
        if (int.Parse(score.text) > level[levelindex])
        {
            levelindex++;
        }
    }
}
