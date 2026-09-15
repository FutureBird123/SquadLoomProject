using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectilePosition;

    private GameObject bullet;

    private float timer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 2.0f)
        {
            Shoot();
            timer = 0.0f;
        }

    }

    void Shoot()
    {
        Instantiate(projectile, projectilePosition.position, projectilePosition.rotation);
    }
}
