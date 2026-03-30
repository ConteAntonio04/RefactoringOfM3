using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField]
    private int maxLife = 10;

    private int life;

    private EnemyController enemyControl;

    private PlayerController playerControl;

    [Header("UI")]
    [SerializeField]
    private Slider healtSlider;

    void Awake()
    {
        enemyControl = GetComponent<EnemyController>();
        playerControl = GetComponent<PlayerController>();
        life = maxLife;
        SetupSlider();
        UpdateHealtBar();
    }
    void SetupSlider()
    {
        if(healtSlider != null)
        {
            healtSlider.maxValue = maxLife;
            healtSlider.value = life;
        }
    }
    void UpdateHealtBar()
    {
        if (healtSlider != null)
        {
            healtSlider.value = life;
        }
    }
    public void TakeDamage(int damage)
    {
        life -= damage;
        UpdateHealtBar();
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
