using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Health myHealth = null;

    private void Start()
    {
        myHealth = this.GetComponent<Health>();
    }
    void Update()
    {
        SetPlayerPosition();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "projectile")
        {
            Debug.Log("Hello Projectile ********************************************");
            myHealth.TakeDamage(collision.gameObject.GetComponent<Projectile>().GetDamage());
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
}
