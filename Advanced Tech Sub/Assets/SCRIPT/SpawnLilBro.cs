using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLilBro : MonoBehaviour
{
    public GameObject lilbro;
    public int houseCount, pathCount;
    void FixedUpdate()
    {
        if(houseCount > 0 && pathCount > 2)
        {
            Instantiate(lilbro,new Vector3(0,5,0), transform.rotation);
            pathCount = 0;
        }
    }
}
