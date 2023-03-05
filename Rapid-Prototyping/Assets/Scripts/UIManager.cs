using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : GameBehaviour<UIManager>
{
    [Header("Text")]
    public TMP_Text scoreText;
    //public TMP_Text waveText;
    public TMP_Text healthText;

    [Header("Screens")]
    public GameObject gameOverScreen;

    private void Start()
    {
        gameOverScreen.SetActive(false);
        TweenHealth(3);
        //TweenWave(1);
        TweenScore(0);
    }

    private void Update()
    {
        
    }

    public void TweenScore(int _score)
    {
        DOTween.To(() => _score, x => _score = x, _score, 1).OnUpdate(() =>
        {
            scoreText.text = "Score: " + _score;
        });
    }

    //public void TweenWave(int _wave)
    //{
    //    //DOTween.To(() => _wave, x => _wave = x, _wave, 1).OnUpdate(() =>
    //    //{
    //    //    waveText.text = "Wave Number " + _wave;
    //    //});

    //    waveText.text = "Wave Number " + _wave;
    //}

    public void TweenHealth(int _health)
    {
        DOTween.To(() => _health, x => _health = x, _health, 1).OnUpdate(() =>
        {
            healthText.text = "Health: " + _health;
        });
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }
}
