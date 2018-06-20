using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {

        //if (photonView.isMine)
        //{
        //    Debug.Log("SetPlayerPosition being called");
        //    SetPlayerPosition();
        //}

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "projectile")
        {
            Debug.Log("Hello Projectile ********************************************");
        }
    }

    private void SetPlayerPosition()
    {
        GameObject head = GameObject.FindGameObjectWithTag("Head");
        GameObject saber = GameObject.FindGameObjectWithTag("RHand");

        if (head)
        {
            Transform headTransform = transform.Find("Player Head");
            headTransform.position = head.transform.position;
            headTransform.rotation = head.transform.rotation;
        }

        if (saber)
        {
            Transform saberTransform = transform.Find("Sword");
            saberTransform.position = saber.transform.position;
            saberTransform.rotation = saber.transform.rotation;
        }
    }
}
