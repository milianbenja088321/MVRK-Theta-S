using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightsaber : MonoBehaviour
{
    LineRenderer light;
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform endPos;

    // Use this for initialization
    void Start()
    {
        light = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        light.SetPosition(0, startPos.position);
        light.SetPosition(1, endPos.position);
    }
}
