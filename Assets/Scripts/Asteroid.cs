using UnityEngine;

public class Asteroid : MonoBehaviour
{
    //Rotation speed for effects//
    public float health = 1f;
    
    public float rotateSpeed = 5f;

  
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }

    public void TakeDamage(float amount)
    {
        

        
        health -= amount;
        if (health <= 0f)
        {
            Explode();
        }
    }

    void Explode()
    {
        Destroy(gameObject);
    }

    //Ends Game if player collides with asteroid//
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("GameOver Ship hit an asteroid");
      
            GameManager.Instance.GameOver();
        }
    }

    //Destroy asteroid if bullet collides with asteroid//
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Debug.Log("Asteroid is dead");
        }
    }
}
