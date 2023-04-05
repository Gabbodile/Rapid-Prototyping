using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Projectile : GameBehaviour
{
    public int destroyTime = 3;
    public int score = 0;
    public int scoreMultiplier = 1;

    [SerializeField] ParticleSystem shootParticle = null;
    void Update()
    {
        Destroy(this.gameObject, destroyTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy");
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Floor1"))
        {
            PlayParticle();
            Debug.Log("Add score +10");
            ProjectileScore(10);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Floor2"))
        {
            PlayParticle();
            Debug.Log("Add score +25");
            ProjectileScore(25);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Floor3"))
        {
            PlayParticle();
            Debug.Log("Add score +50");
            ProjectileScore(50);
            Destroy(this.gameObject);
        }
    }

    void PlayParticle()
    {
        shootParticle.Play();
    }

    public void ProjectileScore(int _score)
    {
        score += score + _score;
        _SHOP.AddMoney(score);
    }
}
