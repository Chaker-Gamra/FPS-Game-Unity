using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class RidingSystem : MonoBehaviour
{
    public GameObject normalFPS;
    public GameObject robotFPS;

    public TextMeshProUGUI ridingMessage;
    InputAction ride;

    public Button rideButton;
    private void Start()
    {
        ride = new InputAction("Ride", binding: "Keyboard/F");
        ride.Enable();
        rideButton.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        ridingMessage.enabled = true;
        ridingMessage.text = "Press F To Ride The Robot";
        rideButton.gameObject.SetActive(true);
    }
    private void OnTriggerStay(Collider other)
    {
        /*if (ride.triggered)
        {
            Ride();
        }
        */
        if (CrossPlatformInputManager.GetButtonDown("Ride"))
            Ride();
    }
    private void OnTriggerExit(Collider other)
    {
        ridingMessage.enabled = false;
        rideButton.gameObject.SetActive(false);
    }

    void Ride()
    {
        robotFPS.transform.position = transform.position;
        robotFPS.transform.rotation = transform.rotation;
        normalFPS.SetActive(false);
        robotFPS.SetActive(true);
        transform.gameObject.SetActive(false);
        rideButton.gameObject.SetActive(false);
    }
}
