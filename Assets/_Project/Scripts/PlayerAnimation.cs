using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private PlayerController playerController;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }
    void Update()
    {
        if (playerController.playerIsAlive)
        {
            Vector2 direction = playerController.direction;
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
