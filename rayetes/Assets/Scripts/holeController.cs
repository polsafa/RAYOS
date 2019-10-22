using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holeController : MonoBehaviour {

    public GameObject exit;
    public GameObject currentrep;

    private void Update()
    {
        if(currentrep == null)
        {
            exit.GetComponent<LineRenderer>().enabled = false;
        }
    }

}
