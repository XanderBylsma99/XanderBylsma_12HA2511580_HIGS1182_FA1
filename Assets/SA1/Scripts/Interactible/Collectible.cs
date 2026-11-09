using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("Visual Effects")]
    public float rotateSpeed = 30f;

    [Header("Audio")]
    public AudioClip collectSound;

    private void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(
                    collectSound,
                    transform.position
                );
            }

            if (CollectibleManager.Instance != null)
            {
                CollectibleManager.Instance.CollectItem();
            }

            Destroy(gameObject);
        }
    }
}