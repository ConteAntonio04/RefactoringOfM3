using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{
 
    public Rigidbody2D rb;

    [SerializeField]
    private float speed = 3f;

    private float h, v; 

    public Vector2 direction;

    public bool playerIsAlive = true;

    public Collider2D _collider;

    void Awake()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        if (_collider == null)
        {
            _collider = GetComponent<Collider2D>();
        }
    }

    void Update()
    {
        if (playerIsAlive)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            direction = new Vector2(h, v).normalized;
            CheckMovement();
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * (speed * Time.fixedDeltaTime));
    }

    void CheckMovement()
    {
        float sqrLenght = direction.sqrMagnitude;
        if (sqrLenght > 1)
        {
            direction = direction / Mathf.Sqrt(sqrLenght);
        }
    }
}
