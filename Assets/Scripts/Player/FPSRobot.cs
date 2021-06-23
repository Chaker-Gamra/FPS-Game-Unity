using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FPSRobot : MonoBehaviour
{
    InputAction exit;
    public TextMeshProUGUI ridingMessage;

    public GameObject cube;
    public GameObject normalFPS;

    public Button exitButton;

    private void OnEnable()
    {
        exit = new InputAction("Exit", binding: "<Keyboard>/E");
        exit.Enable();

        ridingMessage.enabled = true;
        ridingMessage.text = "Press E To Exit";

        exitButton.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (exit.triggered)
        {
            ExitRobot();
        }*/

        if (CrossPlatformInputManager.GetButtonDown("Exit"))
        {
            ExitRobot();
        }
    }

    void ExitRobot()
    {
        normalFPS.transform.position = transform.position;
        normalFPS.transform.rotation = transform.rotation;
        normalFPS.SetActive(true);
        gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        cube.transform.position = normalFPS.transform.position;
        cube.SetActive(true);
    }
}
