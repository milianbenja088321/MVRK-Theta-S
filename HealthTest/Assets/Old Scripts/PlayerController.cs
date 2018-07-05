using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Health myHealth = null;
    [SerializeField] private int lastDamageAmount = 0;
    public bool isDead;

    private void Start()
    {
        isDead = false;
        myHealth = this.GetComponent<Health>();
    }

    void Update()
    {
        Debug.Log("Update():: " + lastDamageAmount);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "projectile")
        {
            Debug.Log("Hello Projectile ********************************************");
            lastDamageAmount = (int)collision.gameObject.GetComponent<Projectile>().GetDamage();
            myHealth.TakeDamage(collision.gameObject.GetComponent<Projectile>().GetDamage());
        }
    }

    private void SetPlayerPosition()
    {
        GameObject head = GameObject.FindGameObjectWithTag("head");
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
            //  Debug.Log("head is null");
        }

        if (saber)
        {
            Transform saberTransform = transform.Find("Sword");
            saberTransform.position = saber.transform.position;
            saberTransform.rotation = saber.transform.rotation;
        }
        else
        {
            // Debug.Log("saber is null");
        }
    }
}
