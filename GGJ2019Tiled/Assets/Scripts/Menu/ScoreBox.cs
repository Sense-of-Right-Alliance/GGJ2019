using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Fruitz;

public class ScoreBox : MonoBehaviour
{
    public GameObject PlayerScoreBoxPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void SetScore(List<Identity> scores)
    {
        if (scores.Count == 0)
        {
            GameObject pScore = (GameObject)Instantiate<GameObject>(PlayerScoreBoxPrefab, transform);
            pScore.GetComponent<PlayerScoreBox>().SetScore("NO SCORES!?", -10000);
        }
        else
        {
            for (int i = 0; i < scores.Count; i++)
            {
                GameObject pScore = (GameObject)Instantiate<GameObject>(PlayerScoreBoxPrefab, transform);
                pScore.GetComponent<PlayerScoreBox>().SetScore(scores[i].Name, scores[i].Score);
            }
        }
    }
}
