using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public GameObject damagePopup;
    
    
    void Start()
    {
        health = maxHealth;
    }

    public void takeDamage(float damage)
    {
        float damageValue = Mathf.Round(damage * Random.Range(0.9f, 1.1f) + Random.Range(0, 2));
        health -= Mathf.Round(damageValue);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        GameObject popup = Instantiate(damagePopup, transform.position, Quaternion.identity);
        DamPopScript pop = popup.GetComponent<DamPopScript>();
        pop.damageNumber(damageValue);
    }
}
