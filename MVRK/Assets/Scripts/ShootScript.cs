using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {



    // Update is called once per frame
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;

    public void Fire()
    {
        GameObject bullet = Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        bullet.transform.SetParent(null);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 5;

        Destroy(bullet, 5.0f);
    }
}
