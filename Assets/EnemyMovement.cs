using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D enemyPlane;
    [SerializeField] int speed = 20;
    const int minY = 131;
    const int maxY = 289;
    public float maxTime = 10;
    public float minTime = 2;
    private float time;
    private float spawnTime;
    [SerializeField] GameObject bullet1;
    [SerializeField] bool isGrounded = false;
    private int health = 20;
    [SerializeField] Text healthText;
    public AudioClip audio;
    
    
    // Start is called before the first frame update
    private void Start()
    {   
        GetHealth();
        GetComponent<AudioSource> ().playOnAwake = false;
        GetComponent<AudioSource> ().clip = audio;
        
        if (enemyPlane == null)
        {
            enemyPlane = GetComponent<Rigidbody2D>();
        }
        if (time >= spawnTime)
        {
             SpawnObject();
             SetRandomTime();
         }
          
    }

    // Update is called once per frame
    private void Update()
    {
        
        if (health == 0)
        {
            GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }

        GetHealth();
        
        // Y axis
        //if y position is less than or equal to 6.7, then go up
        //spawn bullet and attack
        
        var targetPos = new Vector2(enemyPlane.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (transform.position.y >= maxY) 
        {
            isGrounded = false;
            transform.Translate(new Vector2 (0f,-10f) * speed * Time.deltaTime);
             
        } 
        if (isGrounded)
        {
            transform.Translate(new Vector2 (0f,10f) * speed * Time.deltaTime);
        } 
        // else enemyPlane.AddForce(transform.up * speed);
    }

    private void FixedUpdate()
    {
        //Counts up
        time += Time.deltaTime;
 
        //Check if its the right time to spawn the object
        if(time >= spawnTime)
        {
             SpawnObject();
             SetRandomTime();
        }
 
    }

    //track collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "bullet(Clone)")
        {   
            health -= 5;
            Debug.Log("Enemy Health: " + health);
        }

        if (collision.gameObject.name == "bot-platform")
        {    
            isGrounded = true;
        }

        
    }

    //GetHealth
    private void GetHealth()
    {
        healthText.text = "Health: " + health;
    }

    private void SpawnObject()
    {
        time = minTime;
        Instantiate(bullet1, enemyPlane.transform.position, Quaternion.identity);
    }

    private void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
    
}
