using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] 
    private GameObject bulletPrefab;

    [SerializeField]
    private float fireRate = 0.5f;

    [SerializeField]
    private float fireRange = 5;

    private float nextFireTime;

    private float lastShootTime;
    
    private EnemyManager enemyManager;

    private void Awake()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
    }
    void Update()
    {
     if(Time.time - lastShootTime > fireRate)
        {
            lastShootTime = Time.time;
            Shoot();
        }
    }
     GameObject NearestEnemy()
    {
        GameObject _nearestEnemy = null;

        float _nearestDist = fireRange;

        foreach (EnemyController currentEnemy in enemyManager.listEnemies)
        {
            float _currentDist = Vector2.Distance(transform.position, currentEnemy.transform.position);
            if (_currentDist < _nearestDist)
            {
                _nearestDist = _currentDist;
                _nearestEnemy = currentEnemy.gameObject;
            }
        }
        return _nearestEnemy;
    }
    void Shoot()
    {
        GameObject Target = NearestEnemy();
        if (Target == null) return;

        Vector2 targetPos = Target.GetComponent<Rigidbody2D>().position;
        Vector2 shootPos = transform.position;
        Vector2 direction = (targetPos - shootPos).normalized;

        float spawnOffset = 0.2f;
        Vector2 spawnBulletPos = shootPos + direction * spawnOffset;

        if (bulletPrefab != null)
        {
            GameObject cloneBullet = Instantiate(bulletPrefab, spawnBulletPos, Quaternion.identity);
            cloneBullet.gameObject.GetComponent<Bullet>().Shoot(direction);
        }
    }
}
