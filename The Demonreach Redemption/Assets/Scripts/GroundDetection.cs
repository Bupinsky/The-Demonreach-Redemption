using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    public GameObject player;
    PlayerScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //checking when the player is on the ground by setting a variable when the enter or exit a collider on the ground layer
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            playerScript.isGrounded = true;
        }
        playerScript.isGrounded = true;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        playerScript.isGrounded = false;
    }
}
