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

    public Camera playerCam;

    public override void Die()
    {
        enabled = false;

        foreach (Transform m_children in transform)
        {
            if (m_children.gameObject.tag != "MainCamera")
            {
                m_children.gameObject.SetActive(false);
            }

        }

        foreach (Transform n_children in playerCam.transform)
        {
            n_children.gameObject.SetActive(false);
        }

        playerCam.GetComponent<MouseLook>().enabled = false;
    }

    override public void TakeDamage(float amount)
    {

        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

}
