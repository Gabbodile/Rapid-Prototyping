using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : GameBehaviour<PlayerController>
{
    private Rigidbody playerRB;
    private GameObject focalPoint;

    [Header("Player")]
    public float speed = 5.0f;
    public int playerHealth = 3;
    public GameObject player;
    public Transform respawnPoint;

    [Header("Power ups")]
    public bool hasPowerUp = false;
    public float powerUpStrength = 15;
    public float seconds = 7;
    public GameObject powerupIndicator;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        SetUp();
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        powerupIndicator.transform.position = transform.position + new Vector3(0, 1f, 0);
        playerRB.AddForce(focalPoint.transform.forward * speed * forwardInput);
        Health(playerHealth);
    }

    void SetUp()
    {
        switch (_GM.difficulty)
        {
            case Difficulty.Easy:
                playerHealth = 10;
                seconds = 10;
                break;
            
            case Difficulty.Medium:
                playerHealth = 3;
                seconds = 7;
                break;
            
            case Difficulty.Hard:
                playerHealth = 1;
                seconds = 5;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdown());
        }

        if (other.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            _SM.CollectableScore();
        }

        if (other.CompareTag("Potion"))
        {
            Destroy(other.gameObject);
            playerHealth++;
        }

        if (other.CompareTag("Out Of Bounds"))
        {
            player.transform.position = respawnPoint.position;
            playerHealth = playerHealth - 1;
            Health(playerHealth);
            if (playerHealth == 0)
            {
                _UI.GameOver();
            }
        }
    }

    IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(seconds);
        powerupIndicator.gameObject.SetActive(false);
        hasPowerUp = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            Debug.Log("Collided with" + collision.gameObject.name + " with powerup set to" + hasPowerUp);
        }
        else
        {
            Debug.Log("Collided with" + collision.gameObject.name + " with powerup set to" + hasPowerUp);
        }
    }

    public void Health(int _health)
    {
        _health = playerHealth;
        _UI.TweenHealth(_health);
    }
}
