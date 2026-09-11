using UnityEngine;

public class GunShooter : MonoBehaviour
{
    public Rigidbody BulletPrefab;
    public float force = 1000f;
    public Transform muzzle;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody b = Instantiate(BulletPrefab, muzzle.position, muzzle.rotation); //shoots with bullet prefab not raycast because i just could not manage to sort out the raycasting before submision date
            b.AddForce(muzzle.forward * force);
            Destroy(b.gameObject, t: 1.2f);
        }
    }

    
}
