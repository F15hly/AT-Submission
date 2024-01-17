using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aplle : MonoBehaviour
{
    public GameObject platform, apple;
    PlatformRotation platformRotation;
    public bool readyApple;

    private void Awake()
    {
        platformRotation = platform.GetComponent<PlatformRotation>();
        readyApple = true;
    }

    private void Update()
    {
        if(platformRotation.Shaken)
        {
            if(readyApple)
            {
                StartCoroutine(Wait());
                readyApple = false;
                Instantiate(apple, apple.transform.position = new Vector3(Random.Range(-3, 3), 2, Random.Range(-3,3)), transform.rotation, transform.parent = platform.transform.GetChild(0));
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        readyApple = true;
    }
}
