using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 15;
    private Vector3 move;

    public float gravity = -10f;
    public float jumpHeight = 2;
    private Vector3 velocity;

    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;

    InputAction movement;
    InputAction jump;

    void Start()
    {
        jump = new InputAction("Jump", binding: "<keyboard>/space");
        jump.AddBinding("<Gamepad>/a");

        movement = new InputAction("PlayerMovement", binding: "<Gamepad>/leftStick");
        movement.AddCompositeBinding("Dpad")
            .With("Up", "<keyboard>/w")
            .With("Up", "<keyboard>/upArrow")
            .With("Down", "<keyboard>/s")
            .With("Down", "<keyboard>/downArrow")
            .With("Left", "<keyboard>/a")
            .With("Left", "<keyboard>/letfArrow")
            .With("Right", "<keyboard>/d")
            .With("Right", "<keyboard>/rightArrow");

        movement.Enable();
        jump.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");
        float x = movement.ReadValue<Vector2>().x;
        float z = movement.ReadValue<Vector2>().y;

        move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.3f, groundLayer);

        if (isGrounded && velocity.y < 0)
            velocity.y = -1f;

        if (isGrounded)
        {
            if (Mathf.Approximately(jump.ReadValue<float>(), 1))
            {
                Jump();
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
        
        controller.Move(velocity * Time.deltaTime);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * 2 * -gravity);
    }
}
