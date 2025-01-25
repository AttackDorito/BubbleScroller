using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   

        // if (Collider2D.GetComponent<EnemyCollider2D>() != null);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log(collision.gameObject.name);
        Debug.Log("collision");
        if (collision.gameObject.name == "Bubble") {
            transform.position = collision.gameObject.transform.position;
        }
    }
}
