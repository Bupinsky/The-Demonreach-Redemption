using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MirrorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // when a projectile hits the mirror, they player wins.  This will eventually be made to bring the player to the next scene.
        if (collision.gameObject.tag == "Projectile" || collision.gameObject.tag == "Fireball")
        {
            print("WINNER!");
            Destroy(collision.gameObject);
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
