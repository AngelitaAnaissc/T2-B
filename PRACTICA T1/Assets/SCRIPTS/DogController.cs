using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    
   private bool b_morir = false;
   private bool tocando_suelo = false;
  
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sp;
    public int velocidad = 3;
    public int f_saltar = 1;
    private const int quieto = 0;
    private const int correr = 1;
    private const int saltar = 2;
    private const int morir = 3;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (b_morir ==false) { 
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y);
            animator.SetInteger("estado", correr);
            Debug.Log("entra");
            sp.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
            animator.SetInteger("estado", correr);
            sp.flipX = true;
        }
        else if (Input.GetKey(KeyCode.Space) && tocando_suelo)
        {
            rb.velocity = new Vector2(rb.velocity.x, f_saltar);
                 animator.SetInteger("estado", saltar);
                 tocando_suelo = false;
        }
      
        else
        {
            animator.SetInteger("estado", quieto);
        }

        }
        else if(b_morir == true) 
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        animator.SetInteger("estado", morir);
        }
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        tocando_suelo = true;
        if (collision.gameObject.name == "zombie")
        {
            
            b_morir = true;
        }
    }
}



