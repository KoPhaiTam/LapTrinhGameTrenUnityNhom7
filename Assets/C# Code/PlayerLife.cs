using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        
        if(collision.gameObject.CompareTag("Trap")) // nếu collide với object có gameTag là Trap thì die
        {
            Die();
            SceneManager.LoadScene("ContinueScene");
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death"); // chạy animation die
    }
}
