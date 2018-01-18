using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform projectileSpawn;
    [SerializeField] private float speed;

    public void Shoot()
    {
        var bullet = (GameObject)Instantiate(
            projectile,
            Camera.main.transform.position,
            Camera.main.transform.rotation);
        
        bullet.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * 10;
        bullet.transform.SetParent(null, false);
        Destroy(bullet, 2.0f);
    }
}

