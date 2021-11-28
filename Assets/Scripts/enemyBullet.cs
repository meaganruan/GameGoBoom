using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyBullet : MonoBehaviour
{
    [SerializeField] GameObject bullet1;
    [SerializeField] Rigidbody2D plane;
    const float speed = 15.0f;
    public AudioSource audio;
    

    // Start is called before the first frame update
    void Start()
    {
        if (audio == null)
            audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {   

        if(SceneManager.GetActiveScene().name == "Level1")
        {
            level1();
        }
        else if(SceneManager.GetActiveScene().name == "Level2")
        {
            level2();   
        }
        else if(SceneManager.GetActiveScene().name == "Level3")
        {
            level3(); 
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.name == "plane"){
                AudioSource.PlayClipAtPoint(audio.clip, transform.position);
                Destroy(gameObject);

            }
        }

    void level1()
    {
        //need to move bullet across screen horizontally
        transform.Translate(new Vector2 (-10f,0f) * speed * Time.deltaTime);
      
    }

    void level2()
    {
        //need to move bullet across screen horizontally faster
        transform.Translate(new Vector2 (-10f,0f) * (speed*2) * Time.deltaTime);
      
    }

    void level3()
    {
        //chasing algorithm
        transform.Translate(new Vector2 (plane.transform.position.x,plane.transform.position.y) * (speed*3) * Time.deltaTime);
      
    }

}
