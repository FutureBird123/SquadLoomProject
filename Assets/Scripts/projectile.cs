using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float timeAlive = 0.0f;
    private float lifeTime = 5.0f;

    [Tooltip("The distance this projectile will move each second.")]
    public float projectileSpeed = 15.0f;

    [SerializeField] private bool player = false;

    private void Update()
    {
        MoveProjectile();
        if (timeAlive > lifeTime)
        {
            Destroy(this.gameObject);
        }
        else
        {
            timeAlive += Time.deltaTime;
        }
    }

    private void MoveProjectile()
    {
        // move the transform
        if (player)
        {
            transform.position = transform.position + transform.up * projectileSpeed * Time.deltaTime;
        }
        else
        {
            transform.position = transform.position - transform.up * projectileSpeed * Time.deltaTime;
        }
    }
}