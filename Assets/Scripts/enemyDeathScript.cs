using UnityEngine;

public class enemyDeathScript : MonoBehaviour
{
    private float timeAlive = 0.0f;
    private float lifeTime = 20.0f;

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
        }
    }
}
