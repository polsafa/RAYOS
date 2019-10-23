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
                if (hitLine.collider.tag == "obstacle")
                {
                    if (currentrepeater != null)
                    {
                        currentrepeater.GetComponent<ReapiterControl>().desactiveray(gameObject);
                        currentrepeater = null;
                    }
                }
                if (hitLine.collider.tag == "hole")
                {
                    GameObject blackHole;
                    blackHole = hitLine.collider.gameObject;
                    blackHole.GetComponent<holeController>().currentrep = currentrepeater;
                    blackHole.GetComponent<holeController>().exit.GetComponent<LineRenderer>().enabled = true;

                }
                if (hitLine.collider.tag == "bifurcator")
                {
                    GameObject bifurcator;
                    bifurcator = hitLine.collider.gameObject;
                    bifurcator.GetComponent<BifurcatorControler>().currentrep = currentrepeater;
                    bifurcator.GetComponent<BifurcatorControler>().bifur1.GetComponent<LineRenderer>().enabled = true;
                    bifurcator.GetComponent<BifurcatorControler>().bifur2.GetComponent<LineRenderer>().enabled = true;
                    bifurcator.GetComponent<BifurcatorControler>().bifur2.GetComponent<Renderer>().material = bifurcator.GetComponent<BifurcatorControler>().b;
                    bifurcator.GetComponent<BifurcatorControler>().bifur1.GetComponent<Renderer>().material = bifurcator.GetComponent<BifurcatorControler>().b;

                }
                if (hitLine.collider.tag == "enchufe")
                {
                    GameObject enchufe;
                    enchufe = hitLine.collider.gameObject;
                    enchufe.GetComponent<Enchufecontroller>().currentrep = currentrepeater;
                    enchufe.GetComponent<Enchufecontroller>().power = true;
                    enchufe.GetComponent<Renderer>().material = enchufe.GetComponent<Enchufecontroller>().b;
                    

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
