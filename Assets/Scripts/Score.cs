using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text score, finalScore;
    [Header("Should be zero or start value")]
    public int points;

    public Stat[] stats;

    [System.Serializable]

    public class Stat
    {
        public string statName;
        public int points;
        public TMP_Text textbox;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = points + "";
        finalScore.text = points + "";

        for (int i = 0; i<stats.Length; i++)
        {
            stats[i].textbox.text = stats[i].points + "";
        }
    }
}
