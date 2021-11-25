using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    float movement;
    [SerializeField] Rigidbody2D plane;
    const float speed = 50.0f;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] bool attackPressed = false;
    [SerializeField] float jumpForce = 750.0f;
    [SerializeField] GameObject bullet;
    [SerializeField] Text healthText;
    [SerializeField] int health = 5;
    

    // Start is called before the first frame update
    void Start()
    {
        GetHealth();
        if (plane == null)
            plane = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame; best for user input
    void Update()
    {
        
        if (health == 0)
        {
            Destroy(gameObject);
        }
        GetHealth();
        movement = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jumpPressed = true;
        }
        if(isFacingRight)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                attackPressed = true;
            }
        }
        
    }

    //FixedUpdate is called potentially multiple times per frame; best for physics and movement
    private void FixedUpdate()
    {
        plane.velocity = new Vector2(movement * speed, plane.velocity.y);

        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
        {    
            Flip();
        }
        if (jumpPressed) //only allow Mario to jump if he is on the ground -- no double jumps 
        {    
            Jump();
        }
        if (attackPressed) //control key on mac
        {   
            attack();
        }
    }
        
    //GetHealth
    private void GetHealth()
    {
        healthText.text = "Health: " + health;
    }

    private void Flip()
    {
        //Vector3 playerScale = transform.localScale;
        //playerScale.x = playerScale.x * -1;
        //transform.localScale = playerScale;

        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;

    }

    private void Jump()
    {
        plane.velocity = new Vector2(plane.velocity.x, 0);
        plane.AddForce(new Vector2(0, jumpForce));
        jumpPressed = false;
    }

    private void attack()
    {
        //need to spawn bullet object
        Instantiate(bullet, plane.transform.position, Quaternion.identity);
        attackPressed = false;
    }
    
    //track collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "bullet1(Clone)")
        {
        health -= 1;
        Debug.Log("Player Health: " + health);
        }
    }

}
