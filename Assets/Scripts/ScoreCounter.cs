using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    private Text credit;
    [SerializeField]
    private Text score;
    [SerializeField]
    private Transform[] points;
    [SerializeField]
    private GameObject SFxManager;


    private int currentCredit;
    private int PosCredit;
    private int LocCredit;
    private int platformNumber;
    private int prevPlatformNum;
    private bool shouldCheckPos;

    bool tempSteady;

    // Start is called before the first frame update
    void Start()
    {
        currentCredit = 10;
        shouldCheckPos = false;
        credit.text = "10";
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldCheckPos)
        {
            CalcPoints();
        }
        if (tempSteady)
        {
            StartCoroutine(Steady());
        }
        
    }

    IEnumerator Steady()
    {
        yield return new WaitForSeconds(0.01f);
        if (tempSteady)
        {
            ChangeScore(LocCredit + PosCredit);
            tempSteady = false;
        }
    }

   

    private void CalcPoints()
    {
        PointsBasedOnLanding();
        if (!shouldCheckPos)
        {
            PointsBasedOnPlatform();
            if ((LocCredit == -1) && PosCredit == 2)
                PosCredit--;
        }       
    }

    private void PointsBasedOnLanding()
    {
        if (Mathf.Abs(points[0].position.x - points[1].position.x) < 0.003f)
        {
            tempSteady = true;
            shouldCheckPos = false;
            if (points[0].position.y > points[1].position.y)
                PosCredit = 1;
            else
                PosCredit = 2;
        }
        else if ((Mathf.Abs(points[2].position.y - points[3].position.y) < 0.005f) || (Mathf.Abs(points[4].position.y - points[5].position.y) < 0.005f))
        {
            tempSteady = true;
            shouldCheckPos = false;
            PosCredit = 0;
        }
        else
            tempSteady = false;
    }

    private void PointsBasedOnPlatform()
    {
        platformNumber = gameObject.GetComponent<PlayerBehaviour>().GetCurrentPlatform();
        if (prevPlatformNum > platformNumber)
            LocCredit = -2;
        else if (prevPlatformNum < platformNumber)
            LocCredit = 0;
        else
            LocCredit = -1;
    }

    public void CheckScore(int lastPlatformNum)
    {
        prevPlatformNum = lastPlatformNum;
        shouldCheckPos = true;
    }


    public void ChangeScore(int change)
    {
        //shouldCheckPos = false;
        if (change > 0)
            SFxManager.GetComponent<SFxPlayer>().PlayGetP();
        else if (change < 0)
            SFxManager.GetComponent<SFxPlayer>().PlayLoseP();

        currentCredit += change;
        if (currentCredit < 0)            
            GetComponent<PlayerBehaviour>().Die();

        credit.text = currentCredit.ToString("D2");
        score.text = platformNumber.ToString("D3");
    }

    public void SaveResults()
    {
        Save save = gameObject.GetComponent<Save>();
        save.LoadFile();
        save.SetLastScore(platformNumber);
        if (platformNumber > save.GetBestScore())
            save.SetBestScore(platformNumber);
        save.SaveFile();
        
    }
}
