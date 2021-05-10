using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject impactEffect;
    private void OnCollisionEnter(Collision collision)
    {
        FindObjectOfType<AudioManager>().Play("Explosion");
        GameObject impact  = Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(impact, 2);
        Destroy(gameObject);
    }
}
