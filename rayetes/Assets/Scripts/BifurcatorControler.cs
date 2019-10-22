using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BifurcatorControler : MonoBehaviour {

    public GameObject bifur1,bifur2;
    public GameObject currentrep;
    public Material a,b;

    private void Update()
    {
        if (currentrep != null)
        {
            bifur1.GetComponent<LineRenderer>().enabled = false;
            bifur2.GetComponent<LineRenderer>().enabled = false;
            bifur1.GetComponent<Renderer>().material = a;
            bifur2.GetComponent<Renderer>().material = a;

        }
    }
}
