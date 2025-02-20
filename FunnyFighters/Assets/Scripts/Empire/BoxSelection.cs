using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoxSelection : MonoBehaviour
{
    private LineRenderer line;
    private Vector2 initial, current;
    private BoxCollider2D col;
    private List<Minion> minions = new List<Minion>();
    public float detectionRadius = 0.1f;
    public LayerMask detection;

    public GameObject selectionParticle;
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (Input.GetMouseButtonDown(1))
        {
            GameObject target = null;
            float closest = detectionRadius;
            Vector3 flatMouse = new(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            Collider2D[] hits = Physics2D.OverlapCircleAll(flatMouse, detectionRadius);
            Debug.Log(hits.Length);
            foreach (Collider2D hit in hits)
            {
                if (hit.gameObject.CompareTag("Selectable") || hit.gameObject.CompareTag("Enemy"))
                {
                    target = hit.gameObject;    
                    
                    
                }
                
            }
            if (minions.Count > 0) 
            {
                if (target != null)
                {
                    foreach (Minion i in minions)
                    {
                        i.setAttack(target.gameObject);
                    }
                }
                else
                {
                    foreach (Minion i in minions)
                    {
                        i.setLocation(flatMouse);
                        Instantiate(selectionParticle, flatMouse, Quaternion.identity);
                    }
                }
            } 
            
        }

        if (Input.GetMouseButtonDown(0))
            {
                foreach (Minion i in minions)
                {
                    i.Deselect();
                }
                minions.Clear();
                line.positionCount = 4;
                initial = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                line.SetPosition(0, new Vector2(initial.x, initial.y));
                line.SetPosition(1, new Vector2(initial.x, initial.y));
                line.SetPosition(2, new Vector2(initial.x, initial.y));
                line.SetPosition(3, new Vector2(initial.x, initial.y));
                col = gameObject.AddComponent<BoxCollider2D>();
                col.isTrigger = true;
                col.offset = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            }

            if (Input.GetMouseButton(0))
            {
                current = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                line.SetPosition(0, new Vector2(initial.x, initial.y));
                line.SetPosition(1, new Vector2(initial.x, current.y));
                line.SetPosition(2, new Vector2(current.x, current.y));
                line.SetPosition(3, new Vector2(current.x, initial.y));

                transform.position = (current + initial) / 2;

                col.size = new Vector2(Mathf.Abs(initial.x - current.x), Mathf.Abs(initial.y - current.y));



            }
            if (Input.GetMouseButtonUp(0))
            {
                Minion[] allMinions = FindObjectsOfType<Minion>();
                foreach (Minion i in allMinions)
                {
                    if (i.hovered)
                    {
                        minions.Add(i);
                        i.Select();
                    }
                }
                line.positionCount = 0;
                Destroy(col);
                transform.position = Vector3.zero;
            }
        }
    }

