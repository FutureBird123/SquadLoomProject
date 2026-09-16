using TMPro;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectilePosition;
    public float movementSpeed=3f;
    public float attackDelay=2f;


    private float attacktimer;



    // Update is called once per frame
    void Update()
    {
        attacktimer += Time.deltaTime;

        if (attacktimer >= attackDelay)
        {
            Shoot();
            attacktimer = 0.0f;
        }

        //enemy movement code
        transform.Translate(Vector2.down * Time.deltaTime * movementSpeed);


    }

    void Shoot()
    {
        Instantiate(projectile, projectilePosition.position, projectilePosition.rotation);
    }
}
