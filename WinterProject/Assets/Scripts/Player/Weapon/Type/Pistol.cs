using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : LightGun
{

    protected bool isShooting = false;

    override protected void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);

        isShooting = false;
        animator.SetBool("Shooting", false);

    }

    override protected void Update()
    {
        if (isReloading || isShooting)
        {
            return;
        }

        if (Input.GetKey(reload))
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            StartCoroutine(Shooting());
        }

    }

    protected IEnumerator Shooting()
    {
        isShooting = true;
        animator.SetBool("Shooting", true);
        Shoot();
        yield return new WaitForSeconds(0.37f/1.3f);
        animator.SetBool("Shooting", false);
        isShooting = false;
    }

    override protected void Shoot()
    {
        currentAmmo--;
        GameObject flashGO = Instantiate(muzzleFlash, flash.transform.position, flash.transform.rotation);
        flashGO.GetComponent<ParticleSystem>().Play();
        Destroy(flashGO, 0.1f);

        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
        {

            Explosive explosive = hit.transform.GetComponent<Explosive>();
            if (explosive != null)
            {
                explosive.Explode();
            }

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                Player pl = hit.transform.GetComponent<Player>();
                if (pl == null)
                {
                    target.TakeDamage(damage);
                }
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }



            //Impact effect
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            Destroy(impactGO, 0.5f);
        }
    }
}
