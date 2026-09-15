using UnityEngine;

public class damageScript : MonoBehaviour
{
    private bool isDeactivating = false;
    private float deactivateTimer = 0f;
    private float deactivateDuration = 3f;

    void Start()
    {

    }

    void Update()
    {
        if (isDeactivating)
        {
            deactivateTimer += Time.deltaTime;
            if (deactivateTimer >= deactivateDuration)
            {
                isDeactivating = false;
                gameObject.SetActive(true);
                deactivateTimer = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemyProjectile"))
        {
            Debug.Log("Hit by enemy projectile");
            if (!isDeactivating)
            {
                isDeactivating = true;
                InvokeRepeating("changeState", 0f, 0.2f);
                Invoke("StopFlickering", deactivateDuration);
                Destroy(collision.gameObject);
            }
        }
    }

    void changeState()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    void StopFlickering()
    {
        CancelInvoke("changeState");
        gameObject.SetActive(true);
        isDeactivating = false;
    }
}
