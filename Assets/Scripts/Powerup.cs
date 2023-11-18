using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Powerup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BolasManager.instance.PowerUpCathed();
            BolasManager.instance.myDelegate();
            //Destroy(gameObject);

            BolaVermelha.MyDelegatePowerup();
        }
    }
}
