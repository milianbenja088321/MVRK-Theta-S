using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkedHealth : NetworkBehaviour
{
    private const int mMaxHealth = 100;

    
    [SyncVar]
    public int mHealth = mMaxHealth;
    
   public void TakeDamage(int amount)
    {
        // if (!isServer) return;
        Debug.Log("TakeDamage::()");

        mHealth -= amount;

        if (mHealth <= 0)
        {
            mHealth = 0;
            Debug.Log("Dead");
       }

    }

    private void OnChangeHealth(int _currentHealth)
    {
        Debug.Log("OnChangeHealth()::");
    }
}
