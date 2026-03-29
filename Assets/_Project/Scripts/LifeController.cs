using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField]
    private int maxLife = 10;

    private int life;

    private EnemyController _enemyControl;

    private PlayerController _playerControl;

    void Awake()
    {
        _enemyControl = GetComponent<EnemyController>();
        _playerControl = GetComponent<PlayerController>();
        life = maxLife;
    }
    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            if(this.CompareTag("Player"))
            {
                _playerControl.playerIsAlive = false;
                _playerControl.rb.simulated = false;
                _playerControl._collider.enabled = false;
            }
            if (this.CompareTag("Enemy"))
            {
                _enemyControl.enemyIsAlive = false;
            }

            Destroy(gameObject, 1f);
        }
        else
        {
            if (this.CompareTag("Enemy"))
            {
                _enemyControl.enemyIsHit = true;
            }
        }
    }
}
