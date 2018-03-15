using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable] //Serve per serializzare la classe Boundary, se non lo metto, unity non sa a cosa serve la classe
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class OldManScript : MonoBehaviour {

    public Boundary boundary;
    Sprite startImage;
    public Sprite manleft, manup, manright, mandown;
    // Use this for initialization
    void Start () {
        startImage = GetComponent<Sprite>();
        InvokeRepeating("Move", 3.0f, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {

    }
    void Move()
    {
//        int rand = 1; PROVA SOLO AD ANDARE A SINISTRA.
        int rand = Random.Range(1, 5);
        //1 = LEFT
        //2 = UP
        //3 = RIGHT
        //4 = DOWN

        if (rand == 1)
        {
    //        Debug.Log("LEFT"); 
            this.GetComponent<SpriteRenderer>().sprite = manleft; 
            transform.Translate(Vector2.left * Time.deltaTime*20);
            GetComponent<Rigidbody>().position = new Vector3(
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),//Collezione di funzioni matematiche, Clamp prende un asse e ci setta il massimo e minimo in cui deve stare.
                Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax),
                0.0f//Collezione di funzioni matematiche
            );
        }
        else if (rand == 2)
        {
        //    Debug.Log("UP");
            this.GetComponent<SpriteRenderer>().sprite = manup;
            transform.Translate(Vector2.up * Time.deltaTime*20);
            GetComponent<Rigidbody>().position = new Vector3(
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),//Collezione di funzioni matematiche, Clamp prende un asse e ci setta il massimo e minimo in cui deve stare.
                Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax),
                0.0f//Collezione di funzioni matematiche
            );
        }
        else if (rand == 3)
        {
    //        Debug.Log("RIGHT");
            this.GetComponent<SpriteRenderer>().sprite = manright;
            transform.Translate(Vector2.right * Time.deltaTime*20);
            GetComponent<Rigidbody>().position = new Vector3(
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),//Collezione di funzioni matematiche, Clamp prende un asse e ci setta il massimo e minimo in cui deve stare.
                Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax),
                0.0f//Collezione di funzioni matematiche
            );
        }
        else if (rand == 4)
        {
   //         Debug.Log("DOWN");
            this.GetComponent<SpriteRenderer>().sprite = mandown;
            transform.Translate(Vector2.down * Time.deltaTime*20);
            GetComponent<Rigidbody>().position = new Vector3(
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),//Collezione di funzioni matematiche, Clamp prende un asse e ci setta il massimo e minimo in cui deve stare.
                Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax),
                0.0f//Collezione di funzioni matematiche
            );
        }
    }
}
