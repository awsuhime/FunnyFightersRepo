using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    private float startTime;
    public float lifeTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float timeLeft = Time.time - startTime;
        if (timeLeft > lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
