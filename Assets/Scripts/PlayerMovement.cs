using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public PlayerHealth playerHealth;
    private ScoreSystem scoring;
    Vector3 velocity;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public float jumpHeight = 3f;

    void Start()
    {
        scoring = gameObject.GetComponentInChildren<ScoreSystem>();
    }


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Poison")
        {
            playerHealth.decreaseHealth(10);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "HealthBox")
        {
            playerHealth.increaseHealth(10);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            scoring.increaseScore();
        }

        if (collision.gameObject.tag == "Enemy")
        {
            playerHealth.decreaseHealth(50);
        }
    }
}
