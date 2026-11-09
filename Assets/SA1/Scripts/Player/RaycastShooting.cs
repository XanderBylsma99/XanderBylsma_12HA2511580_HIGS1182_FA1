using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShooting : MonoBehaviour
{
    [Header("Effects")]
    public Transform FirePoint;
    public GameObject Fire;
    public GameObject HitPoint;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip explosionSound;

    [Header("Settings")]
    public float range = 100f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shooting();
        }
    }

    public void Shooting()
    {
        RaycastHit hit;

        if (Physics.Raycast(
            FirePoint.position,
            transform.forward,
            out hit,
            range))
        {
            Debug.DrawRay(
                FirePoint.position,
                transform.forward * hit.distance,
                Color.red,
                2f);

            // Muzzle Effect
            GameObject fireEffect =
                Instantiate(Fire,
                FirePoint.position,
                FirePoint.rotation);

            // Impact Effect
            GameObject hitEffect =
                Instantiate(HitPoint,
                hit.point,
                Quaternion.identity);

            Destroy(fireEffect, 1f);
            Destroy(hitEffect, 1f);

            // Play explosion sound on impact
            if (audioSource != null && explosionSound != null)
            {
                audioSource.PlayOneShot(explosionSound);
            }

            // Enemy Damage
            EnemyHealth enemy =
                hit.transform.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.Damage(1);
            }

            // Asteroid Damage
            AsteroidHealth asteroid =
                hit.transform.GetComponent<AsteroidHealth>();

            if (asteroid != null)
            {
                asteroid.Damage(1);
            }

            Debug.Log("Hit: " + hit.collider.name);
        }
    }
}