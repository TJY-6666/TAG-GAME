using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class playerScript : MonoBehaviour

{
    public float timeSinceLastCollision = 0f;

    public Rigidbody2D rbPlayer;
    [SerializeField] float moveSpeed = 50f;

    private Vector2 direction;
    private Vector2 targetPosition;

    public bool hit = true;

    public GameObject sparkParticlePrefab; 

    public SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer


    public timeManagerScript timeManagerScript;



    // Start is called before the first frame update
    void Start()
    {
        // Set the initial target position to the ball's current position
        targetPosition = rbPlayer.position;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastCollision += Time.deltaTime;

        if (hit)
        {
            spriteRenderer.color = Color.red;
        }
        else
        {
            spriteRenderer.color = Color.blue;
        }


    }

    void FixedUpdate()
    {

        // Set the velocity to move towards the target position
        rbPlayer.velocity = direction * moveSpeed;
    }

    public void changeDirection(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // Get the world position of the mouse click
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Set the target position, ignoring the z-axis
            targetPosition = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);

            // Calculate the direction to the target position
            direction = targetPosition - rbPlayer.position;
            direction.Normalize();

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //wall
        if (collision.gameObject.layer == 3)
        {
            // Reflect the ball's direction based on the collision normal
            direction = Vector2.Reflect(direction, collision.contacts[0].normal);
            rbPlayer.velocity = direction * moveSpeed;
        }


        //enemy
        if (collision.gameObject.layer == 6)
        {


            // Reflect the ball's direction based on the collision normal
            direction = Vector2.Reflect(direction, collision.contacts[0].normal);
            rbPlayer.velocity = direction * moveSpeed;

            //spark effect!!
            // Get the collision contact point
            ContactPoint2D contact = collision.contacts[0];

            // Instantiate the spark particle system at the contact point
            GameObject sparkInstance = Instantiate(sparkParticlePrefab, contact.point, Quaternion.identity);

            // Optionally, destroy the particle system after it finishes playing
            Destroy(sparkInstance, sparkInstance.GetComponent<ParticleSystem>().main.duration);


            //bullet Time!!
            timeManagerScript.slowMotion();

            //fix continuous hitting
            if (timeSinceLastCollision >= 0.5f)
            {
            hit = !hit;

            }

            timeSinceLastCollision = 0f;


        }

    }

}