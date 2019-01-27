using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animator animator = gameObject.GetComponent<Animator>();
        Destroy(gameObject, GetAnimationClipLength(animator, 0));
    }

    float GetAnimationClipLength(Animator animator, int clipIndex)
    {
        return animator.runtimeAnimatorController.animationClips[clipIndex].length - 0.05f;
    }
}
