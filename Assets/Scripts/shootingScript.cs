using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// A class which controlls player aiming and shooting
/// </summary>
public class ShootingController : MonoBehaviour
{
    public GameObject projectilePrefab = null;
    public Transform projectileHolder = null;

    public bool isPlayerControlled = false;
    public InputAction fireAction;

    public float fireRate = 0.05f;

    public float projectileSpread = 1.0f;

    // The last time this component was fired
    private float lastFired = Mathf.NegativeInfinity;

    public GameObject fireEffect;

    void OnEnable()
    {
        fireAction.Enable();
    }

    void OnDisable()
    {
        fireAction.Disable();
    }

    private void Update()
    {
        ProcessInput();
    }

    private void Start()
    {
        if (fireAction.bindings.Count == 0 && isPlayerControlled)
        {
            Debug.LogWarning("The Fire Input Action does not have a binding set but is set to be player controlled! Make sure that it has a binding or the shooting controller will not shoot!");
        }
    }


    void ProcessInput()
    {
        if (isPlayerControlled)
        {
            if (fireAction.bindings.Count == 0)
            {
                Debug.LogError("The Fire Input Action does not have a binding set! It must have a binding set in order to fire!");
            }
            if (fireAction.ReadValue<float>() >= 1)
            {
                Fire();
            }
        }
    }

    public void Fire()
    {
        // If the cooldown is over fire a projectile
        if ((Time.timeSinceLevelLoad - lastFired) > fireRate)
        {
            // Launches a projectile
            SpawnProjectile();

            if (fireEffect != null)
            {
                Instantiate(fireEffect, transform.position, transform.rotation, null);
            }

            // Restart the cooldown
            lastFired = Time.timeSinceLevelLoad;
        }
    }

    public void SpawnProjectile()
    {
        // Check that the prefab is valid
        if (projectilePrefab != null)
        {
            // Create the projectile
            GameObject projectileGameObject = Instantiate(projectilePrefab, transform.position, transform.rotation, null);

            // Account for spread
            Vector3 rotationEulerAngles = projectileGameObject.transform.rotation.eulerAngles;
            rotationEulerAngles.z += Random.Range(-projectileSpread, projectileSpread);
            projectileGameObject.transform.rotation = Quaternion.Euler(rotationEulerAngles);

            // Keep the heirarchy organized
            if (projectileHolder == null && GameObject.Find("ProjectileHolder") != null)
            {
                projectileHolder = GameObject.Find("ProjectileHolder").transform;
            }
            if (projectileHolder != null)
            {
                projectileGameObject.transform.SetParent(projectileHolder);
            }
        }
    }
}
