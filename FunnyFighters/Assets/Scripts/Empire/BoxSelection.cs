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
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
            foreach(Minion i in allMinions)
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
