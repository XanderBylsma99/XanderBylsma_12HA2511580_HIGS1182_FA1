using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 2;
    
 

    void Start()
    {
       
    }


    public void Damage(int damage)
    {  
        health -= damage;

        if(health <= 0 )
        {
           
            Destroy(this.gameObject);
            Debug.Log("Enemy Destroyed");
           
        }
    }
}
