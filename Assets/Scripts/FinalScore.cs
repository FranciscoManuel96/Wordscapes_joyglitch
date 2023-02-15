using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int score;

    private void Start()
    {   
        score = PlayerPrefs.GetInt("score");
        scoreText.text = score.ToString();
    }
    
}
