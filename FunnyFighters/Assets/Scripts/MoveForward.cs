using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 5f;
    

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
