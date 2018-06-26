using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCameraScript : MonoBehaviour {

    [SerializeField] Camera arCam = null;


	// Update is called once per frame
	void Update ()
    {
        if (arCam != null)
            Debug.Log(arCam.transform.position.ToString());
        else
            Debug.Log("No camera detected");

	}
}
