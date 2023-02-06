using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingScript : MonoBehaviour
{
    public Animator animator;

        public void triggerAnimation()
        {
        animator.Play("Base Layer.Ring", 0, 0.0f);

        }
    
}
