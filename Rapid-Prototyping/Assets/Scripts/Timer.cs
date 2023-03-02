using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TimerDirection { CountUp, CountDown }
public class Timer : GameBehaviour<Timer>
{
    public TimerDirection timerDirection;
    public float startTime = 0;
    float currentTime;
    bool isTimed = false;
    bool hasTimeLimit = false;
    float timeLimit = 0f;

    void Update()
    {
        if (!isTimed)
            return;

        currentTime = timerDirection == TimerDirection.CountUp ? currentTime += Time.deltaTime : currentTime -= Time.deltaTime;

        if (currentTime < 0)
        {
            currentTime = 0;
            StopTimer();
        }
    }

    public void StartTimer(float _startTime = 0, float _timeLimit = 0, bool _hasTimeLimit = true, TimerDirection _direction = TimerDirection.CountUp)
    {
        timerDirection = _direction;
        hasTimeLimit = _hasTimeLimit;
        startTime = _startTime;
        isTimed = true;
    }

    public void ResumeTimer()
    {
        isTimed = true;
    }

    public void PauseTimer()
    {
        isTimed = false;
    }

    public void StopTimer()
    {
        isTimed = false;
    }

    public void IncrementTimer(float _increment)
    {
        currentTime += _increment;
    }

    public void DecrementTimer(float _decrement)
    {
        currentTime -= _decrement;
    }

    public bool TimeExpired()
    {
        if (!hasTimeLimit)
            return false;

        return timerDirection == TimerDirection.CountDown ? currentTime > timeLimit : currentTime < timeLimit;
    }
    public float GetTime()
    {
        return currentTime;
    }
    public bool IsTiming()
    {
        return isTimed;
    }

    public void ChangeTimerDirection(TimerDirection _direction)
    {
        timerDirection = _direction;
    }
}
