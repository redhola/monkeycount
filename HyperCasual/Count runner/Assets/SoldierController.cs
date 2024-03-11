using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    
    private FollowerBehaviour followerBehaviour;
    private Animator animator;
    private bool isFollowing;
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (isFollowing)
        {
            followerBehaviour.SetInitialDestination();            
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}
