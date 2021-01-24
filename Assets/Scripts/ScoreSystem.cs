using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public float score = 0;
    public Text scoreText;


    public void Update()
    {
        scoreText.text = "Score : " + score.ToString();
    }

    public void increaseScore()
    {
        score += 20;
    }

    public void decreaseScore()
    {
        if (score >= 20)
        {
            score -= 20;
        }
    }
}
