using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    [SerializeField] GameObject bullet1;
    const float speed = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //need to move bullet across screen horizontally
        transform.Translate(new Vector2 (-10f,0f) * speed * Time.deltaTime);
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.name == "plane"){
                Destroy(gameObject);

            }
        }
}
