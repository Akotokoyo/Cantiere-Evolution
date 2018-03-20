using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour {

    public GameObject oldman1;
    public GameObject oldman2;
    public float spawnWait;
    public float startWait;
    private bool oldmantype;

    public int oldManLimit;
    private int manCont;

    //GESTIONE SCORE
    public float nexttouch;
    public Text finalscore;
    private int attualscore;

    private int[] level = new int[10];
    private int levelindex;

    //VARIABILI INERENTI AL TOUCH
    RaycastHit hit;

    void Start()
    {
        //GESTIONE NUMERO VECCHIETTI
        manCont = 0;
        oldmantype = false;

        //LISTA LIVELLI
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
        attualscore = 0;

        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        if(manCont < 10)
        {
                for (int i = 0; i < oldManLimit; i++)
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-3, 0), -1);
                    Quaternion spawnRotation = Quaternion.identity;
                    
                if (oldmantype) {
                    Debug.Log("uno");
                    Instantiate(oldman1, spawnPosition, spawnRotation);
                    oldmantype = false;
                }
                else
                {
                    Debug.Log("due");
                    Instantiate(oldman2, spawnPosition, spawnRotation);
                    oldmantype = true;
                }
                yield return new WaitForSeconds(spawnWait);
                }
        }
    }


    //GESTIONE DEL TOUCH
    void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                if (Physics.Raycast(ray)) { 
                    Debug.Log("TUTTO REGOLARE"); finalscore.text = "" + attualscore;
                attualscore++;
                }
            }
            ++i;
        }





        /*
         *  
         * 
         * 
        //Se clicchi, parte animazione di dialogo
        //        if (Input.GetButton("Fire1") && Time.time > nexttouch)
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D raycastHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (raycastHit.collider.gameObject.name == "Worker")
                //if (raycastHit.collider != null && raycastHit.collider.tag == "Worker")
            {
                nexttouch = Time.time + 1.5f;
                    Debug.Log("Worker Touched");
                finalscore.text = ""+attualscore;
                attualscore++;
                }
                else if(raycastHit.collider == null)
                {
                    Debug.Log("NULLO");
                }
            else
            {
                Debug.Log("Altro");
            }


        }
    */

        //Se punteggio raggiunge l'obiettivo, fai partire animazione
        if (attualscore > level[levelindex])
        {
            attualscore = 0;
            finalscore.text = (attualscore + "/" + level[levelindex]);
            levelindex++;
        }
        else
        {
            finalscore.text = (attualscore + "/" + level[levelindex]);
        }
    }

}
