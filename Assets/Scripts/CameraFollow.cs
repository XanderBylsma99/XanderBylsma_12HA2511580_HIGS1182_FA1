using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3 (0, 5, -8);

    void LateUpdate()
    {
        if (target == null)
            return;

        //Keeps camera behind the player//
        transform.position = target.position + offset;
    }
}