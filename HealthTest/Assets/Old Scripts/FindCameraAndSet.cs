using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FindCameraAndSet : MonoBehaviour
{

    private Camera arCam = null;

    // Use this for initialization
    void Start()
    {
        arCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // check the scene to make sure we arent the vr player
        if (SceneManager.GetActiveScene().name== "AR Scene")
        {
            //check the current view, if its yours set the position
                SetPosition();
        }
    }

    private void SetPosition()
    {
        if(arCam != null)
        {
            Debug.Log("setting position");
            //Debug.Log(arCam.transform.position.ToString());
            // create an instance of the object to reference in this case
            // i am using a capsule to represent where the ARCamera is in
            // 3d space
            GameObject arPlayer = GameObject.FindGameObjectWithTag("ARPlayer");

            // set the arPlayers (capsule GameObject in unity) position and rotation
            arPlayer.transform.position = arCam.transform.position;
            arPlayer.transform.rotation = arCam.transform.rotation;
        }
    }
}
