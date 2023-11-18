using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Contador : MonoBehaviour
{


    public TextMeshProUGUI messageText;
   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
            messageText.SetText($"count - {ScoreManager.instance.GetScore()}");
            messageText.SetText($"count : {ScoreManager.instance.GetScore()}\nHighScore : {ScoreManager.instance.GetHighscore()}");





    }

}
