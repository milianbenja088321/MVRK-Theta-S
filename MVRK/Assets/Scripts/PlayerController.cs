using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NetworkedHealth myHealth = null;
    public float phealth;
    private float mHealth = 100;
    public bool isDead;

    private void Start()
    {
        phealth = mHealth;
        isDead = false;
    }

    void Update()
    {
        phealth = mHealth;
        //SetPlayerPosition();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "projectile")
        {
            Debug.Log("Hello Projectile ********************************************");
            TakeDamage((int)collision.gameObject.GetComponent<Projectile>().GetDamage());
        }
    }

    private void SetPlayerPosition()
    {
        GameObject head = GameObject.FindGameObjectWithTag("Head");
        GameObject saber = GameObject.FindGameObjectWithTag("RHand");


        if (head)
        {
            Debug.Log("Head not null");
            Transform headTransform = transform.Find("Player Head");
            headTransform.position = head.transform.position;
            headTransform.rotation = head.transform.rotation;
        }
        else
        {
            Debug.Log("head is null");
        }

        if (saber)
        {
            Transform saberTransform = transform.Find("Sword");
            saberTransform.position = saber.transform.position;
            saberTransform.rotation = saber.transform.rotation;
        }
        else
        {
            Debug.Log("saber is null");
        }
    }

    private void TakeDamage(int amount)
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
