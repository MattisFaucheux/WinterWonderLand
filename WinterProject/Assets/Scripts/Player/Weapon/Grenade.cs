﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Explosive
{

    public float delay = 3f;
    private float countdown;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if(countdown <= 0 && !hasExploded) 
        {
            Explode();
        }
    }
}
