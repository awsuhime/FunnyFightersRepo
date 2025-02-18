using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.Events;

public class AbilitySelect : MonoBehaviour
{
    public int currentSelection;
    private int maxAbilities;

    public UnityEvent first;
    public UnityEvent second;
    public UnityEvent third;
    public UnityEvent fourth;
    public UnityEvent fifth;


    void Update()
    {
        //Activate Ability
        if (Input.GetMouseButtonDown(0))
        {
            if (currentSelection == 1)
            {
                first.Invoke();
            }
            else if (currentSelection == 2)
            {
                second.Invoke();
            }
            else if (currentSelection == 3)
            {
                third.Invoke();
            }
            else if (currentSelection == 4)
            {
                fourth.Invoke();
            }
            else if (currentSelection == 5)
            {
                fifth.Invoke();
            }

        }
        //Select Ability
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (first != null)
            {
                if (currentSelection != 1)
                {
                    currentSelection = 1;
                }
                else
                {
                    currentSelection = 0;
                }
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (second != null)
            {
                if (currentSelection != 2)
                {
                    currentSelection = 2;
                }
                else
                {
                    currentSelection = 0;
                }
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (third != null)
            {
                if (currentSelection != 3)
                {
                    currentSelection = 3;
                }
                else
                {
                    currentSelection = 0;
                }
            }
           
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (fourth != null)
            {
                if (currentSelection != 4)
                {
                    currentSelection = 4;
                }
                else
                {
                    currentSelection = 0;
                }
            }

            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (fifth != null)
            {
                if (currentSelection != 5)
                {
                    currentSelection = 5;
                }
                else
                {
                    currentSelection = 0;
                }
            }

            
        }
    }
}
