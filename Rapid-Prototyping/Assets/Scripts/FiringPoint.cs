using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum fruitTypes { Apple, Banana, Chili }
public class FiringPoint : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 1000f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            fireBullet();
    }
    void fireBullet()
    {
        GameObject bulletInstance;
        bulletInstance = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
    }
}
