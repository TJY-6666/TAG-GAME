using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public Rigidbody2D rbEnemy;

    public SpriteRenderer spriteRenderer;

    public Transform player;

    private float timer = 0;
    [SerializeField]
    private float rateOfChasing = 2f;

    [SerializeField] float moveSpeed = 50f;

    private Vector2 direction;
    private Vector2 targetPosition;

    public playerScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial target position to the ball's current position
        targetPosition = rbEnemy.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < rateOfChasing)
        {
            timer += Time.deltaTime;
        }
        else
        {
            chase();
            timer = 0;
        }

        if (playerScript.hit)
        {
            spriteRenderer.color = Color.blue;
        }
        else
        {
            spriteRenderer.color = Color.red;
        }


    }

    void FixedUpdate()
    {
        if (playerScript.hit == false)
        {
            // Set the velocity to move towards the player
            rbEnemy.velocity = (direction * moveSpeed);
        } else
        {
            // Set the velocity to move away from the player
            rbEnemy.velocity = -(direction * moveSpeed);

        }

    }

    public void chase()
    {
        // Set the target position, ignoring the z-axis
        targetPosition = new Vector2(player.position.x, player.position.y);

        // Calculate the direction to the target position
        direction = targetPosition - rbEnemy.position;
        direction.Normalize();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reflect the ball's direction based on the collision normal
        direction = Vector2.Reflect(direction, collision.contacts[0].normal);
        rbEnemy.velocity = direction * moveSpeed;

    }

}
