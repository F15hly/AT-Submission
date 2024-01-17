using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public bool dragging;

    private int counter;

    public GameObject objectToDrag;
    public GameObject objPref;

    public string theTag;

    private void Update()
    {
        //objectToDrag = GameObject.FindGameObjectWithTag(theTag);
        if(objectToDrag.GetComponent<Snapping>().landed)
        {
            objectToDrag = null;
        }
        if(dragging)
        {
            counter = 1;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition + new Vector3(0, 0, 1));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Grid")
                {
                    objectToDrag.transform.position = (hit.collider.transform.position + new Vector3(0, 3, 0));
                }
            }
        }
        if(!dragging)
        {
            if (counter == 1)
            {
                objectToDrag.GetComponent<Rigidbody>().useGravity = true;
                counter = 0;
            }
        }
    }
    private void LateUpdate()
    {
        if(objectToDrag == null)
        {
            objectToDrag = Instantiate(objPref);
        }
    }
}
