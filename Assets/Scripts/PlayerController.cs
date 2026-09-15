using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private float boostTimer;
    private bool boostActive = false;
    private bool boostCoolDownActive = false;
    private float boostCoolDownTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("PlayerController Start: Rigidbody component found.");
        boostTimer = 0f;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        //Debug.Log("Move Input: " + moveInput);
    }

    public void OnBoost(InputAction.CallbackContext context)
    {
        Debug.Log("Boost Activated");
        if (context.performed)
        {
            if (boostActive || boostCoolDownActive)
            {
                Debug.Log("Boost is already active or in cooldown. Cannot activate again.");
                return;
            }
            else
            {
                moveSpeed *= 1.75f;
                Debug.Log("Boost Activated: Move Speed is now " + moveSpeed);
                boostActive = true;
            }
        }
        //else if (context.canceled)
        //{
        //    moveSpeed /= 1.75f;
        //    Debug.Log("Boost Deactivated: Move Speed is now " + moveSpeed);
        //}
    }

    void Update()
    {
        Vector2 moveDirection = new Vector2(moveInput.x, moveInput.y);
        //rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);
        rb.linearVelocity = moveDirection * moveSpeed;

        if(boostActive)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= 1f)
            {
                moveSpeed /= 1.75f;
                Debug.Log("Boost Deactivated after 1 second: Move Speed is now " + moveSpeed);
                boostActive = false;
                boostTimer = 0f;
                boostCoolDownActive = true;
            }
        }
        if(boostCoolDownActive)
        {
            boostCoolDownTimer += Time.deltaTime;
            if (boostCoolDownTimer >= 4f)
            {
                boostCoolDownActive = false;
                boostCoolDownTimer = 0f;
                Debug.Log("Boost Cooldown Complete");
            }
        }


    }
}
