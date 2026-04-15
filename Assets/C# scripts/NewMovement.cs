using UnityEngine;
using UnityEngine.InputSystem;

public class NewMovement : MonoBehaviour
{
    public float speed = 5f;
    private CharacterController cc;
    private Vector2 moveInput;

    void Start() => cc = GetComponent<CharacterController>();

    void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        move = transform.TransformDirection(move) * speed;
        cc.Move(move * Time.deltaTime);
    }

    public void OnMove(InputValue value) => moveInput = value.Get<Vector2>();
}