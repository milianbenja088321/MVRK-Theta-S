using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{

    enum ProjectileType
    {
        normal = 0,
        rocket,
        ballistic,
        hardshell
    }

    [SerializeField] float speed = 10.0f;
    [SerializeField] Text canvsText;

    public float timer = 3f;
    int ID;
    int count = 0;

    // Use this for initialization
    void Start()
    {

        this.transform.SetParent(null, false);
    }

    // Update is called once per frame
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
        
        if (collision.gameObject.tag == "Laser")
        {
            speed = -speed;
        }
        else if (collision.gameObject.tag == "ARPlayer")
        {
            Debug.Log("AR Player was hit");
        }
        else if (collision.gameObject.tag == "Player")
        {
            // let everyone know he was hit with an rpc
            Debug.Log("VR Player was hit");
        }

    }

    public void SetProjectileID(int _id) { ID = _id; }

    public void SetProjectileSpeed(int _speed) { speed = _speed; }

}
