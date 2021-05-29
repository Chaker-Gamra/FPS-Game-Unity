using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    float xRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = 0;
        float mouseY = 0;

        if(Mouse.current != null)
        {
            mouseX = Mouse.current.delta.ReadValue().x;
            mouseY = Mouse.current.delta.ReadValue().y;
        }

        if (Gamepad.current != null)
        {
            mouseX = Gamepad.current.rightStick.ReadValue().x;
            mouseY = Gamepad.current.rightStick.ReadValue().y;
        }

        //float mouseX = Input.GetAxis("Mouse X");
        //float mouseY = Input.GetAxis("Mouse Y");

        mouseX *= mouseSensitivity;
        mouseY *= mouseSensitivity;

        xRotation -= mouseY * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -80, 80);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX * Time.deltaTime);
    }
}
