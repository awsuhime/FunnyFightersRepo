using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingStar : MonoBehaviour
{
    public float speed = 5f;
    public float homingSpeed = 2.5f;
    public float homingTime = 1f;
    private float creationTime;
    private GameObject target;
    private float closestDistance = 50f;
    private bool homing;
    private Rigidbody2D rb;
    private bool noTarget;
    public float damage = 7f;
    private bool activated;
    void Start()
    {
        creationTime = Time.time;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        if (!homing || noTarget)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (!noTarget && Time.time - creationTime > homingTime)
            {
                activated = true;
                homing = true;
                Health[] enemies = FindObjectsOfType<Health>();
                foreach(Health i in enemies)
                {
                    if (!i.ally && Vector3.Distance(transform.position, i.gameObject.transform.position) < closestDistance)
                    {
                        target = i.gameObject;
                        closestDistance = Vector3.Distance(transform.position, i.gameObject.transform.position);
                    }
                }
                if (target == null)
                {
                    noTarget = true;
                }
            }
        }
        else if(!noTarget)
        {
            if (target == null)
            {
                closestDistance = 50f;
                Health[] enemies = FindObjectsOfType<Health>();
                foreach (Health i in enemies)
                {
                    if (!i.ally && Vector3.Distance(transform.position, i.gameObject.transform.position) < closestDistance)
                    {
                        target = i.gameObject;
                        closestDistance = Vector3.Distance(transform.position, i.gameObject.transform.position);
                    }
                }
                if (target == null)
                {
                    rb.velocity = Vector2.zero;
                    homing = false;
                    noTarget = true;
                }
            }
            else
            {
                rb.AddForce((target.transform.position - transform.position).normalized * homingSpeed);

            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activated)
        {
            if (collision.gameObject.GetComponent<Health>() != null)
            {
                Health health = collision.gameObject.GetComponent<Health>();
                if (!health.ally)
                {
                    health.takeDamage(damage / 3);

                }

            }

        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (activated)
        {
            if (collision.gameObject.GetComponent<Health>() != null)
            {
                Health health = collision.gameObject.GetComponent<Health>();
                if (!health.ally)
                {
                    health.takeDamage(damage + rb.velocity.magnitude);
                    Destroy(gameObject);
                }

            }

        }
    }
    
}
