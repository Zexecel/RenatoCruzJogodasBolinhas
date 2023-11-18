using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLevel : MonoBehaviour
{
    static MusicLevel instance;

    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject); // If an instance already exists, destroy this duplicate
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        // Your existing code for managing the music
    }
}
