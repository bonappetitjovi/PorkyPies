using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int ScoreInt;
    public Text ScoreText;
    public Text HighScore;

    void Start()
    {
        HighScore.text=PlayerPrefs.GetInt("MaxRun",0).ToString();
    }

    public void ScorePlusOne()
    {
        ScoreInt++;
        if(ScoreInt>PlayerPrefs.GetInt("MaxRun",0))
        {
            PlayerPrefs.SetInt("MaxRun",ScoreInt);
            HighScore.text=ScoreInt.ToString();
        }
    }

    private void Update()
    {
        ScoreText.text = ScoreInt.ToString();
    }
}
