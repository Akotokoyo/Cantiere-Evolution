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

    //VARIABILI INERENTI AL TOUCH
    RaycastHit hit;

    //VARIABILI PER FAR MUOVERE IL VECCHIETTO
    private GameObject target;
    private float smoothTime = 0.5F;
    private Vector3 velocity = Vector3.zero;
    private bool startMove;



    // Use this for initialization
    void Start () {
        startImage = GetComponent<Sprite>();
        InvokeRepeating("Move", 3.0f, 1.0f);

        target = GameObject.Find("Worker");
        startMove = false;
    }

    // Update is called once per frame
    void Update () {

        //SPOSTA TIPO VERSO CANTIERE, Fai partire animazione, e successivamente aumenta lo score;
        int i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray.origin, ray.direction, out hit) && hit.collider.gameObject.Equals(this.gameObject)) {
                    startMove = true;
                }
            }
            ++i;
        }
        //if oldman touched, move object to worker, and disappear
        if (startMove)
        {
 
            Vector3 targetPosition = target.transform.TransformPoint(new Vector3(0, 0, 0));
            this.transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
//            Debug.Log("OLDMAN TOUCHED");
            if (this.transform.position.x <= 0.5f && this.transform.position.y >= 1.5f)
            {
                startMove = false;
//                Debug.Log("ARRIVE");
                Destroy(gameObject);
            }

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
