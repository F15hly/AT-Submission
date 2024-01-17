using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCheck : MonoBehaviour
{
    public GameObject PP,LastPath;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PP")
        {
            PP = other.gameObject;
            LastPath = other.gameObject;
        }
        else
        {
           PP = null;
        }
    }
}
