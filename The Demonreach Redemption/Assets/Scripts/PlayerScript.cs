using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool isGrounded;
    public bool dead = false;
    public SpriteRenderer playerSprite;

    // moved bullet management to the player, to make it more easily accessable in other files
    public int numBullets;
    public int maxBullets;

    // a cooldown after a teleport to prevent the release of the teleport click from firing another bullet
    public bool cooldown;
    public float speed;
    public Vector3 spawn;
    GameObject camera;

    public float gravity;
    public Vector2 velocity;
    public float maxFallSpeed;
    public GameObject shoebox;

    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindWithTag("MainCamera");
        rigidbody = GetComponentInChildren<Rigidbody2D>();
        spawn = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // apply gravity
        if (!isGrounded)
        {
            if (velocity.y >= -maxFallSpeed)
            {
                velocity.y -= gravity;
            }
            Vector3 fallVector = new Vector3(0, velocity.y * Time.deltaTime, 0);
            this.transform.position += fallVector;
        } else
        {
            velocity.y = 0;
        }

        if (dead)
        {
            // bring the player and camera back to spawn
            transform.position = spawn;
            // temporary vector so the camera stays on the right spot in Z
            Vector3 tempvec = new Vector3(spawn.x, spawn.y, camera.transform.position.z);
            camera.transform.position = tempvec;
            // refill the bullets
            reload();
        }

        // reset same as dying for now
        if (Input.GetKey("r"))
        {
            // bring the player and camera back to spawn
            transform.position = spawn;
            // temporary vector so the camera stays on the right spot in Z
            Vector3 tempvec = new Vector3(spawn.x, spawn.y, camera.transform.position.z);
            camera.transform.position = tempvec;
            // refill the bullets
            reload();
        }

        // controls for walking
        if (Input.GetKey("a"))
        {
            // move left
            Vector3 tempVector = new Vector3(-speed * Time.deltaTime, 0, 0);
            this.transform.position += tempVector;
            // flip the sprite
            if (playerSprite.flipX)
            {
                playerSprite.flipX = false;
            }
        }
        else if (Input.GetKey("d"))
        {
            // move right
            Vector3 tempVector = new Vector3(speed * Time.deltaTime, 0, 0);
            this.transform.position += tempVector;
            // flip the sprite
            if (!playerSprite.flipX)
            {
                playerSprite.flipX = true;
            }
        }
    }

    public void reload()
    {
        numBullets = maxBullets;
    }
}