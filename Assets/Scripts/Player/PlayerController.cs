using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 10f;
    public float rotationSpeed = 150f;

    private Rigidbody rb;

    private float horizontal;
    private float vertical;
    private float mouseX;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.freezeRotation = true;
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        mouseX = Input.GetAxis("Mouse X");
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        Vector3 moveDirection =
            (transform.forward * vertical) +
            (transform.right * horizontal);

        moveDirection = moveDirection.normalized;

        Vector3 targetPosition =
            rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(targetPosition);
    }

    private void HandleRotation()
    {
        Quaternion deltaRotation =
            Quaternion.Euler(0f,
                             mouseX * rotationSpeed * Time.fixedDeltaTime,
                             0f);

        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
