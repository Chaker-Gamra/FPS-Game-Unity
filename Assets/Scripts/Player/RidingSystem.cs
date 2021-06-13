using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class RidingSystem : MonoBehaviour
{
    public GameObject normalFPS;
    public GameObject robotFPS;

    public TextMeshProUGUI ridingMessage;
    InputAction ride;
    private void Start()
    {
        ride = new InputAction("Ride", binding: "Keyboard/F");
        ride.Enable();
    }
    private void OnTriggerEnter(Collider other)
    {
        ridingMessage.enabled = true;
        ridingMessage.text = "Press F To Ride The Robot";
    }
    private void OnTriggerStay(Collider other)
    {
        if (ride.triggered)
        {
            Ride();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        ridingMessage.enabled = false;
    }

    void Ride()
    {
        robotFPS.transform.position = transform.position;
        robotFPS.transform.rotation = transform.rotation;
        normalFPS.SetActive(false);
        robotFPS.SetActive(true);
        transform.gameObject.SetActive(false);
    }
}
