using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour 
{
    public float speedX;
    public float jumpSpeedY;
    public static bool dead;
    bool facingRight, jumping;
    float speed;
    public int jumpcount = 0;
    public float launchx = 400;
    public float launchy = 2000.0f;

    Animator anim;
    Rigidbody2D rb;
	// Use this for initialization
	void Start () 
    {
        dead = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        facingRight = true;
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (!dead)
        {
            MovePlayer(speed); //update move
            //Moving Left
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                anim.SetInteger("State", 1);
                speed = -speedX;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                anim.SetInteger("State", 0);
                speed = 0;
            }
            //Moving Right
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                speed = speedX;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                speed = 0;
            }

            
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                jumping = true;
                rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
                anim.SetInteger("State", 3);
            }
            
        }
        else
        {
            Invoke("reset",3);
        }
	}
    void reset()
    {
        SceneManager.LoadScene("Menu");
    }
    void MovePlayer(float playerSpeed)
    {
        Flip();
        //movespeed
        if (playerSpeed < 0 && !jumping || playerSpeed > 0 && !jumping)
        {
            anim.SetInteger("State", 2);
        }

        if (playerSpeed == 0 && !jumping)
        {
            anim.SetInteger("State", 0);
        }

        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
    }

    void Flip()
    {
        if (speed > 0 && !facingRight || speed < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "GROUND")
        {
            jumpcount = 0;
            jumping = false;
            anim.SetInteger("State", 0);
        }

        if (other.gameObject.tag == "BOMB" && !dead)
        {
            dead = true;
            anim.SetInteger("State", -1);

            float tmp = (Random.Range(0, 1));
            float dir;
            if ((int)tmp == 0)
            {
                dir = launchx;
            }
            else
            {
                dir = -launchx;
            }
            
            rb.AddForce(new Vector2(dir,launchy));
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "BOMB" && dead)
        {
            Destroy(other.gameObject);
        }


    }

    public void WalkLeft()
    {
        speed = -speedX;
    }

    public void WalkRight()
    {
        speed = speedX;
    }
    public void StopMoving()
    {
        speed = 0;
    }

    public void jump()
    {
        jumping = true;
        jumpcount += 1;
        if (jumpcount < 3 && !dead)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
            anim.SetInteger("State", 3);
        }
           
        

    }
}
