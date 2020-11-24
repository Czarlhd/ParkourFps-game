using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    private float nextTimeToFire = 0f;

    public Camera FPScam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1")&& Time.time>=nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            shoot();
        }
    }

    void shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;

        if(Physics.Raycast(FPScam.transform.position, FPScam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);

            Enemy target = hit.transform.GetComponent<Enemy>();

            if(target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impact=Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 1f);
        }
    }

}
