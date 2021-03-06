using UnityEngine.InputSystem;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform fpsCam;
    public float range = 20;
    public float impactForce = 150;

    public int fireRate = 10;
    private float nextTimeToFire = 0;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    InputAction shoot;

    void Start()
    {
        shoot = new InputAction("Shoot", binding: "<mouse>/leftButton");
        shoot.AddBinding("<Gamepad>/x");

        shoot.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        bool isShooting = shoot.ReadValue<float>() == 1;

        if (isShooting && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Fire();
        }
    }

    private void Fire()
    {
        AudioManager.instance.Play("Shoot");

        muzzleFlash.Play();
        
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.position, fpsCam.forward, out hit, range))
        {
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            Quaternion impactRotation = Quaternion.LookRotation(hit.normal);
            GameObject impact = Instantiate(impactEffect, hit.point, impactRotation);
            Destroy(impact, 5);
        }

    }
}
