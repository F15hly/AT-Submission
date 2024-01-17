using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mousepress : MonoBehaviour
{
    NewControls controls;

    public bool mousePress;

    public GameObject[] objects;

    LevelManager LevelManager;

    private void Awake()
    {
        LevelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    private void OnEnable()
    {
        if(controls == null)
        {
            controls = new NewControls();
            controls.Newactionmap.Mouseclick.performed += i => mousePress = i.ReadValueAsButton();
        }
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        if(mousePress)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition + new Vector3(0, 0, 1));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.tag == "drag")
                {
                    if(LevelManager.appleCount > 0)
                    {
                        hit.collider.GetComponent<DragDrop>().dragging = true;
                    }
                }
                if(hit.collider.tag == "apple")
                {
                    hit.collider.GetComponentInParent<ApplePickUp>().PickedUp = true;
                }
            }
        }
        if(!mousePress)
        {
            foreach (var item in objects)
            {
                item.GetComponent<DragDrop>().dragging = false;
            }
        }
    }
}
