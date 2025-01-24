using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public float verticalSpeed = 10;
    public float horizontalSpeed = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal")*horizontalSpeed;
        float vertical = Input.GetAxis("Vertical")*verticalSpeed;
        rb.linearVelocity = new Vector2(horizontal, vertical);
    }
}
