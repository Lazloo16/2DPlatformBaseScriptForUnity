using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rgbody;//We get Rigidbody2D component
    BoxCollider2D coll;
    SpriteRenderer player;

    [SerializeField]private int jumpPower = 7;          //we set how high the player wants it to jump
    [SerializeField]private float speed = 1f;           //we set how fast we want the player to go
    [SerializeField]private LayerMask jumpLayer;        //Where can we jump?

    private float jump = 0f;
    private float dirX = 0f;

    void Start()
    {
        player = GetComponent<SpriteRenderer>();
        rgbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        //Get Axis
        jump = Input.GetAxisRaw("Jump"); //Jump axis get 1 when space key down
        dirX = Input.GetAxisRaw("Horizontal"); // Horizontal axis get 1 or -1 when A or D || < or > pressed

        //Movement
        rgbody.velocity = new Vector2(dirX * speed, rgbody.velocity.y);

        //Jump
        if (jump != 0 && OnGrounded())
        {
            rgbody.velocity = new Vector2(rgbody.velocity.x, jumpPower);
        }
        //Set UpdateAnimState
        UpdateAnimState();
    }
    //Updating Animation State
    public void UpdateAnimState()
    {
        //We set animation
        if (dirX > 0f)
        {
            player.flipX = false;
        }

        else if (dirX < 0f)
        {
            player.flipX = true;
        }
    }
    private bool OnGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.01f, jumpLayer);

    }
}
