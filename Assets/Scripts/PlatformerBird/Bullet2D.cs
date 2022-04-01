using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2D : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //bullet Launch
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // collider detects "enemy"
        if (other.gameObject.CompareTag("enemy"))
        {
            // Destroy bullet
            Destroy(gameObject);
            // Destroy enemy
            Destroy(other.gameObject);
        }

        // collider detects "Block"
        if (other.gameObject.CompareTag("Block"))
        {
            // Destroy bullet
            Destroy(gameObject);
        }
    }
}
