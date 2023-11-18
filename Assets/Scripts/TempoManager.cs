using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempoManager : MonoBehaviour
{
    // Start is called before the first frame update
    float tempo;
    bool cena1 = true;
    bool cena2 = true;
    bool contarTempo = true;

    public static TempoManager instance;

    private void Awake()
    {
        contarTempo = true;
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


        DontDestroyOnLoad(gameObject);
        tempo = 0f;
    }
   

    // Update is called once per frame
    void Update()
    {

        Debug.Log(Mathf.Round(tempo));
        if(contarTempo)
        {
            tempo += Time.deltaTime;
        }
        

        if(tempo > 30 && cena1)
        {
            cena1 = false;
            SceneManager.LoadScene("SampleScene 1");
        }
        if(tempo > 60 && cena2)
        {
            BolasManager.instance.DestruirLista();
            cena2 = false;
            Destroy(FindObjectOfType<Movement>());
            SceneManager.LoadScene("End");
            ResetTime();
            
        }
    }



    public void ResetTime()
    {
        contarTempo = false;
        tempo = 0;
    }

    public void PlayTime()
    {
        contarTempo = true;
        tempo = 0;
    }

    public bool foiParaASegunda()
    {
        if(!cena1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
