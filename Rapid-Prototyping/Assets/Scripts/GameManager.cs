using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Difficulty { Easy, Medium, Hard }
public class GameManager : GameBehaviour<GameManager>
{
    public Difficulty difficulty;
    public int scoreBonus = 50;

    void Start()
    {
        //_TIMER.TimerDirection.CountUp(0, TimerDirection.CountUp);
        DifficultySetup();
    }

     void Update()
     {
        //if (Input.GetKeyDown(KeyCode.C))
        //    _TIMER.ChangeTimerDirection(TimerDirection.CountDown);
        //if (Input.GetKeyDown(KeyCode.U))
        //    _TIMER.ChangeTimerDirection(TimerDirection.CountUp);
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    if (_TIMER.IsTiming())
        //        _TIMER.PauseTimer();
        //    else
        //        _TIMER.ResumeTimer();
        //}

        //if (_TIMER.TimeExpired())
        //{
        //    Debug.Log("Time Expired");
        //}
     }

    public void ChangeDifficulty(int _difficulty)
    {
        difficulty = (Difficulty)_difficulty;
        DifficultySetup();
    }

    void DifficultySetup()
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                scoreBonus = 50;
                break;
            case Difficulty.Medium:
                scoreBonus = 100;
                break;
            case Difficulty.Hard:
                scoreBonus = 150;
                break;
        }

        _SM.AddScore(scoreBonus);
    }
  
}
