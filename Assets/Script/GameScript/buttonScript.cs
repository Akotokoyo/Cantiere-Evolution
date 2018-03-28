using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class buttonScript : MonoBehaviour {

    public GameObject oldman1;
    public GameObject oldman2;
    private ManagerScript managerscript = new ManagerScript();

    private bool oldtype;
    private Vector3 spawnPosition;
    private Quaternion spawnRotation;

    public void onclick() {

        //Show The Advertisement
        Advertisement.Show();

        //Spawn 7 OldMan after advertising
        oldtype = false;

        for (int i = 0; i < 7; i++)
        {
            spawnPosition = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-3, 0), -1);
            spawnRotation = Quaternion.identity;
            if (oldtype)
            {
                Instantiate(oldman1, spawnPosition, spawnRotation);
                oldtype = false;
                managerscript.manCont++;
            }
            else if (!oldtype)
            {
                Instantiate(oldman2, spawnPosition, spawnRotation);
                oldtype = true;
                managerscript.manCont++;
            }
        }
    }
}
