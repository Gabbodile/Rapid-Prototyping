using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AmmoType { Apple, Banana, Chili, Meatball }
public class FiringPoint : GameBehaviour<FiringPoint>
{
    public GameObject apple;
    public GameObject banana;
    public GameObject chili;
    public GameObject meatball;
    public float bulletSpeed = 1000f;
    public AmmoType fruit;

    private void Start()
    {
        fruit = AmmoType.Apple;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            FruitType();
    }

    void FruitType()
    {
        switch (fruit)
        {
            case AmmoType.Apple:
                fireApple();
                bulletSpeed = 1000f;
                break;
            case

                AmmoType.Banana:
                fireBanana();
                bulletSpeed = 1200f;
                break;

            case AmmoType.Chili:
                fireChili();
                bulletSpeed = 1500f;
                break;

            case AmmoType.Meatball:
                fireMeatball();
                break;
        }
    }

    void fireApple()
    {
        GameObject bulletInstance;
        bulletInstance = Instantiate(apple, transform.position, transform.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
    }
    void fireBanana()
    {
        GameObject bulletInstance;
        bulletInstance = Instantiate(banana, transform.position, transform.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
    }
    void fireChili()
    {
        GameObject bulletInstance;
        bulletInstance = Instantiate(chili, transform.position, transform.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
    }
    void fireMeatball()
    {
        GameObject bulletInstance;
        bulletInstance = Instantiate(meatball, transform.position, transform.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
    }
}
