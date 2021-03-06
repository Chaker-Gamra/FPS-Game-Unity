using UnityEngine.InputSystem;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    InputAction switching;
    public int selectedWeapon = 0;
    void Start()
    {
        switching = new InputAction("Scroll", binding: "<Mouse>/scroll");
        switching.AddBinding("<Gamepad>/Dpad");
        switching.Enable();

        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        float scrollValue = switching.ReadValue<Vector2>().y;

        int previousSelected = selectedWeapon;
        if(scrollValue > 0)
        {
            selectedWeapon++;
            if (selectedWeapon == 3)
                selectedWeapon = 0;
        }else if (scrollValue < 0)
        {
            selectedWeapon--;
            if (selectedWeapon == -1)
                selectedWeapon = 2;
        }
        if(previousSelected != selectedWeapon)
            SelectWeapon();

    }

    private void SelectWeapon()
    {
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(false);
        }
        transform.GetChild(selectedWeapon).gameObject.SetActive(true);
    }
}
