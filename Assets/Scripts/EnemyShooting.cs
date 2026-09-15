using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectilePosition;
    public float movementSpeed=2f;
    public float attackSpeed=2f;

    private GameObject bullet;

    private float timer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= attackSpeed)
        {
            Shoot();
            timer = 0.0f;
        }

        //enemy movement code
        transform.Translate(Vector2.down * Time.deltaTime * movementSpeed);

    }

    void Shoot()
    {
        Instantiate(projectile, projectilePosition.position, projectilePosition.rotation);
    }
}
