using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReapiterControl : MonoBehaviour
{
    private LineRenderer liner;

    public float lineDistance;
    // Use this for initialization
    void Start()
    {
        liner = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        liner.SetPosition(0, transform.position);
        liner.SetPosition(1, transform.position + transform.forward * lineDistance);

    }
}
