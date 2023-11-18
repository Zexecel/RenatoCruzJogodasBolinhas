using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaVermelha : BolaVerde
{
    // Start is called before the first frame update

    public delegate void Powerup();
    public static Powerup MyDelegatePowerup;

    private void Start()
    {
        MyDelegatePowerup += powerup;
    }
    public override void Bounce(Collision2D collision, Vector3 lastVel)
    {
        base.Bounce(collision, lastVel);
        if (gameObject.tag == "BolaVermelha" && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Movement>().aleijou();
        }
    }

    public void powerup()
    {
        rb.transform.localScale /= 2;
    }
}