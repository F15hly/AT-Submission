using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snapOrientation : MonoBehaviour
{
    public GameObject platform;
    public float y;
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, platform.transform.eulerAngles.y - y, 0);

        if(platform.transform.localEulerAngles.y > 0 && platform.transform.localEulerAngles.y < 90)
        {
            y = 0;
        }
        if (platform.transform.localEulerAngles.y > 90 && platform.transform.localEulerAngles.y < 180)
        {
            y = 90;
        }
        if (platform.transform.localEulerAngles.y > 180 && platform.transform.localEulerAngles.y < 270)
        {
            y = 180;
        }
        if (platform.transform.localEulerAngles.y > 270 && platform.transform.localEulerAngles.y < 360)
        {
            y = 270;
        }
    }
} 
