using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour 
{	
	// Update is called once per frame
	void Update () 
    {
		this.transform.Rotate(0, Input.acceleration.x * 20, 0);
	}
}
