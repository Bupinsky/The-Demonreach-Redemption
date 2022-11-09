using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool isGrounded;
    public bool infiniteFlight;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInBounds() && !infiniteFlight)
        {
            Destroy(gameObject);
            //Debug.Log("bullet destroyed");
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
