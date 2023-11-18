using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    int highIndex;
    int score;
    void Start()
    {

        
        if (instance == null)
        {
            instance = this;
        }
        else
            
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighscore()
    {
        return PlayerPrefs.GetInt("Highscore");
    }


    public void IncrementScore()
    {
        score++;
        Highscore();
    }

    void Highscore()
        {
        if (score > PlayerPrefs.GetInt("Highscore"))
            {
            PlayerPrefs.SetInt("Highscore", score);
        }

    }

    public void ResetScore()
    {
        score = 0;
    }

}
