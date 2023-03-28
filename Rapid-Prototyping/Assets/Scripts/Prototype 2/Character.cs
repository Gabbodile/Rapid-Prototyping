using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : GameBehaviour
{

    [Header("Movement")]
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;


    [Header("Health")]
    public int playerHealth = 3;
    public int maxHealth = 5;
    public int healthMultipier = 1;

    private int damage = 1;


    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -0.2f;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
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
            //player.transform.position = respawnPoint.position;
            playerHealth = playerHealth - 1;
            Health(playerHealth);
            if (playerHealth == 0)
            {
                _UI.GameOver();
            }

        }
    }

    public void Health(int _health)
    {
        _health = playerHealth;
        _UI.TweenHealth(_health);
    }
}

