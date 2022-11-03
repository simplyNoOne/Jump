using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public float jumpVel;
    public GameObject SFxPlayer;

    public GameObject mobileButton;

    private Rigidbody2D body;

    private bool bInAir;
    private int doubleJump;
    private bool jumped;

    private int currentPlatform;
    private int lastPlatform;

    public void SetInAir(bool inAir) { bInAir = inAir; }

    private void Awake()
    {
#if UNITY_STANDALONE_OSX ||UNITY_STANDALONE_WIN 
        mobileButton.SetActive(false);
#endif
        body = GetComponent<Rigidbody2D>();
        doubleJump = 2;
        currentPlatform = 0;
        lastPlatform = 0;       //so that we start with neutral score
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Jump()
    {
        if (!bInAir || doubleJump > 0)
        {
            SFxPlayer.GetComponent<SFxPlayer>().PlayJump();
            lastPlatform = currentPlatform;
            body.velocity = Vector2.up * jumpVel;
            doubleJump--;
            jumped = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Destroyer"))
        {
            Die();   
        }
        if (collision.CompareTag("PositionCheck"))
        {
            currentPlatform = collision.gameObject.GetComponentInParent<PlatformActions>().platformNum;
            if (jumped)
            {
                gameObject.GetComponent<ScoreCounter>().CheckScore(lastPlatform);
                
                doubleJump = 2;
                jumped = false;
            }
        }
    }

    public int GetCurrentPlatform() { return currentPlatform; } 

    public void Die()
    {
        GetComponent<ScoreCounter>().SaveResults();
        print (currentPlatform);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
