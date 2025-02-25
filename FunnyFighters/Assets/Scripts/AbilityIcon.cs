using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AbilityIcon : MonoBehaviour
{
    public string abilityName;
    public float selectDistance = 10;
    public bool selected;
    public int id;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Select(int sentid)
    {
        if (sentid == id)
        {
            if (!selected)
            {
                transform.Translate(0, selectDistance, 0);
            }
            selected = true;
        }
        else
        {
            if (selected)
            {
                transform.Translate(0, -selectDistance, 0);
            }
            selected = false;
        }
    }

    
}
