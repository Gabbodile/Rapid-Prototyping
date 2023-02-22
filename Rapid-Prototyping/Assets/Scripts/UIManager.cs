using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : GameBehaviour<UIManager>
{
    public TMP_Text scoreText;
    int score = 0;
    int scoreBonus = 50;

    private void Start()
    {
        scoreText.text = score.ToString();
    }

    public void TweenScore()
    {
        DOTween.To(() => score, x => score = x, score + scoreBonus, 1).OnUpdate(() =>
        {
            scoreText.text = "score: " + score.ToString();
        });
    }
}
