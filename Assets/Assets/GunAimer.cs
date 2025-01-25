
using UnityEngine;

public class GunAimer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Vector3 mousePos;
    [SerializeField] float speed = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        float angle = Vector2.Angle(transform.position, mousePos);
        Debug.Log(angle);

        transform.Rotate(new Vector3(0, 0, angle));

        // Debug.DrawRay(this.transform.position, this.transform.forward * 1000f, Color.green);
    }
}
