using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum ProjectileType
{
    normal = 0,
    rocket,
    ballistic,
    hardshell

}
public class Projectile : MonoBehaviour
{



    [SerializeField] float speed = 10.0f;
    [SerializeField] float damage = 5;
    [SerializeField] Text canvsText;

    public float timer = 3f;
    int ID;
    int count = 0;

    public int projectileID { get; set; }
    public float GetDamage() { return damage; }

    void Start()
    {
        this.transform.SetParent(null, false);
    }
    void Update()
    {
        this.GetComponent<Rigidbody>().velocity = this.transform.forward * speed;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            //  PhotonNetwork.Destroy(this.GetComponent<PhotonView>()); ;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hit = null;

        if (collision.gameObject.tag == "Laser")
        {
            speed = -speed;
        }
        else if (collision.gameObject.tag == "ARPlayer")
        {
            Debug.Log("AR Player was hit");
            hit = collision.gameObject;
            Health health = hit.GetComponent<Health>();

            if (health != null) { health.TakeDamage(damage); }
        }
        else if (collision.gameObject.tag == "Player")
        {
            Debug.Log("VR Player was hit");

            hit = collision.gameObject;
            Health health = hit.GetComponent<Health>();

            if (health != null) { health.TakeDamage(damage); }
        }

    }

    public void SetProjectileID(int _id) { ID = _id; }

    public void SetProjectileSpeed(int _speed) { speed = _speed; }

}
