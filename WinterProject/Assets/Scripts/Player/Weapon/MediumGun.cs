using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumGun : gun
{
    override protected void Update()
    {

        if (isReloading)
        {
            return;
        }

        if (Input.GetKey(reload) && player.mediumCharger > 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

    }

    override protected IEnumerator Reload()
    {
        isReloading = true;
        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - 0.25f);
        currentAmmo = maxAmmo;
        player.mediumCharger -= 1;
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(0.25f);
        isReloading = false;

    }
}
