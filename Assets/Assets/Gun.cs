using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject BubbleBullet;
    public float BubbleSpeed = 200f;

    public Boolean charging;
    public float chargeTime = 0f;
    [SerializeField] Camera sceneCamera;

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
        
        if (chargeTime > 10f) {
            chargeTime = 10f;
        }
        else if (chargeTime < 0.25f) {
            chargeTime = 0.25f;
        }
        
        GameObject newGameObject = Instantiate(BubbleBullet, this.transform.position, this.transform.rotation);
        newGameObject.GetComponent<Bubble>().charge = chargeTime;
        chargeTime = 0f;

        // direction of bubble
        
        newGameObject.GetComponent<Bubble>().dir = (sceneCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        
    }

    // Update is called once per frame;
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
        
        updateRotation();
        Debug.DrawLine((transform.position + transform.right*10), transform.position, Color.magenta);

    }

    void updateRotation() {
        Vector2 mouseVector = sceneCamera.ScreenToWorldPoint(Input.mousePosition) - transform.parent.position;
        //Debug.Log(mouseVector);
        float mouseAngle = -(Mathf.Atan2(mouseVector.x, mouseVector.y) * Mathf.Rad2Deg) + 90;
        // Debug.Log(mouseAngle);
        transform.parent.rotation = Quaternion.Euler(new Vector3(0, 0, mouseAngle));
    }
}
