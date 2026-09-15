using UnityEngine;

public class enemyDeathScript : MonoBehaviour
{
    private float timeAlive = 0.0f;
    private float lifeTime = 20.0f;
    private void Start()
    {
        //// Verify the collider is set up correctly
        //Collider2D col = GetComponent<Collider2D>();
        //if (col == null)
        //{
        //    Debug.LogError("enemyDeathScript: No Collider2D found on " + gameObject.name);
        //}
        //else if (!col.isTrigger)
        //{
        //    Debug.LogError("enemyDeathScript: Collider2D on " + gameObject.name + " is NOT set as a trigger!");
        //}

        //Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //if (rb == null)
        //{
        //    Debug.LogWarning("enemyDeathScript: No Rigidbody2D found on " + gameObject.name);
        //}
    }

    private void Update()
    {
        if (timeAlive > lifeTime)
        {
            Destroy(this.gameObject);
        }
        else
        {
            timeAlive += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("playerProjectile"))
        {
            Debug.Log("Enemy hit by player projectile");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy collided with another enemy");
            Destroy(gameObject);
            // Optionally, you can add logic here to handle what happens when enemies collide
        }
    }
}
