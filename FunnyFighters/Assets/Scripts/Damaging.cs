using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaging : MonoBehaviour
{
    public int pierce = 3;
    public float damage = 5;
    public bool ally = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() != null)
        {
            Health health = collision.GetComponent<Health>();

            if (ally && !health.ally)
            {
                health.takeDamage(damage);
                pierce--;
                if (pierce == 0)
                {
                    Destroy(gameObject);
                }
            }
            
        }
    }
}
