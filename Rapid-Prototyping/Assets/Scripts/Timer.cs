using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : GameBehaviour<Timer>
{
    public float currentTime = 0;
    float bestTime;
    public bool timing = false;

    [Header("Texts")]
    public TMP_Text timerText;
    public TMP_Text timeResult;
    public TMP_Text bestTimeText;

    [Header("Screens")]
    public GameObject timerScreen;
    public GameObject timerResults;

    void Start()
    {
        timerScreen.SetActive(false);
        timerResults.SetActive(false);
    }

    void Update()
    {
        if(timing == true)
            isTiming();
    }

    public void isTiming()
    {
        timing = true;
        if (timing)
        {
            timerScreen.SetActive(true);
            StartTimer();
            currentTime += Time.deltaTime;
            timerText.text = currentTime.ToString("F3");
        }
    }

    public void StartTimer()
    {
        currentTime = 0;
        timing = true;
    }

    public void StopTimer()
    {
        timing = false;
        timeResult.text = currentTime.ToString("F3");
        bestTimeText.text = bestTime.ToString("F3");

        timerScreen.SetActive(false);
        timerResults.SetActive(true);

        if (currentTime <= bestTime)
        {
            bestTime = currentTime;
            bestTimeText.text = bestTime.ToString("F3") + " !! NEW BEST SCORE !!";
        }
    }

   
}

