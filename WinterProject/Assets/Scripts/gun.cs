using UnityEngine;

public class gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;

    public Camera playerCam;

   // public ParticleSystem muzzleFlash;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
               
    }

    void Shoot()
    {

      //The flash when we shoot
      //  muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

           Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
