using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatable : MonoBehaviour
{
    public bool isActivated = false;

    virtual public void Switch()
    {
        if(isActivated)
        {
            isActivated = false;
        }
        else
        {
            isActivated = true;
        }

    }

}
