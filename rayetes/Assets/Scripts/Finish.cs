using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {

    public Material a, b;
    public GameObject enchufe1, enchufe2, bola;
    public GameObject currentrep;

    // Update is called once per frame
    void Update () {
        if (currentrep == null)
        {
            if (enchufe1.GetComponent<Enchufecontroller>().power == true && enchufe2.GetComponent<Enchufecontroller>().power == true)
            {

                bola.GetComponent<Renderer>().material = b;
            }

            if (enchufe1.GetComponent<Enchufecontroller>().power == false || enchufe2.GetComponent<Enchufecontroller>().power == false)
            {

                bola.GetComponent<Renderer>().material = a;
            }
        }
    }
}
