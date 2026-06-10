using UnityEngine;
using UnityEngine.InputSystem;

public class NewMovement : MonoBehaviour
{
    private CharacterController cc;
    private Vector2 moveInput;

    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float runSpeed = 8f;

    [Header("Stamina")]
    [SerializeField] float maxStamina = 100f;
    [SerializeField] float regenRate = 20f;
    [SerializeField] float drainRate = 30f;

    [Header("Gravity")]
    [SerializeField] float gravity = -20f;

    private float currentStamina;
    private bool isRunning;
    private Vector3 verticalVelocity;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        currentStamina = maxStamina;
    }

    void Update()
    {
        Stamina();

        // Movement
        float currentSpeed = isRunning ? runSpeed : walkSpeed;
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        move = transform.TransformDirection(move) * currentSpeed;

        // Gravity
        if (cc.isGrounded && verticalVelocity.y < 0)
            verticalVelocity.y = -2f; // small downward force
        else
            verticalVelocity.y += gravity * Time.deltaTime;

        move += verticalVelocity;

        cc.Move(move * Time.deltaTime);
    }

    void Stamina()
    {
        isRunning = Input.GetKey(KeyCode.LeftShift) && currentStamina > 0f;
        if (isRunning)
            currentStamina -= drainRate * Time.deltaTime;
        else if (currentStamina < maxStamina)
            currentStamina += regenRate * Time.deltaTime;

        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
    }

    public void OnMove(InputValue value) => moveInput = value.Get<Vector2>();
}