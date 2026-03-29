using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyManager enemyManger;

    [SerializeField]
    private float speed = 2.5f;

    private Transform player;

    [SerializeField]
    private int damage = 10;

    public Vector2 direction;

    public bool enemyIsAlive = true;

    public bool enemyIsHit = false;

    void OnEnable()
    {
        enemyManger.AddEnemy(this);
    }
    void OnDisable()
    {
        enemyManger.RemoveEnemy(this);
    }
    void Awake()
    {
        enemyManger = FindObjectOfType<EnemyManager>();
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (enemyIsAlive)
        {
            if (player == null)
            {
                direction = Vector2.zero;
                return;
            }
                
            direction = (player.position - transform.position).normalized;
            Vector3 movement = new Vector3(direction.x, direction.y, 0f);
            transform.position += movement * speed * Time.deltaTime;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LifeController life = collision.gameObject.GetComponent<LifeController>();
            if (life != null)
            {
                life.TakeDamage(damage);
            }
            enemyIsAlive = false;
            Destroy(gameObject, 1f);
        }
    }
}
