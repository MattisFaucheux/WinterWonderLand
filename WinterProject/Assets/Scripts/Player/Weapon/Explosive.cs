using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public float radius = 5f;
    public float explosionForce = 700f;
    public float damage = 10f;
    public GameObject explosionEffect;
    protected bool hasExploded = false;

    public void Explode()
    {
        if(hasExploded)
        {
            return;
        }

        hasExploded = true;
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, radius);
            }

            Target target = nearbyObject.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            Explosive explosive = nearbyObject.transform.GetComponent<Explosive>();
            if (explosive != null)
            {
                explosive.Explode();
            }

        }

        StartCoroutine(Explosion());
    }

    IEnumerator Explosion()
    {
        GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
        GetComponent<MeshRenderer>().enabled = false;
        
        if(GetComponent<BoxCollider>())
        {
            GetComponent<BoxCollider>().enabled = false;
        }
        yield return new WaitForSeconds(1f);
        Destroy(explosion);

        Destroy(gameObject);
    }
}
