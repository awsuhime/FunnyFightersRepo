using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaging : MonoBehaviour
{
    public int pierce = 3;
    public float damage = 5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Damageable"))
        {
            Health health = collision.GetComponent<Health>();
            health.takeDamage(damage);
            pierce--;
            if (pierce == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
