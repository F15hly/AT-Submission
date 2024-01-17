using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePickUp : MonoBehaviour
{
    public bool PickedUp;
    GameObject Parent;

    private void Awake()
    {
        Parent = gameObject.transform.parent.gameObject;
    }
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        if(PickedUp)
        {
            Destroy(Parent);
        }
    }
    private void OnDestroy()
    {
        GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().appleCount += 1;
    }
}
