using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform checkpoint;
    [SerializeField]
    private Transform borderL;
    [SerializeField]
    private Transform borderR;

    [SerializeField]
    private float speed;

    private float diff, left, right;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        diff = target.transform.position.y - checkpoint.position.y;
        if (diff >= 0.0f)
        {
            transform.position = Vector3.Slerp(transform.position, transform.position + new Vector3(0.0f, diff, 0.0f), speed * Time.deltaTime);
        }
        right = target.transform.position.x - borderR.position.x;
        if (right >= 0.0f)
        {
            target.transform.position = Vector3.Slerp(target.transform.position, target.transform.position + new Vector3(-right, 0.0f, 0.0f), speed * Time.deltaTime * 20);
        }
        left = target.transform.position.x - borderL.position.x;
        if (left <= 0.0f)
        {
            target.transform.position = Vector3.Slerp(target.transform.position, target.transform.position + new Vector3(-left, 0.0f, 0.0f), speed * Time.deltaTime * 20);
        }
    }
}
