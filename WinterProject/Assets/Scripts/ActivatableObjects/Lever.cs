using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Activatable
{
    public Animator animator;
    override public void Switch()
    {
        if (isActivated)
        {
            isActivated = false;
            animator.SetBool("IsActivated", false);
        }
        else
        {
            isActivated = true;
            animator.SetBool("IsActivated", true);
        }
    }
}
