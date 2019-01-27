using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Fruitz;

public class Score : MonoBehaviour
{
    public List<Identity> Scores { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetScores(List<Identity> leaderboard)
    {
        Scores = leaderboard;
    }
}
