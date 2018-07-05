using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour 
{
    TouchSpawn touch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            Destroy(touch.gameObject);
            Debug.Log("blah");
            //Instantiate(theObject,
            // new Vector3(0,0, 1),
            //Quaternion.identity);
        }

        //if (thro)
            //isThrown = false;
    }
}
