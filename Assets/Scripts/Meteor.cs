using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    //float size = 50f;
    public float speed = 5f;

    //SpriteRenderer renderer;
    // Start is called before the first frame update
    //void Start()
    //{
    //    renderer = GetComponent<SpriteRenderer>();

    //    float x = Random.Range(25.0f, 736.0f);
    //    float y = Random.Range(1127.0f, 1255.0f);

    //    transform.position = new Vector3(x, y, 0);
    //}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime); 

        if (transform.position.y < 50) 
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
