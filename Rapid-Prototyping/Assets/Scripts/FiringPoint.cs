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
        if (_GM.gameState == GameState.Pause)
            return;

        if (Input.GetButtonDown("Fire1"))
            FruitType();
    }

    void FruitType()
    {
        switch (fruit)
        {
            case AmmoType.Apple:
                FireApple();
                bulletSpeed = 1000f;
                break;
            case

                AmmoType.Banana:
                FireBanana();
                bulletSpeed = 1200f;
                break;

            case AmmoType.Chili:
                FireChili();
                bulletSpeed = 1500f;
                break;

            case AmmoType.Meatball:
                FireMeatball();
                break;
        }
    }

    void FireApple()
    {
        GameObject bulletInstance;
        bulletInstance = Instantiate(apple, transform.position, transform.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
    }
    void FireBanana()
    {
        GameObject bulletInstance;
        bulletInstance = Instantiate(banana, transform.position, transform.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
    }
    void FireChili()
    {
        GameObject bulletInstance;
        bulletInstance = Instantiate(chili, transform.position, transform.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
    }
    void FireMeatball()
    {
        GameObject bulletInstance;
        bulletInstance = Instantiate(meatball, transform.position, transform.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
    }
}
