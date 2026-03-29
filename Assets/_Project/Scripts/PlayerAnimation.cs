using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private PlayerController _playerController;

    void Start()
    {
        animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
    }
    void Update()
    {
        if (_playerController.playerIsAlive)
        {
            Vector2 direction = _playerController.direction;
            bool isWalking = direction != Vector2.zero;
            animator.SetBool("IsWalking", isWalking);
            if (isWalking)
            {
                animator.SetFloat("InputX", direction.x);
                animator.SetFloat("InputY", direction.y);
            }
        }
        else
        {
            animator.SetBool("IsDying", true);
        }
    }
}
