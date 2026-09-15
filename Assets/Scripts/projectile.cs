using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class to make projectiles move
/// </summary>
public class Projectile : MonoBehaviour
{
    private float timeAlive = 0.0f;
    private float lifeTime = 5.0f;

    [Tooltip("The distance this projectile will move each second.")]
    public float projectileSpeed = 3.0f;

    [SerializeField] private bool player = false;

    /// <summary>
    /// Description:
    /// Standard Unity function called once per frame
    /// Inputs: 
    /// none
    /// Returns: 
    /// void (no return)
    /// </summary>
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

    /// <summary>
    /// Description:
    /// Move the projectile in the direction it is heading
    /// Inputs: 
    /// none
    /// Returns: 
    /// void (no return)
    /// </summary>
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