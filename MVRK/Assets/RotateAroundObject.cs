using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundObject : MonoBehaviour
{

    [SerializeField] Transform centerPoint;

    public float xSpread = 10, 
        zSpread = 10,
        yOffset = 3.5f,
        rotSpeed = .5f, 
        timer = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * rotSpeed;

        float x = -Mathf.Cos(timer) * xSpread;
        float z = Mathf.Sin(timer) * zSpread;

        Vector3 pos = new Vector3(x, yOffset, z);

        transform.position = pos + centerPoint.position;
    }
}
