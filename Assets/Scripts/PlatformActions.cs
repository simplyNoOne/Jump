using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActions : MonoBehaviour
{
    public int platformNum;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Destroyer"))
            Destroy(gameObject);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
            collision.collider.GetComponent<PlayerBehaviour>().SetInAir(false);
           
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerBehaviour>().SetInAir(true);
            collision.collider.transform.SetParent(null);
        }
    }
}
