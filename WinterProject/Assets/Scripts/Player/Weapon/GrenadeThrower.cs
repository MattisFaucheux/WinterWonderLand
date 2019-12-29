using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{

    public float throwForce = 20f;
    public GameObject grenadePrefab;
    public GameObject grenadeFire;

    public Player player;

    public float reloadTime = 4f;
    private float countdown;
    private bool throwed = false;

    public KeyCode input;

    // Update is called once per frame
    void Update()
    {
        if (throwed)
        {
            countdown -= Time.deltaTime;
            if(countdown <= 0)
            {
                throwed = false;
            }
        }

        if (Input.GetKey(input) && !throwed && player.grenade > 0)
        {
            ThrowGrenade();
        }

        
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, grenadeFire.transform.position, grenadeFire.transform.rotation);
        player.grenade -= 1;
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(grenadeFire.transform.forward * throwForce, ForceMode.VelocityChange);

        throwed = true;
        countdown = reloadTime;

    }
}
