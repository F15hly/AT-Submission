using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapping : MonoBehaviour
{
    public float yValue, newY, XSpawn;
    public GameObject newOBJ, snapTrack, platform;
    public string theTag;
    LevelManager LevelManager;

    public string Identification;

    public bool landed;

    private void Awake()
    {
        snapTrack = GameObject.FindGameObjectWithTag("SnapTrack");
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        LevelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        gameObject.tag = theTag;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        landed = false;
        Identification = tag;
        platform = GameObject.FindGameObjectWithTag("Platform");
    }

    private void Update()
    {
        newY = snapTrack.transform.rotation.eulerAngles.y;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Grid")
        {
            landed = true;
            transform.parent = collision.transform;
            transform.localPosition = new Vector3(0, yValue, 0);
            transform.localRotation = Quaternion.Euler(0, transform.rotation.y + (Mathf.RoundToInt(Random.RandomRange(0,4) * 90)), 0);
            Destroy(gameObject.GetComponent<Rigidbody>());
            if (gameObject.tag == "House")
            {
                GameObject.FindGameObjectWithTag("LevelManager").GetComponent<SpawnLilBro>().houseCount += 1;
                gameObject.tag = "Untagged";
            }
            else if (gameObject.tag == "Path")
            {
                GameObject.FindGameObjectWithTag("LevelManager").GetComponent<SpawnLilBro>().pathCount += 1;
                gameObject.tag = "PP";
            }
            else
            {
                gameObject.tag = "Untagged";
            }
        }
    }

    private void LateUpdate()
    {
        if (landed)
        {
            LevelManager.appleCount -= 1;
            landed = false;
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        Destroy(GetComponent<Snapping>());
    }
}
