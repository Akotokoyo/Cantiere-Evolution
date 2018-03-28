using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable] //If isn't exist, Unity don't know what is a class
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
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //SPOSTA TIPO VERSO CANTIERE, Fai partire animazione, e successivamente aumenta lo score;
        }
    }

    //Function for move OldMan
    void Move()
    {
        int rand = Random.Range(1, 5);
        //1 = LEFT
        //2 = UP
        //3 = RIGHT
        //4 = DOWN

        if (rand == 1)
        {
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
