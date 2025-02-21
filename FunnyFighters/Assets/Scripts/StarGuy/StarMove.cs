using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMove : MonoBehaviour
{
    public float speed = 25f;
    public float slowedSpeed = 7.5f;
    public float fastTime = 0.5f;
    private float fastStart;

    public float damage = 1;
    private float attackStart;
    public float atttackInterval = 0.1f;
    public float rotateSpeed;
    public GameObject sprite;
    private List<GameObject> hits = new List<GameObject>();

    private void Start()
    {
        fastStart = Time.time;
        Damage();
    }
    void Update()
    {
        sprite.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);

        if (Time.time - attackStart > atttackInterval)
            {
                Damage();
            }
        
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (Time.time - fastStart > fastTime)
        {
            speed = slowedSpeed;
        }
    }

    private void Damage()
    {
        foreach (GameObject i in hits)
        {
            Health health = i.GetComponent<Health>();
            health.takeDamage(damage);
        }
        attackStart = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hits.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hits.Remove(collision.gameObject);
        }
    }
}
