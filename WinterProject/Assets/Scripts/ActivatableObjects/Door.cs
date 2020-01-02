using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Activatable
{
    public Animator animator;

    override public void Switch()
    {
        if (isActivated)
        {
            isActivated = false;
            animator.SetBool("IsActivated", false);
            GetComponent<BoxCollider>().isTrigger = false;
        }
        else
        {
            isActivated = true;
            animator.SetBool("IsActivated", true);
            GetComponent<BoxCollider>().isTrigger = true;
        }
    }
}
