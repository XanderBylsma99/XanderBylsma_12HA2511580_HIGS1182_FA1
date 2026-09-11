using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    //This is for visual effects//
    public float rotateSpeed = 30f;


    void Update()
    {
        //This rotates the fuel case for visual effects//
        transform.Rotate(rotateSpeed * Time.deltaTime * Vector3.up);
    }
    
    
    // This Destroys gameObject on Collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            ScoreManager.scoreCount += 1;
            Debug.Log("Fuel Collected");
            GameManager.Instance.WinGame();
        }

   


}
}
