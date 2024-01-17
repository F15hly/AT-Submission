using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rot : MonoBehaviour
{
    public bool clicked;
    public float rotSpeed;
    public GameObject platform;
    public static Vector3 currentRotation;
    public bool xSpin;
    public bool positive;

    public void platRot()
    {
        clicked = true;
    }

    private void Update()
    {
        if(currentRotation.x > 15)
        {
            currentRotation.x = 15;
        }
        if (currentRotation.x < -15)
        {
            currentRotation.x = -15;
        }
        if (currentRotation.z > 15)
        {
            currentRotation.z = 15;
        }
        if (currentRotation.z < -15)
        {
            currentRotation.z = -15;
        }
        if (clicked)
        {
            if(xSpin)
            {
                if(positive)
                {
                    currentRotation.x += Time.deltaTime * rotSpeed;
                }
                else
                {
                    currentRotation.x -= Time.deltaTime * rotSpeed;
                }
            }
            else
            {
                if (positive)
                {
                    currentRotation.z += Time.deltaTime * rotSpeed;
                }
                else
                {
                    currentRotation.z -= Time.deltaTime * rotSpeed;
                }
            }
            platform.transform.rotation = Quaternion.Euler(currentRotation);
        }
    }
}
