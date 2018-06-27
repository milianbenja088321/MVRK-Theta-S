using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealthShooting : MonoBehaviour
{
    [SerializeField] private GameObject projObject = null;
    [SerializeField] private Transform projectileSpawn;

    private Projectile theBullet = null;
    private GameObject projectile;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }
    }

    public void shoot()
    {
        Debug.Log("RpcShoot:: Called in the network");

        projectile = Instantiate(
            projObject,
            projectileSpawn.position,
            projectileSpawn.rotation
            );

        theBullet = projectile.GetComponent<Projectile>();
        theBullet.projectileID++;

        Debug.Log("CmdShoot:: Projectile ID: " + theBullet.projectileID);

        projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * 6;
        projectile.transform.SetParent(null);

      //  Instantiate(projectile);

        // Call RPC for because this command only wokrs for server.

        Destroy(projectile, 2.0f);
    }
}