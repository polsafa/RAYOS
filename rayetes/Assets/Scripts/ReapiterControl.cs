using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReapiterControl : MonoBehaviour
{
    public LineRenderer liner;

    public float lineDistance;

    private RaycastHit hitLine;

    private GameObject currentrepeater;

    public List<GameObject> objray;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (liner.enabled == true)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hitLine, lineDistance))
            {
                if (hitLine.collider.tag == "repeater")
                {
                    if (currentrepeater != hitLine.collider.gameObject)
                    {
                        if (currentrepeater != null)
                        {
                            currentrepeater.GetComponent<ReapiterControl>().desactiveray(gameObject);
                        }
                        currentrepeater = hitLine.collider.gameObject;
                        hitLine.collider.GetComponent<ReapiterControl>().activeray(gameObject);
                    }
                }
                else
                {
                    if(currentrepeater != null)
                    {
                        currentrepeater.GetComponent<ReapiterControl>().desactiveray(gameObject);
                        currentrepeater = null;
                    }
                }
                liner.SetPosition(0, transform.position);
                liner.SetPosition(1, hitLine.point);
            }
            else
            {
                if (currentrepeater != null)
                {
                    currentrepeater.GetComponent<ReapiterControl>().desactiveray(gameObject);
                    currentrepeater = null;
                }
                liner.SetPosition(0, transform.position);
                liner.SetPosition(1, transform.position + transform.forward * lineDistance);
            }

        }
    }

    public void activeray(GameObject rayobjects)
    {
        if (objray.Contains(rayobjects) == false)
        {
            objray.Add(rayobjects);
            if (objray.Count > 0)
            {
                liner.enabled = true;
            }
        }
    }

    public void desactiveray(GameObject rayobjects)
    {
        if(objray.Contains(rayobjects) == true)
        {
            objray.Remove(rayobjects);
            if(objray.Count == 0)
            {
                liner.enabled = false;
                if(currentrepeater != null)
                {
                    currentrepeater.GetComponent<ReapiterControl>().desactiveray(gameObject);
                    currentrepeater = null;
                }
            }
        }
    }

    public void setdistance(float value)
    {
        print("hola");
        lineDistance += value;
        if(lineDistance > 20)
        {
            lineDistance = 20;
        }

        if(lineDistance < 5)
        {
            lineDistance = 5;
        }
    }
}
