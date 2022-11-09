using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    Vector2 normal;
    public bool rotateable = true;
    int cooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        normal = new Vector2(this.gameObject.transform.up.x, this.gameObject.transform.up.y);

    }

    // Update is called once per frame
    void Update()
    {
        //rotate when right clicked
        if (Input.GetMouseButtonDown(1) && rotateable)
        {
            // convert mouse position to the relative world position of the mouse
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePos);
            // make sure the mouse is close enough to the platform
            if (cooldown == 0 && Mathf.Abs(mousePosWorld.x - this.gameObject.transform.position.x) < 1 && Mathf.Abs(mousePosWorld.y - this.gameObject.transform.position.y) < 1)
            {
                this.gameObject.transform.Rotate(0,0,45);
                // recalculate normals because the object was rotated
                normal.x = this.gameObject.transform.up.x;
                normal.y = this.gameObject.transform.up.y;

                // considering a cooldown to prevent cheese
                //cooldown = 60;
            }

        }
        //if (cooldown > 0) cooldown -= 1;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile" || collision.gameObject.tag == "Fireball")
        {
            //print("collided");
            BulletScript bullet = collision.gameObject.GetComponent <BulletScript> ();
            //print(bullet.velocity.y);
            Vector2 newVel = Vector2.Reflect(bullet.getVelocity(), normal);
            bullet.setVelocity(newVel);

            //print(newVel.y);
        }
        if (this.gameObject.tag == "Wooden" && collision.gameObject.tag == "Fireball")
        {
            Destroy(this.gameObject);
            //print(newVel.y);
        }
    }

}
