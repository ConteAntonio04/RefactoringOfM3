using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;

    private EnemyController _enemyController;

    void Start()
    {
        animator = GetComponent<Animator>();
        _enemyController = GetComponent<EnemyController>();
    }
    void Update()
    {
        if (_enemyController.enemyIsAlive)
        {
            if (_enemyController.enemyIsHit)
            {
                _enemyController.enemyIsHit = false;
                animator.SetTrigger("IsHit");
            }
            else
            {
                Vector2 direction = _enemyController.direction;
                bool isWalking = direction != Vector2.zero;
                animator.SetBool("IsWalking", isWalking);
                if (isWalking)
                {
                    animator.SetFloat("PosX", direction.x);
                    animator.SetFloat("PosY", direction.y);
                }
            }
        }
        else
        {
            animator.SetBool("IsDying", true);
        }
    }
}
