using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{
    public ScoreBox ScoreBox;

    private Score score;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreObj = GameObject.FindGameObjectWithTag("Score");
        
        if (scoreObj != null)
        {
            score = scoreObj.GetComponent<Score>();

            Debug.Log("EndController -> Num scores = " + score.Scores.Count.ToString());
            ScoreBox.SetScore(score.Scores);

            Destroy(scoreObj);
        }
    }

    void Update()
    {
        if (Input.GetButtonUp("Jump1") || Input.GetButtonUp("Jump2") || Input.GetButtonUp("Special1") || Input.GetButtonUp("Special2"))
        {
            SceneManager.LoadScene("SplashScene");
        }
    }
}
