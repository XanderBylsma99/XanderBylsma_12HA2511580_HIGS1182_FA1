//using UnityEngine;
//using System.Collections;
//[RequireComponent(typeof(LineRenderer))]


//public class RaycastShoot : MonoBehaviour
//{
//    public int gunDamage = 1;
//    public float fireRate = .25f;
//    public float weaponRange = 50f;
//    public float hitForce = 100f;
//    public Transform gunEnd;
//    public Camera Camera;
//    private WaitForSeconds shotDuration = new(0.7f);
//    private LineRenderer laserLine;
//    private float nextFire;

//    void Start()
//    {
//        laserLine = GetComponent<LineRenderer>();
//        Camera = GetComponent<Camera>();
//    }

//    void Update()
//    {
//       if (Input.GetButtonDown ("Fire1") && Time.time > nextFire)
//            Debug.Log("Shot Fired");
//        {
//            nextFire = Time.time + fireRate;
//            StartCoroutine(ShotEffect());
//            Vector3 rayOrigin = Camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

//            laserLine.SetPosition(0, gunEnd.position);

//            if (Physics.Raycast(rayOrigin,Camera.transform.forward, out RaycastHit hit, weaponRange))
//            {
//                laserLine.SetPosition(1, hit.point);
//            }
//            else
//            {
//                laserLine.SetPosition(1, rayOrigin + (Camera.transform.forward * weaponRange));
//            }
//        }
//    }

//    private IEnumerator ShotEffect()
//    {
//        laserLine.enabled = true;
//        yield return shotDuration;
//        laserLine.enabled = false;
//    }
//}
