using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShooting : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject Fire;
    public GameObject HitPoint;
   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shooting();
        }
    }
    public void Shooting()
    {
        RaycastHit hit;
        if (Physics.Raycast(FirePoint.position, transform.TransformDirection(Vector3.forward), out hit, 100))
        {
            Debug.DrawRay(FirePoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);

           GameObject a = Instantiate(Fire , FirePoint.position , Quaternion.identity);
           GameObject b = Instantiate(HitPoint , hit.point , Quaternion.identity);

            Destroy(a, 1);
            Destroy(b, 1);

            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            
            if(enemy != null)
            {
                enemy.Damage(1);
            }

            AsteroidHealth asteroid = hit.transform.GetComponent<AsteroidHealth>();

            if (asteroid != null)
            {
                asteroid.Damage(1);
            }
        }
    }
}