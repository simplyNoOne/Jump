using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxBG : MonoBehaviour
{
    private float length, startPos;

    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private float parallax;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;

    }

    // Update is called once per frame
    void Update()
    {
        float temp = (mainCamera.transform.position.y * (1- parallax));
        float dist =( mainCamera.transform.position.y * parallax);

        transform.position = new Vector3(transform.position.x, startPos + dist, transform.position.z);

        if (temp > startPos + length)
            startPos += 2*length;
        else if (temp < startPos - length)
            startPos -= 2*length;
    }
}
