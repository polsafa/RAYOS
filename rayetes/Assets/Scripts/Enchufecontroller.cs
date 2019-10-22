using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enchufecontroller : MonoBehaviour {

    public Material a, b;
    public bool power;
    public GameObject meta;
    public GameObject currentrep;

    private void Start()
    {
        power = false;
    }

    private void Update()
    {
        if(currentrep != null)
        {
            this.GetComponent<Renderer>().material = b;
        }
        else
        {
            this.GetComponent<Renderer>().material = a;
        }

       
    }
}
