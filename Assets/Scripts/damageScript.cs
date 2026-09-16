using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class damageScript : MonoBehaviour
{
    private bool isDeactivating = false;
    private float deactivateTimer = 0f;
    private float deactivateDuration = 3f;
    private bool invincible = false;
    private int health = 3;
    private bool shieldActive = false;

    private float sheildTimer = 0f;
    private bool shieldCooldownActive = false;

    public GameObject health1;
    public GameObject health2;
    public GameObject health3;
    public GameObject shield;

    //public GameObject shieldText;
    public GameObject playerSheildButton;
    public GameObject playerAltShieldButton;

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

        if (health <= 0)
        {
            Debug.Log("Player has died");
            Destroy(gameObject);
            SceneManager.LoadScene(2);
            // Handle player death (e.g., reload scene, show game over screen, etc.)
        }

        if (shieldActive)
        {
            sheildTimer += Time.deltaTime;
            if (sheildTimer >= 1.5f)
            {
                shieldActive = false;
                shield.SetActive(false);
                sheildTimer = 0f;
                Debug.Log("Shield deactivated");
                shieldCooldownActive = true;
                invincible = false;
            }
        }
        if(shieldCooldownActive)
        {
            sheildTimer += Time.deltaTime;
            if (sheildTimer >= 5f)
            {
                shieldCooldownActive = false;
                sheildTimer = 0f;
                //shieldText.SetActive(true);
                playerSheildButton.SetActive(true);
                playerAltShieldButton.SetActive(true);
                Debug.Log("Shield cooldown ended");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("enemyProjectile") || collision.gameObject.CompareTag("enemy")) && !invincible)
        {
            Debug.Log("Hit by enemy projectile");
            if (!isDeactivating)
            {
                isDeactivating = true;
                InvokeRepeating("changeState", 0f, 0.2f);
                Invoke("StopFlickering", deactivateDuration);
                Destroy(collision.gameObject);
                invincible = true;
                Debug.Log("Player is now invincible ");
                health--;
                if (health == 2)
                {
                    health3.SetActive(false);
                }
                else if (health == 1)
                {
                    health2.SetActive(false);
                }
                else if (health <= 0)
                {
                    health1.SetActive(false);
                }
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
        invincible = false;
        Debug.Log("Player is no longer invincible");
        isDeactivating = false;
    }

    public void ActivateShield(InputAction.CallbackContext context)
    {
        if(context.performed && !shieldActive && !shieldCooldownActive)
        {
            shield.SetActive(true);
            shieldActive = true;
            invincible = true;
            Debug.Log("Shield activated");
            //shieldText.SetActive(false);
            playerSheildButton.SetActive(false);
            playerAltShieldButton.SetActive(false);
        }
    }
}
