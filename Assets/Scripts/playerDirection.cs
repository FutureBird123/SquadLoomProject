using UnityEngine;
using UnityEngine.InputSystem;  

public class playerDirection : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        float angleRad= Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad -90;

        transform.rotation = Quaternion.Euler(0, 0, angleDeg);
    }

}
