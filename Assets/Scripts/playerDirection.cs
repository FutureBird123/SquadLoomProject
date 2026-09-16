using UnityEngine;
using UnityEngine.InputSystem;  

public class playerDirection : MonoBehaviour
{

    public InputAction lookAction;
    private Vector2 lookInput;

    void OnEnable()
    {
        lookAction.Enable();
    }

    void OnDisable()
    {
        lookAction.Disable();
    }

    void Update()
    {
        lookInput = lookAction.ReadValue<Vector2>();

        // Only rotate if there's meaningful input (deadzone)
        if (lookInput.magnitude > 0.1f)
        {
            float angleRad = Mathf.Atan2(lookInput.y, lookInput.x);
            float angleDeg = (180 / Mathf.PI) * angleRad - 90;

            transform.rotation = Quaternion.Euler(0, 0, angleDeg);
        }
    }

}
