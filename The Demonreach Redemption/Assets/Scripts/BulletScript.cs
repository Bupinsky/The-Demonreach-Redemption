using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    GameObject player;
    GameObject camera;
    PlayerScript playerScript;
    public Vector2 velocity;
    public int speed;
    float x;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        camera = GameObject.FindWithTag("MainCamera");
        playerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // moving the bullet
        x = transform.position.x + Time.deltaTime * velocity.x;
        y = transform.position.y + Time.deltaTime * velocity.y;
        transform.position = new Vector3(x, y, 0);

        // rotating the bullet ( this doesnt work rn cuz the unity gravity does not correspond to this script's velocity )
        Vector2 unitVec = new Vector2(0, 1);
        transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(unitVec, velocity));


        // double click for teleportation
        if (Input.GetMouseButtonDown(0))
        {
            // cooldown makes sure this click does not simultaniously start another launch
            playerScript.cooldown = true;
            Vector3 newPosition = this.transform.position;
            //raising height by 1 so the player doesnt spawn inside the platform
            newPosition.y += 1;
            player.transform.position = newPosition;
            Destroy(gameObject);
        }


        // destroy out of bounds bullets
        if (!isInBounds())
        {
            Destroy(gameObject);
            //Debug.Log("bullet destroyed");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // for now all ground collisions will allow for teleportation
        if (collision.gameObject.layer == 3)
        {
            Vector3 newPosition = this.transform.position;
            //raising height by 1 so the player doesnt spawn inside the platform
            newPosition.y += 1;
            player.transform.position = newPosition;
            Destroy(gameObject);
        }
    }

    public void SetVelocity(float xVel, float yVel)
    {
        velocity = new Vector2(xVel * speed, yVel * speed);
    }

    public bool isInBounds()
    {
        if (Mathf.Abs(camera.transform.position.x - x) > 10 || Mathf.Abs(camera.transform.position.y - y) > 8) return false;
        return true;
    }

    public Vector2 getVelocity()
    {
        return velocity;
    }

    public void setVelocity(Vector2 newVel)
    {
        velocity = newVel;
    }
}
