using UnityEngine;

public class gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    public Camera playerCam;

    public GameObject flash;
    public GameObject muzzleFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
               
    }

    void Shoot()
    {

        //The flash when we shoot
        // muzzleFlash.Play();

        GameObject flashGO = Instantiate(muzzleFlash, flash.transform.position, Quaternion.LookRotation(flash.transform.localPosition));
        flashGO.GetComponent<ParticleSystem>().Play();
        Destroy(flashGO, 0.1f);

        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
        {
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
