using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int scoreCount;
    public TMP_Text scoreText;
    void Start()
    {
        scoreCount = 0;
    }

    void Update()
    {
        scoreText.text = "Fuel:" + Mathf.Round(scoreCount);
        
    }

    
}
