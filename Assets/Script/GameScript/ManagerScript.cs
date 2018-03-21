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
    public GameObject spotButton;

    public int oldManLimit;
    private int manCont;

    //GESTIONE SCORE
    public Text finalscore;
    private int attualscore;

    private int[] level = new int[10];
    private int levelindex;

    //VARIABILI INERENTI AL TOUCH
    RaycastHit hit;
    public float nextTouch;

    //VARIABILE DI LINGUAGGIO
    private string lang;
    string[] englishWorkerDialogue = { "But go to withdraw your pension?", "Pigeons are hungry", "Return to war instead of breaking us", "But do not you have grandchildren to watch?", "Go to disturb the state workers", "Do you want to come and do it yourself?", "but waiting the death like the other?", "In your day you were all abusive", "Look, go to the bar, I'll pay for it", "Oh, are you going?" };
    string[] italianWorkerDialogue = { "Ma non vai a ritirare la pensione?", "I piccioni hanno fame..", "Torna in guerra al posto di rompere a noi", "Ma non avete nipoti da guardare?", "Vai a disturbare gli operai statali", "Vuoi venire a farlo te?", "Ma aspettare la morte come gli altri no?", "Ai tuoi tempi eravate tutti abusivi", "Senti, vai al bar, te lo pago io", "Oh ma te ne vai?" };
    string[] englishOldManDialogue = { "Stupid Generation", "There's no religion anymore", "They were the Gypsies", "This job isn't good", "You must bring respect to those who have made war" };
    string[] italianOldManDialogue = { "Generazione incapace", "Non c'è più religione", "Sono stati gli Zinghiri", "Non si fa mica così quel lavoro lì", "Bisogna portare rispetto a chi ha fatto la guerra"};
    public GameObject workerDialogueButton;
    public Text workerDialogueText;
    public GameObject oldManDialogueButton;
    public Text oldManDialogueText;


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

        //LANGUAGE FROM ANOTHER SCRIPT, English or Italian
        //lang = PlayerPrefs.GetString("Language");     COMMENTO SOLO PER PROVARE INGLESE
        lang = "English";
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        if(true)
        {
            for (int i = 0; i < oldManLimit; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-3, 0), -1);
                Quaternion spawnRotation = Quaternion.identity;

            //What type of oldman will spawn
            if (oldmantype) {
//                Debug.Log("uno");
                Instantiate(oldman1, spawnPosition, spawnRotation);
                oldmantype = false;
                manCont++;
            }
            else if(!oldmantype)
            {
//                Debug.Log("due");
                Instantiate(oldman2, spawnPosition, spawnRotation);
                oldmantype = true;
                manCont++;
            }

            //Show and hide Spot Button
            if (manCont <= 2)
            {
                spotButton.gameObject.SetActive(true);
            }
            else if(manCont > 2)
            {
                spotButton.gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(spawnWait);
            }
        }
    }

    IEnumerator ShowMessageWorker(float delay)
    {
        int rand = Random.Range(0,10);
        workerDialogueButton.gameObject.SetActive(true);
        if (lang == "English") { 
            workerDialogueText.text = englishWorkerDialogue[rand];
        }
        else
        {
            workerDialogueText.text = italianWorkerDialogue[rand];
        }
        yield return new WaitForSeconds(delay);
        workerDialogueButton.gameObject.SetActive(false);
    }


    void Update()
    {
    //GESTIONE DEL TOUCH
        int i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began && Time.time > nextTouch)
            {
                nextTouch = Time.time + 6.0f;
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray.origin, ray.direction, out hit)) {
                    if(hit.transform.tag=="Worker") {
                        StartCoroutine(ShowMessageWorker(5.5f));
//                        finalscore.text = "" + attualscore;
//                        attualscore++;
                    }
                    else
                    {
                        Debug.Log("Other Touch");
                    }
                }
            }
            ++i;
        }

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
