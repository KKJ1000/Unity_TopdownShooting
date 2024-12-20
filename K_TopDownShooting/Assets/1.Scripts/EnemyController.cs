using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    enum State
    {
        Spawning,
        Moving,
        Dying
    }

    public float speed = 2;

    public Material flashMeterial;
    public Material defaultMaterial;

    private GameObject target;
    State state;

    void Start()
    {

    }

    public void Spawn(GameObject target)
    {
        this.target = target;
        state = State.Spawning;
        GetComponent<Character>().Initialize();
        GetComponent<Animator>().SetTrigger("Spawn");
        Invoke("StartMoving", 1);
        GetComponent<Collider2D>().enabled = false;
    }

    void StartMoving()
    {
        GetComponent<Collider2D>().enabled = true;
        state = State.Moving;
    }

    void FixedUpdate()
    {
        if (state == State.Moving)
        {
            Vector2 direction = target.transform.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.fixedDeltaTime);

            if (direction.x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            if (direction.x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            float d = collision.gameObject.GetComponent<Bullet>().damage;

            if (GetComponent<Character>().Hit(d))
            {
                //살아있을 때
                Flash();
            }
            else
            {
                //죽었을 때
                Die();
            }
        }
    }

    void Flash()
    {
        GetComponent<SpriteRenderer>().material = flashMeterial;
        Invoke("AfterFlash", 0.5f);
    }

    void AfterFlash()
    {
        GetComponent<SpriteRenderer>().material = defaultMaterial;
    }

    void Die()
    {
        state = State.Dying;
        GetComponent<Animator>().SetTrigger("Die");
        Invoke("AfterDying", 1.4f);
    }

    void AfterDying()
    {
        gameObject.SetActive(false);
    }
}
