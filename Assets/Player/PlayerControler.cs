using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveForce = 50f;
    public float maxSpeed = 12f;
    public float dragFactor = 2f;
    
    InputAction moveAction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        Vector2 inputVector = moveAction.ReadValue<Vector2>();
        rb.AddForce(inputVector * moveForce);
        rb.AddForce(-rb.linearVelocity*dragFactor);
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);
    }
}
