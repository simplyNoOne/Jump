using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField]
    private float minStep;
    [SerializeField]
    private float maxStep;


    [SerializeField]
    private GameObject spawner;
    [SerializeField]
    private GameObject destroyer;
    [SerializeField]
    private GameObject[] platforms;


    private float spawnHeight;
    private int num;

    // Start is called before the first frame update
    void Start()
    {
        num = 3;
        spawnHeight = spawner.transform.position.y + 5.0f;
        StartCoroutine(spawnPlatform());
    }
  

    private IEnumerator spawnPlatform()
    {
        while (true)
        {
            yield return null;
            if (spawner.transform.position.y >= spawnHeight)
            {
                spawnHeight += Random.Range(minStep, maxStep);

                Vector3 pos = spawner.transform.position;

                int index = Random.Range(0, platforms.Length);
                GameObject obj = Instantiate(platforms[index], pos, new Quaternion());
                obj.GetComponent<PlatformActions>().platformNum = num;
                num++;
            }
        }
        
    }
}
