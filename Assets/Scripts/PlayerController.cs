using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("PlayerController Start: Rigidbody component found.");
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log("Move Input: " + moveInput);
    }

    public void OnBoost(InputAction.CallbackContext context)
    {
        Debug.Log("Boost Activated");
        if (context.performed)
        {
            moveSpeed *= 2;
            Debug.Log("Boost Activated: Move Speed is now " + moveSpeed);
        }
        else if (context.canceled)
        {
            moveSpeed /= 2;
            Debug.Log("Boost Deactivated: Move Speed is now " + moveSpeed);
        }
    }

    void Update()
    {
        Vector2 moveDirection = new Vector2(moveInput.x, moveInput.y);
        //rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);
        rb.linearVelocity = moveDirection * moveSpeed;

    }
}
