using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    public bool hovered;
    public bool selected;
    private SpriteRenderer render;

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
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
}
