using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Naagloshii : MonoBehaviour
{
    // the "walker" attributes
    public SpriteRenderer naagSprite;
    public Vector3 velocity;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        velocity.x = -speed;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += velocity * Time.timeScale;
    }

    public void turn()
    {
        this.velocity.x *= -1;
        this.naagSprite.flipX = !this.naagSprite.flipX;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Naagloshii")
        {
            turn();
        }
    }
}
