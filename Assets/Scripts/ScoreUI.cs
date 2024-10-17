using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    TextMeshProUGUI _textMP;
    int _currentScore;
    
    private void Awake()
    {
        _textMP = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateScore()
    {
        _currentScore++;
        _textMP.text = $"Coins: {_currentScore.ToString("")}";
    }
}