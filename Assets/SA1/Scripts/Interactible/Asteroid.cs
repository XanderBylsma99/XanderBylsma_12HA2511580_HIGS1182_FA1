using UnityEngine;

public class Asteroid : MonoBehaviour
{
    //Rotation speed for effects//
    
    public float rotateSpeed = 30f;

  
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("GameOver Ship hit an asteroid");

            GameManager.Instance.GameOver();
        }
    }


}
