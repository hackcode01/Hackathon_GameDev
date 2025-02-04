using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float bulletSpeed = 2f; // Скорость пули
    private string _barrelTag = "barrel";

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Задаем начальную скорость пули
        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_barrelTag))
        {
            Destroy(collision.gameObject);
            Destroy(transform.gameObject);
        }
    }
}
