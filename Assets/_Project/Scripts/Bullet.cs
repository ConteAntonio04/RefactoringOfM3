using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float speed = 6f;

    [SerializeField]
    private int damage = 1;

    [SerializeField]
    private float lifeTime = 2f;

    private Vector2 direction;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * (speed * Time.fixedDeltaTime));
    }
    public void Shoot(Vector2 dir)
    {
      direction = dir.normalized;
      transform.up = direction;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LifeController life = collision.GetComponent<LifeController>();
        if (life != null)
        {
            life.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }
        if (collision.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
