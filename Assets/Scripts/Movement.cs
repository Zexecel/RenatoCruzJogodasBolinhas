using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rgd;
    Animator animator;
    float velocidade = 5f;
    float horizontal;
    float vertical;

    private bool isFacingRight = true;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        animator = gameObject.GetComponent<Animator>();
        rgd = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Flip();

    }
    private void FixedUpdate()
    {
        
        
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(velocidade * horizontal, velocidade * vertical, 0);

            rgd.velocity = movement;


            animator.SetFloat("Andar", rgd.velocity.magnitude);
            
        
        
    }


    public void aleijou()
    {
        rgd.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("morte");
    }

    private void Flip()
    { if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) { isFacingRight = !isFacingRight; Vector3 localscale = transform.localScale; localscale.x *= -1f; transform.localScale = localscale; }

    }


    public void Morte()
    {
        Destroy(gameObject);
        BolasManager.instance.DestruirLista();
        SceneManager.LoadScene("End");
        TempoManager.instance.ResetTime();
        Destroy(gameObject);
    }
}
