using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEditor.UI;
using UnityEngine;

public class Bubble : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed = 10f;
    public float lifespan = 8f;
    float age;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector3(speed, 0, 0);
        age = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // increment object age
        age += Time.deltaTime;
        Debug.Log(age);
        if (age > lifespan) {
            Destroy(gameObject);
        }
    }
}
