using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotation : MonoBehaviour
{
    public float OldX;
    public Quaternion test;
    float yValue = 0;
    public GameObject yRotObj;
    public float timer = 0f;
    public bool Shaken;

    private void Start()
    {
        Input.gyro.enabled = true;
    }

    //private void Update()
    //{
    //    test = Input.gyro.attitude;
    //    transform.rotation = Quaternion.Euler(Input.gyro.attitude.x * 180, Input.gyro.attitude.y * -3600 * 5, 0);
    //}

    //private void Update()
    //{
    
 
    //transform.rotation = deviceRotation;
    //}


    private void Update()
   {
        Quaternion deviceRotation = Gyro.Get();
        test = deviceRotation;

        //transform.rotation = deviceRotation;
        float testx;
        
        if (test.x < 0) { testx = test.x * 180 + 90; }
        else { testx = ((-0.5f / test.x) - .5f) * 180 - 90; }

        if (testx > -7.5f && testx < 53.5f)
        {
            transform.localRotation = Quaternion.Euler(testx - 23.5f, 0, 0);
        }
        else if (test.z > 0)
        {
            if(testx < -7.5f)
            {
                transform.localRotation = Quaternion.Euler(-30, 0, 0);
            }
            if (testx > 53.5f)
            {
                transform.localRotation = Quaternion.Euler(30, 0, 0);
            }
        }

        if (test.w < -0.8f)
        {
            yValue += Time.deltaTime * 60;
        }
        if (test.w > -0.35f)
        {
            yValue -= Time.deltaTime * 60;
        }
        yRotObj.transform.localRotation = Quaternion.Euler(0, yValue, 0);

        timer += Time.deltaTime;
        if(timer > 0.5)
        {
            OldX = transform.eulerAngles.x;
            Shaken = false;
            timer = 0f;
        }
        
        if(OldX - transform.eulerAngles.x > 30 || OldX - transform.eulerAngles.x < -30)
        {
            Shaken = true;
        }
    }
}
