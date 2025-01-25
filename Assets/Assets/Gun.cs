using System;
using JetBrains.Annotations;
using UnityEngine;


public class Gun : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject BubbleBullet;
    public float BubbleSpeed = 200f;

    public Boolean charging;
    public float chargeTime = 0f;


    void Start()
    {
        // BubbleBullet = Instantiate(BubbleBulletObject, transform.position, transform.rotation).GetComponent<Rigidbody2D>();
    }

    void ShootCharge() {
        charging = true;
    }

    void ShootRelease() {
        
        chargeTime *= 2;

        charging = false;

        // speed limit of 20 units/sec 
        
        if (chargeTime > 20f) {
            chargeTime = 20f;
        }


        GameObject newGameObject = Instantiate(BubbleBullet, this.transform.position, this.transform.rotation);
        newGameObject.GetComponent<Bubble>().charge = chargeTime;
        chargeTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // update charge time 
        if (charging) {
            chargeTime += Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0)) {
            ShootCharge();
        }
        if (Input.GetMouseButtonUp(0)) {
            ShootRelease();
        }
    }
}
