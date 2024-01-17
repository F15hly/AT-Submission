using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWonderer : MonoBehaviour
{
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    PlatformRotation platformRotation;
    public GameObject tracker;
    PathCheck pathCheck;
    public float speed, rotFloat, rotTimer;
    public bool onPath, jumpOff;

    private void Awake()
    {
        platformRotation = GameObject.FindGameObjectWithTag("Platform").GetComponent<PlatformRotation>();
        tracker = transform.GetChild(12).gameObject;
        pathCheck = tracker.GetComponent<PathCheck>();
    }

    private void Update()
    {
        onPath = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //SAVE CURRENT PATH OBJ

        if (platformRotation.Shaken)
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up);
        }

        if(!platformRotation.Shaken)
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

            if(!jumpOff)
            {
                if(onPath || pathCheck.PP != null)
                {
                    gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                    //if (pathCheck.PP != null)
                    {
                        var step = speed * Time.deltaTime;
                        transform.position = Vector3.MoveTowards(transform.position, tracker.transform.position, step);
                    }
                }
                if (pathCheck.PP == null & !onPath)
                {
                    var step = rotFloat * Time.deltaTime;
                    transform.Rotate(0, step, 0);
                    rotTimer += Time.deltaTime;
                    if(rotTimer > 5)
                    {
                        jumpOff = true;
                        rotTimer = 0;
                    }
                }
            }
            if(jumpOff)
            {
                var step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, tracker.transform.position, step * 3);
            }
        }
    }
}
