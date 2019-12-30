using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Target
{

    public int lightCharger = 5;
    public int mediumCharger = 5;
    public int heavyCharger = 5;
    public int grenade = 5;

    public int maxLightCharger = 5;
    public int maxMediumCharger = 5;
    public int maxHeavyCharger = 5;
    public int maxGrenade = 5;

    public override void Die()
    {
        enabled = false;

        foreach (Transform m_children in transform)
        {
            m_children.gameObject.SetActive(false);
        }
    }
}
