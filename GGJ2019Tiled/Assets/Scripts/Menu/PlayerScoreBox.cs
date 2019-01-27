using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreBox : MonoBehaviour
{
    public Text NameText;
    public Text ScoreText;

    public void SetScore(string name, int score)
    {
        NameText.text = name;
        ScoreText.text = score.ToString();
    }
}
