using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float mouseSen = 1f;
    public float rotX = 0f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mx = Input.GetAxis(axisName: "Mouse X") * mouseSen;
        float my = Input.GetAxis(axisName: "Mouse Y") - mouseSen;

        transform.Rotate(xAngle: 0f, mx, zAngle: 0f);

        rotX -= my;
        rotX = Mathf.Clamp(rotX, min: -80f, max: 80f);

        //Camera.main.transform.localEulerAngles = new Vector3(rotX, y: 0f, z: 0f);
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis(axisName: "Horizontal");
        float y = Input.GetAxis(axisName: "Vertical");

        Vector3 dir = (transform.right * x + transform.forward * y).normalized;
        rb.MovePosition(rb.position + dir * moveSpeed * Time.fixedDeltaTime);
    }
}
