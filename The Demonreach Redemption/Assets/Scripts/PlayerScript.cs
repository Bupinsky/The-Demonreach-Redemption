using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool isGrounded;
    public bool infiniteFlight;
    // a cooldown after a teleport to prevent the release of the teleport click from firing another bullet
    public bool cooldown;
    public float speed;

    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponentInChildren<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInBounds() && !infiniteFlight)
        {
            Destroy(gameObject);
            //Debug.Log("bullet destroyed");
        }
        // controls for walking
        if (isGrounded)
        {
            if (Input.GetKey("a"))
            {
                // move left
                Vector3 tempVector = new Vector3(-speed * Time.deltaTime, 0, 0);
                this.transform.position += tempVector;
            }
            else if (Input.GetKey("d"))
            {
                // move right
                Vector3 tempVector = new Vector3(speed * Time.deltaTime, 0, 0);
                this.transform.position += tempVector;
            }
        }
    }

    //checking when the player is on the ground by setting a variable when the enter or exit a collider on the ground layer
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isGrounded = true;
        }
        isGrounded = true;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isGrounded = false;
        }
    }

    public bool isInBounds()
    {
        if (Mathf.Abs(transform.position.x) > 10 || Mathf.Abs(transform.position.y) > 10) return false;
        return true;
    }
}
