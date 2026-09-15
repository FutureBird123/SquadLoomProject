using UnityEngine;

public class enemyDeathScript : MonoBehaviour
{
    private void Start()
    {
        // Verify the collider is set up correctly
        Collider2D col = GetComponent<Collider2D>();
        if (col == null)
        {
            Debug.LogError("enemyDeathScript: No Collider2D found on " + gameObject.name);
        }
        else if (!col.isTrigger)
        {
            Debug.LogError("enemyDeathScript: Collider2D on " + gameObject.name + " is NOT set as a trigger!");
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogWarning("enemyDeathScript: No Rigidbody2D found on " + gameObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name + " | Tag: " + collision.gameObject.tag);

        if (collision.gameObject.CompareTag("playerProjectile") || collision.gameObject.CompareTag("player"))
        {
            Debug.Log("Enemy hit by player projectile");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
