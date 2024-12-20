using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public float damage = 1;
    private Vector2 direction;
    public Vector2 Direction
    {
        set
        {
            direction = value.normalized;
        }
    }

    void Start()
    {

    }


    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("Enemy"))
        {
            gameObject.SetActive(false); 
        }
    }

    
}
