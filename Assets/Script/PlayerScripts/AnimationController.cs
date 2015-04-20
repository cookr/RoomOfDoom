﻿using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {
    public RuntimeAnimatorController[] animators;

    private enum Animation
    {
        IDLE,
        WALK
    };
    private Animation currentAnimation;
    private Animator animator;

	// Use this for initialization
	void Start () {
        currentAnimation = Animation.IDLE;
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("a") && Input.GetKey("w"))
        {
            UpdateAnimationState(Animation.WALK);            
        }
        else if (Input.GetKey("a") && Input.GetKey("s"))
        {
            UpdateAnimationState(Animation.WALK);           
        }
        else if (Input.GetKey("d") && Input.GetKey("w"))
        {
            UpdateAnimationState(Animation.WALK);           
        }
        else if (Input.GetKey("d") && Input.GetKey("s"))
        {            
            UpdateAnimationState(Animation.WALK);
        }
        else if (Input.GetKey("w"))
        {
            UpdateAnimationState(Animation.WALK);
        }
        else if (Input.GetKey("s"))
        {
            UpdateAnimationState(Animation.WALK);
        }
        else if (Input.GetKey("a"))
        {
            UpdateAnimationState(Animation.WALK);
        }
        else if (Input.GetKey("d"))
        {
            UpdateAnimationState(Animation.WALK);
        }
        else
        {
            UpdateAnimationState(Animation.IDLE);
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            animator.runtimeAnimatorController = animators[0];
        }

        // Ranged weapon 1
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            animator.runtimeAnimatorController = animators[1];
        }

        // Ranged weapon 2
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            animator.runtimeAnimatorController = animators[1];
        }
	}

    void UpdateAnimationState(Animation curAnimState)
    {
        if (currentAnimation == curAnimState)
            return;

        switch (curAnimState)
        {
            case Animation.IDLE:
                animator.SetInteger("animationState", 0);
                break;
            case Animation.WALK:
                animator.SetInteger("animationState", 1);
                break;
        }

        currentAnimation = curAnimState;
    }
}