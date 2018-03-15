using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour {

    public GameObject oldman1;
    public GameObject oldman2;
    public int oldmancont;
    public float spawnWait;
    public float startWait;
    public Text scoreText;
    public Text finalText;
    private int score;
    private bool oldmantype;
    private int totalMan;

    void Start()
    {
        totalMan = 0;
        oldmantype = false;
        score = 0;
   //     UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        if(totalMan<10)
        {
                for (int i = 0; i < oldmancont; i++)
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
    public void AddScore(int newScore)
    {
        score += newScore;
   //     UpdateScore();
    }

   /* void UpdateScore()
    {
        scoreText.text = "Score : " + score;
        finalText.text = "Final Score : " + score;
    }*/
}
