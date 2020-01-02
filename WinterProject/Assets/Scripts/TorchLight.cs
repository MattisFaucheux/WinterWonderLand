using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour
{
    public KeyCode activate;
    public bool isActivated = true;

    private void Update()
    {
        if(Input.GetKeyDown(activate))
        {
            if(isActivated)
            {
                GetComponent<Light>().enabled = false;
                isActivated = false;
            }
            else
            {
                GetComponent<Light>().enabled = true;
                isActivated = true;
            }
        }
    }
}
