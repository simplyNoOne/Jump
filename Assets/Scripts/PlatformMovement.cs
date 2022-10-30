using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private Vector3 baseLoc;
    private Vector3 acc;
    private Vector3 velocity;

    private float multip;


    // Start is called before the first frame update
    void Start()
    {
        multip = Random.Range(0.8f, 5f);
        float difference = Random.Range(-5.0f, 5.0f);
        float startSpeed = Random.Range(3.0f, 7.0f);

        baseLoc = transform.position;
        transform.position = new Vector3( baseLoc.x + difference, baseLoc.y, baseLoc.z);
        velocity = new Vector3(startSpeed, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        acc = Vector3.Normalize(baseLoc - transform.position)*multip;
        velocity += acc * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }

}
