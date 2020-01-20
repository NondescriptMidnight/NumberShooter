using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public static int scoreNum = 0;
    public Text scoreText;

    void Update()
    {
        scoreText.text = "Score: " + scoreNum;
    }
}
