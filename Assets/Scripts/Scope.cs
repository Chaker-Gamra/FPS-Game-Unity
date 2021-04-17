using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Scope : MonoBehaviour
{
    public Animator animator;
    public GameObject scopeOverlay;
    private bool isScoped = false;
    public Camera fpsCam;
    public Camera weaponsCam;
    InputAction scope;

    void Start()
    {
        scope = new InputAction("Scope", binding: "<mouse>/rightButton");

        scope.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Gun gun = FindObjectOfType<Gun>();
        if(gun.isReloading || gun.currentAmmo == 0)
        {
            OnUnscoped();
        }
        else
        {
            if (scope.triggered)
            {
                isScoped = !isScoped;
                
                if (isScoped)
                {
                    StartCoroutine(OnScoped());
                }
                else
                {
                    OnUnscoped();
                }
            }
        }

    }
    IEnumerator OnScoped()
    {
        animator.SetBool("isScoped", true);
        yield return new WaitForSeconds(0.25f);
        fpsCam.fieldOfView = 45;
        scopeOverlay.SetActive(true);
        //fpsCam.cullingMask = fpsCam.cullingMask & ~(1 << 11);
        weaponsCam.gameObject.SetActive(false);
    }
    void OnUnscoped()
    {
        animator.SetBool("isScoped", false);
        fpsCam.fieldOfView = 60;
        scopeOverlay.SetActive(false);
        //fpsCam.cullingMask = fpsCam.cullingMask | (1 << 11);
        weaponsCam.gameObject.SetActive(true);
    }
}
