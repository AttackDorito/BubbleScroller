using System;
using Mono.Cecil;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject BubbleBullet;
    public float chargeRate;
    private bool charging = false;
    InputAction fireAction;
    
    private float chargeTime = 0f;
    [SerializeField] Camera sceneCamera;

    void Start()
    {
        fireAction = InputSystem.actions.FindAction("Fire");
        // BubbleBullet = Instantiate(BubbleBulletObject, transform.position, transform.rotation).GetComponent<Rigidbody2D>();

    }
    

    void fire(float chargeTime) {


        // speed limit of 20 units/sec 
        chargeTime = math.clamp(chargeTime,0.25f,2f);
        
        
        GameObject newGameObject = Instantiate(BubbleBullet, this.transform.position, this.transform.rotation);
        newGameObject.GetComponent<Bubble>().charge = chargeTime;

        // direction of bubble
        
        newGameObject.GetComponent<Bubble>().dir = (sceneCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        
    }

    // Update is called once per frame;
    void Update()
    {
        if (fireAction.WasPressedThisFrame())
        {   
            charging = true;
        }
        else if(fireAction.WasReleasedThisFrame())
        {
            charging = false;
            fire(chargeTime);
            chargeTime = 0f;
        }
        Debug.Log(chargeTime);
        updateRotation();

    }

    private void FixedUpdate()
    {
        if (charging)
        {
            chargeTime += chargeRate* Time.deltaTime;
        }
    }

    void updateRotation() {
        Vector2 mouseVector = sceneCamera.ScreenToWorldPoint(Input.mousePosition) - transform.parent.position;
        //Debug.Log(mouseVector);
        float mouseAngle = Vector2.SignedAngle(Vector2.right, mouseVector);
        // Debug.Log(mouseAngle);
        transform.parent.eulerAngles = new Vector3(0, 0, mouseAngle);

    }
}
