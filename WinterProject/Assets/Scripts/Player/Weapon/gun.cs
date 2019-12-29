using UnityEngine;
using System.Collections;




public class gun : MonoBehaviour
{
    public Player player;

    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    public int maxAmmo = 10;
    protected int currentAmmo;
    public float reloadTime = 1f;
    protected bool isReloading = false;
    public Animator animator;

    public KeyCode reload;

    public Camera playerCam;

    public GameObject flash;
    public GameObject muzzleFlash;
    public GameObject impactEffect;

    protected float nextTimeToFire = 0f;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);

    }

    virtual protected void Update()
    {

        if(isReloading)
        {
            return;
        }

        if(Input.GetKey(reload))
        {
            StartCoroutine(Reload());
            return;
        }

        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
               
    }

    virtual protected IEnumerator Reload()
    {
        isReloading = true;
        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - 0.25f);
        currentAmmo = maxAmmo;
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(0.25f);
        isReloading = false;

    }
    protected void Shoot()
    {
        currentAmmo--;

        GameObject flashGO = Instantiate(muzzleFlash, flash.transform.position, flash.transform.rotation);
        flashGO.GetComponent<ParticleSystem>().Play();
        Destroy(flashGO, 0.1f);

        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
        {

            Explosive explosive = hit.transform.GetComponent<Explosive>();
            if(explosive != null)
            {
                explosive.Explode();
            }

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }



            //Impact effect
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            Destroy(impactGO, 0.5f);
        }
    }
}
