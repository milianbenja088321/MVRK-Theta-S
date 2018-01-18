using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchSpawn : MonoBehaviour 
{
    [SerializeField] private Vector3 startPos; //mouse slide movement start pos
    [SerializeField] private Vector3 endPos; //mouse slide movement end pos
    [SerializeField] private float zDistance = 30.0f;//z distance
    [SerializeField] private bool isThrown;

    private Vector3 ObjStart;

    void Awake()
    {
       // ObjStart = this.transform.position;
        isThrown = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            transform.position = ObjStart;
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            isThrown = false;
        }

    }

    void Update()
    {
        if (isThrown)
        {
            Debug.Log("Returnin!!!");
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse button clicked0");
            //get start mouse position
            Vector3 mousePos = Input.mousePosition * -1.0f;
            mousePos.z = zDistance; //add z distance

            startPos = Camera.main.ScreenToWorldPoint(mousePos);

            //Print start Pos for debugging
            Debug.Log(startPos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            //get release mouse position
            Vector3 mousePos = Input.mousePosition * -1.0f;
            mousePos.z = zDistance; //add z distance

            // convert mouse position to world position
            endPos = Camera.main.ScreenToWorldPoint(mousePos);
            endPos.z = Camera.main.nearClipPlane; //removing this breaks stuff,no idea why though

            //Print start Pos for debugging
            Debug.Log(endPos);

            Vector3 throwDir = (startPos - endPos).normalized;//get throw direction based on start and end pos

            this.GetComponent<Rigidbody>().AddForce(throwDir * (startPos - endPos).sqrMagnitude);//add force to throw direction*magnitude

            isThrown = true;
        }

    }
}
