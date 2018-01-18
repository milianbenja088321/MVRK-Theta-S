using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnLoadVR : MonoBehaviour 
{
    [SerializeField] private bool vrActive;
    [SerializeField] private Camera arCam;
    [SerializeField] private Camera vrCam;
    [SerializeField] private GameObject arCanvas;
    [SerializeField] private GameObject gameArea;
    // Use this for initialization
    private void Start () 
    {
        if (DDOL.Instance.GetVRComp() == true)
        {
            arCam.gameObject.SetActive(false);
            arCanvas.SetActive(false);
            gameArea.transform.SetParent(null);
        }
        else
        {
            vrCam.gameObject.SetActive(false);

        }
        
	}
	
}
