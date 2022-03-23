using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollecter : MonoBehaviour
{
    public Text Sttext;
    private int st = 0;
    public AudioSource collectSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("collectable"))
        {
            collectSound.Play();
            st++;
            Destroy(collision.gameObject);
            Sttext.text = "Strawberry's : " + st;
        }
    }
}
