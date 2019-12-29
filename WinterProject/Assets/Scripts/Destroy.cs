using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float TimetoDelete = 1f;
    private float countdown;
    void Start()
    {
        countdown = TimetoDelete;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0)
        {
            Destroy(gameObject);
        }
    }
}
