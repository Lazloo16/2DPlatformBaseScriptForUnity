using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    PlayerLife rst;
    Rigidbody2D rgbody;
    SpriteRenderer player;
    Animator anim;
    BoxCollider2D coll;
    Animator jumpAnimator;

    public int jumpPower = 7;
    public float speed = 1f;
    public LayerMask jumpLayer;
    public AudioSource jumpSoundEffect;
    public AudioSource finishSound;

    
    private enum MovementState { idle,running,jumping,falling}
    private float jump = 0;
    private float dirX = 0f;
    private float jumpForTramboline = 0;


    void Start()
    {
        muteJump(false);
        rst = GetComponent<PlayerLife>();
        player = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rgbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "tramboline")
        {
            jumpPower = jumpPower * 2;
            jumpForTramboline = 1;
            jumpAnimator.SetBool("jumptr", true);
        }
        if (collision.gameObject.name == "FinishFlag")
        {
            finishSound.Play();
            Invoke("CompleteLevel", 2f); 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if(collision.gameObject.name == "tramboline") 
        {
            jumpPower = jumpPower / 2;
            jumpForTramboline = 0;
            jumpAnimator.SetBool("jumptr", false); 
        }
       
    }
        
 

    void Update()
    {

        if (Input.GetKeyDown("r"))
            rst.Restart();

        //Get Axis
        jump = Input.GetAxisRaw("Jump"); //Jump axis get 1 when space key down
        dirX = Input.GetAxisRaw("Horizontal"); // Horizontal axis get 1 or -1 when A or D || < or > pressed

        //Movement
        rgbody.velocity = new Vector2(dirX * speed, rgbody.velocity.y);

        //Jump
        if (jump !=0 && OnGrounded() || jumpForTramboline != 0 && OnGrounded()) { 
            
            rgbody.velocity = new Vector2(rgbody.velocity.x, jumpPower);
            jumpSoundEffect.Play();
        }

        //Set UpdateAnimState
        UpdateAnimState();
    }

    //Updating Animation State
    public void UpdateAnimState()
    {
        MovementState state;
        //We set animation
        if (dirX > 0f)
        {
            state = MovementState.running;
            player.flipX = false;
        }
            
        else if (dirX < 0f)
        {
            state = MovementState.running;
            player.flipX = true;
        }
        else
            state = MovementState.idle;

        if (rgbody.velocity.y > .1f)
            state = MovementState.jumping;
        else if (rgbody.velocity.y < -.1f)
            state = MovementState.falling;

        anim.SetInteger("State", (int)state);
    }
    private bool OnGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.01f,jumpLayer);

    }

    public void muteJump(bool yn)
    {
        jumpSoundEffect.mute = yn;
    }
    public void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
