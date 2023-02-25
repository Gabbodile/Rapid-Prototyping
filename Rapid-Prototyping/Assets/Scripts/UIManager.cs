using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : GameBehaviour<UIManager>
{

    public TMP_Text scoreText;
    int scoreBonus = 50;

    private void Start()
    {
        TweenScore(0);
    }

    public void TweenScore(int _score)
    {
        DOTween.To(() => _score, x => _score = x, _score + scoreBonus, 1).OnUpdate(() =>
        {
            scoreText.text = "score: " + _score;
        });
    }
}
