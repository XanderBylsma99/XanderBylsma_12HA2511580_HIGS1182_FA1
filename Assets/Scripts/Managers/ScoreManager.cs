using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public float score;
    //public float scoreCount;
    public TMP_Text collectibleText;
    public TMP_Text scoreText;
    void Start()
    {
        score = 0;
    }

    void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    public void AddScore()
    {
        score++;
    }

    
}
