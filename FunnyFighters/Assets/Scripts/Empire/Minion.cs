using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Minion : MonoBehaviour
{
    public bool hovered;
    public bool selected;
    private SpriteRenderer render;
    private NavMeshAgent agent;

    private GameObject target;
    public bool attacking;

    public float attackDistance = 5f;

    //Status
    private bool shootable = true;
    private bool reloaded = true;

    [Header("Characteristics")]
    private float reloadStart;
    public float reloadTime;

    [Header("Projectiles")]
    public GameObject projectile;


    //Mouse vars
    private Vector3 rotation;
    private Vector3 mousePos;
    private float rotz;

    


    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (!reloaded)
        {
            if (Time.time - reloadStart > reloadTime)
            {
                reloaded = true;
            }
        }
        if (attacking)
        {
            if (target != null)
            {
                if (Vector3.Distance(transform.position, target.transform.position) < attackDistance)
                {
                    agent.SetDestination(transform.position);
                    if (reloaded)
                    {
                        rotation = target.transform.position - transform.position;
                        rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
                        //Shooting
                        if (reloaded)
                        {
                            reloadStart = Time.time;
                            reloaded = false;
                            Instantiate(projectile, transform.position, Quaternion.Euler(0f, 0f, rotz));
                        }
                    }
                }
                else
                {
                    agent.SetDestination(target.transform.position);

                }
            }
            else
            {
                attacking = false;
                agent.SetDestination(transform.position);
                Enemy[] enemies = FindObjectsOfType<Enemy>();
                foreach (Enemy i in enemies)
                {
                    if (target == null)
                    {
                        if (Vector3.Distance(i.transform.position, transform.position) < attackDistance)
                        {
                            target = i.gameObject;
                            attacking = true;
                        }
                    }
                    
                }
            }


        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LineMaker"))
        {
            hovered = true;
            render.color = Color.grey;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LineMaker"))
        {
            hovered = false;
            if (!selected)
            {
                render.color = Color.white;
            }
        }
    }

    public void Select()
    {
        render.color = Color.cyan;
        selected = true;
    }

    public void Deselect()
    {
        render.color = Color.white;
        selected = false;
    }

    public void setLocation(Vector3 location)
    {
        attacking = false; 
        agent.SetDestination(new (location.x, location.y, 0));
    }

    public void setAttack(GameObject targetA)
    {
        target = targetA;
        attacking = true;
    }

    

}
