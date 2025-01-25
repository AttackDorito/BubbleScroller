using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEditor.UI;
using UnityEngine;

public class Bubble : MonoBehaviour
{

    Rigidbody2D rb;
    public float charge;
    public float lifespan = 8f;
    float age;
    public float maxCharge = 9f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (charge >= maxCharge) {
            charge = maxCharge;
        }

        rb = GetComponent<Rigidbody2D>();
        
        // charge determines size of bubble, bubble slows down charge
        
        float size = charge;
        float speed = (1/charge) * 10;

        rb.linearVelocity = new Vector3(speed, 0, 0);
        this.transform.localScale = new Vector3(charge, charge, charge);
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
