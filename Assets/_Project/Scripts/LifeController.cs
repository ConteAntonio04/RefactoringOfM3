using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField]
    private int maxLife = 10;

    private int life;

    private EnemyController enemyControl;

    private PlayerController playerControl;

    void Awake()
    {
        enemyControl = GetComponent<EnemyController>();
        playerControl = GetComponent<PlayerController>();
        life = maxLife;
    }
    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            if(this.CompareTag("Player"))
            {
                playerControl.playerIsAlive = false;
                playerControl.rb.simulated = false;
                playerControl.Collider.enabled = false;
            }
            if (this.CompareTag("Enemy"))
            {
                enemyControl.enemyIsAlive = false;
            }

            Destroy(gameObject, 1f);
        }
        else
        {
            if (this.CompareTag("Enemy"))
            {
                enemyControl.enemyIsHit = true;
            }
        }
    }
}
