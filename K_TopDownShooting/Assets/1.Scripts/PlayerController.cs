using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    private Vector3 move;

    void Start()
    {
        
    }

    void Update()
    {
        move = Vector3.zero;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            move += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            move += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            move += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            move += new Vector3(0, -1, 0);
        }

        move = move.normalized;
        if (move.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (move.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (move.magnitude > 0)
        {
            GetComponent<Animator>().SetTrigger("Move");
        }
        else
        {
            GetComponent<Animator>().SetTrigger("Stop");
        }
    }

    void FixedUpdate()
    {
        transform.Translate(move * speed * Time.fixedDeltaTime);
    }
}