using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShooting : NetworkBehaviour
{
    GameObject bullet = null;
    GameObject cam = null;
    [SerializeField] Transform projectileSpawn = null;

    private void Start()
    {
        cam = GameObject.Find("ARCamera");
        projectileSpawn = GameObject.Find("SpawnPoint").transform;
    }
    public void Shoot()
    {
        Debug.Log(projectileSpawn.position);
        bullet = (GameObject)Network.Instantiate(
           projectileSpawn,
           projectileSpawn.position,
           projectileSpawn.rotation,
           0);

        bullet.transform.SetParent(null, true);
    }
}
