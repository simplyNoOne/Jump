using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform checkpoint;       // for checking if camera should move up
    [SerializeField]
    private float speed;

    Camera cam;
    private float diff, left, right;
    float rightEdge;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
        cam = gameObject.GetComponent<Camera>();
        rightEdge = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f)).x;
        
    }

    // Update is called once per frame
    void Update()
    {
        diff = target.transform.position.y - checkpoint.position.y;
        if (diff >= 0.0f)
        {
            transform.position = Vector3.Slerp(transform.position, transform.position + new Vector3(0.0f, diff, 0.0f), speed * Time.deltaTime);
        }
        
        right = target.transform.position.x - rightEdge +0.5f;
        if (right >= 0.0f)
        {
            target.transform.position = Vector3.Slerp(target.transform.position, target.transform.position + new Vector3(-right, 0.0f, 0.0f), speed * Time.deltaTime * 20);
        }
        
        left = target.transform.position.x + rightEdge - 0.5f;
        if (left <= 0.0f)
        {
            target.transform.position = Vector3.Slerp(target.transform.position, target.transform.position + new Vector3(-left, 0.0f, 0.0f), speed * Time.deltaTime * 20);
        }

    }
}
