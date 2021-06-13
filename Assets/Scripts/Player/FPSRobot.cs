using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;
public class FPSRobot : MonoBehaviour
{
    InputAction exit;
    public TextMeshProUGUI ridingMessage;

    public GameObject cube;
    public GameObject normalFPS;

    private void OnEnable()
    {
        exit = new InputAction("Exit", binding: "<Keyboard>/E");
        exit.Enable();

        ridingMessage.enabled = true;
        ridingMessage.text = "Press E To Exit";
    }
    // Update is called once per frame
    void Update()
    {
        if (exit.triggered)
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
        cube.transform.position = normalFPS.transform.position;
        cube.SetActive(true);
    }
}
