using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFocar : BolaVerde
{
    GameObject player;
    
    float forcaBounce = 5;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    

    public override void Bounce(Collision2D collision, Vector3 lastVel)
    {
        
        Vector2 direcao = (player.transform.position - transform.position).normalized;


        rb.velocity = direcao * forcaBounce;

        if (gameObject.tag == "BolaVermelha" && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Movement>().aleijou();
            
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Bounce(collision, lastVel);
    }


}
