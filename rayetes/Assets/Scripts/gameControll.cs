using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameControll : MonoBehaviour {


    public GameObject repeater;
    private RaycastHit hitpos,hitinfo;
    private Ray rayinfo, raypos;
    GameObject currentrepeater;
    public LayerMask floorlayer;
    private Vector3 initposrepeater;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      
        print(hitpos.point);
        if (Input.GetMouseButtonDown(0))
        {
            rayinfo = Camera.main.ScreenPointToRay(Input.mousePosition );

            if (Physics.Raycast(rayinfo, out hitpos))
            {
                
                if (hitpos.collider.tag == "repeater")
                {
                    currentrepeater = hitpos.collider.gameObject;
                }
                else
                {
                    Vector3 newpos = hitpos.point;
                    newpos.y = 1;
                    GameObject newrepeater = Instantiate(repeater, newpos, Quaternion.Euler(0, 0, 0));
                    currentrepeater = newrepeater;
                }
                if (currentrepeater != null)
                {
                    initposrepeater = currentrepeater.transform.position;
                }
            }
        }
        else if (Input.GetMouseButton(0))
        {
            if(currentrepeater != null)
            {
                raypos = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(raypos, out hitinfo,Mathf.Infinity, floorlayer))
                {
                    Vector3 newpos = hitinfo.point;
                    newpos.y = 1;
                    currentrepeater.transform.position = newpos;
                }
                if (Input.GetKey(KeyCode.W))
                {
                    currentrepeater.GetComponent<ReapiterControl>().setdistance(1);
                    print("w");
                }
                if (Input.GetKey(KeyCode.S))
                {
                    currentrepeater.GetComponent<ReapiterControl>().setdistance(-1);
                    print("s");
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            rayinfo = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayinfo, out hitpos))
            {
                if(hitpos.collider.tag == "repeater" && currentrepeater != hitpos.collider.gameObject)
                {
                    if(currentrepeater != null)
                    {
                        currentrepeater.transform.position = initposrepeater;
                    }
                }
            }
        }
        imputsRepeater();
	}
    private float speedrotation = 150;
    private void imputsRepeater()
    {
        if(currentrepeater != null){
            if (Input.GetMouseButton(0))
            {
                currentrepeater.transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * speedrotation * Time.deltaTime);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    Destroy(currentrepeater);
                }
            }
        }
    }
}
