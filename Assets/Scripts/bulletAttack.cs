using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletAttack : MonoBehaviour
{
    [SerializeField] GameObject bullet;
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
        //need to move bullet across screen horizontally
        transform.Translate(new Vector2 (10f,0f) * speed * Time.deltaTime);
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "enemyplane"){
                AudioSource.PlayClipAtPoint(audio.clip, transform.position);
                Destroy(gameObject);

            }
        }
}
