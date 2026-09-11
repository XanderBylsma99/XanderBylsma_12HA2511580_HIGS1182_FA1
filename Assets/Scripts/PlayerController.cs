using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;
    public Camera playerCamera;
    private Rigidbody rb;

    private void Start()
    {
        // Get the Rigidbody attached to this object 
        rb = GetComponent<Rigidbody>();
        Debug.Log("Player Controller Started");
    }
    private void Update()
    {
        HandleMovement();
        
    }
    // Handles all player movement inputs. 
    // Uses WASD and Mouse Movement.  
    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = (transform.forward * vertical) + (transform.right * horizontal);
        transform.position += movement * moveSpeed * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectible")
        {
            ScoreManager.scoreCount += 1;
        }
    }
}