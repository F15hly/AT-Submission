using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    void Update()
    {
        if(transform.position.y < -30)
        {
            transform.position = new Vector3(0, 5, 0);
        }
    }
}
