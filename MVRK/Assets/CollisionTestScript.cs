using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTestScript : MonoBehaviour
{
    [SerializeField] int mHealth;
    public bool isDead;

    private void Start()
    {
        mHealth = 100;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "projectile")
        {
            TakeDamage(5);
        }
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("TakeDamage()::");

        mHealth -= amount;
        Debug.Log("Health:: " + mHealth); 
        if (mHealth <= 0)
        {
            mHealth = 0;
            isDead = true;
        }
    }
}
