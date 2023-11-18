using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolasManager : MonoBehaviour
{
    // Start is called before the first frame update
    float tempo = 0;
    bool Smoll = false;
    public delegate void TheDelegate();
    public TheDelegate myDelegate;
    public TheDelegate myDelegate2;

    [SerializeField] GameObject bolaVermelha;
    [SerializeField] GameObject bolaFoco;
    GameObject bolaAdd;
    List<GameObject> Bolas = new List<GameObject>();

    public static BolasManager instance;
    bool cena2;
    void Start()
    {
        cena2 = TempoManager.instance.foiParaASegunda();
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if(Smoll)
        {
            tempo += Time.deltaTime;
            if(tempo > 6f)
            {
                 myDelegate2();
                Smoll = false;
                tempo = 0;
            }
        }

    }

    // Update is called once per frame
    public void SpawnFocar(float distance, Collider2D collision, Vector3 spawnposition)
    {
        if (!cena2)
        {
            Debug.Log("CEna DOIS");
            while (distance < 2f)
            {
                spawnposition = new Vector3(Random.Range(-9f, -2f), Random.Range(2f, 3.8f), 0);
                distance = Vector3.Distance(collision.transform.position, spawnposition);
            }
        }
        else
        {


            while (distance < 2f)
            {
                spawnposition = new Vector3(Random.Range(-9f, 9f), Random.Range(2f, -2f), 0);
                distance = Vector3.Distance(collision.transform.position, spawnposition);
            }

        }
        bolaAdd = Instantiate(bolaFoco, spawnposition, Quaternion.identity);
        Bolas.Add(bolaAdd);
        myDelegate += bolaAdd.GetComponent<BolaVerde>().Shrink;
        myDelegate2 += bolaAdd.GetComponent<BolaVerde>().Growth;
        DontDestroyOnLoad(bolaAdd);
    }
    public void SpawnRed(float distance, Collider2D collision, Vector3 spawnposition)
    {
        if (!cena2)
        {
            Debug.Log("CEna DOIS");
            while (distance < 2f)
            {
                spawnposition = new Vector3(Random.Range(-9f, -2f), Random.Range(2f, 3.8f), 0);
                distance = Vector3.Distance(collision.transform.position, spawnposition);
            }
        }
        else
        {


            while (distance < 2f)
            {
                spawnposition = new Vector3(Random.Range(-9f, 9f), Random.Range(2f, -2f), 0);
                distance = Vector3.Distance(collision.transform.position, spawnposition);
            }

        }

        bolaAdd = Instantiate(bolaVermelha, spawnposition, Quaternion.identity);

        Bolas.Add(bolaAdd);
        myDelegate += bolaAdd.GetComponent<BolaVerde>().Shrink;
        myDelegate2 += bolaAdd.GetComponent<BolaVerde>().Growth;
        DontDestroyOnLoad(bolaAdd);
    }



    public void DestruirLista()
    {
        foreach (GameObject obj in Bolas)
        {
            Destroy(obj);
        }
    }

    public void PowerUpCathed()
    {
        Smoll = true;
    }
}