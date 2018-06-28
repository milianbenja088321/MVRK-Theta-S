using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int mHealth;
	// Use this for initialization
	void Start () {
        mHealth = 100;
	}
	

    public void TakeDamage(int ammount)
    {
        mHealth -= ammount;

        if (mHealth <= 0)
            Debug.Log("Dead");
    }
}
