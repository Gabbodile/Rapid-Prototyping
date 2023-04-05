using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Money : GameBehaviour<Money>
{
    public TMP_Text money;
    public GameObject shop;
    public bool open = false;

    private void Start()
    {
        open = false;
    }

    private void Update()
    {
        shop.SetActive(open);

        if (Input.GetKey(KeyCode.E))
        {
            OpenShop();
        }
    }

    public void OpenShop()
    {
        open = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseShop()
    {
        open = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Apple()
    {
        _AMMO.fruit = AmmoType.Apple;
    }

    public void Banana()
    {
        _AMMO.fruit = AmmoType.Banana;
    }

    public void Chili()
    {
        _AMMO.fruit = AmmoType.Chili;
    }

    public void Meatball()
    {
        _AMMO.fruit = AmmoType.Meatball;
    }

    public void AddMoney(int _score)
    {
        DOTween.To(() => _score, x => _score = x, _score, 1).OnUpdate(() =>
        {
            money.text = "money: " + _score;
        });
    }
}
