using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    Rigidbody2D rgbody;
    Animator anim;
    public AudioSource deathSound;
    public Text deadText;
    PlayerMovement pm;

    private int DeadCount = 0;

    void Start() {
        DeadCount = 0;
        pm = GetComponent<PlayerMovement>();
        rgbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        DeadCount++;
        deadText.text = "Dead Count = " + DeadCount;
        pm.muteJump(true);
        deathSound.Play();
        rgbody.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
