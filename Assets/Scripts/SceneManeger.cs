using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManeger : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        
        if(ScoreManager.instance != null)
        {
            TempoManager.instance.PlayTime();
            ScoreManager.instance.ResetScore();
        }

        SceneManager.LoadScene("SampleScene");

    }

    public void Quit()
    {
        Application.Quit();
    }

    

}
