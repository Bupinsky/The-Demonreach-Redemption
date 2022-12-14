using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //how far above the player the camera will be
    public int height;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 motion = new Vector2(player.transform.position.x - this.transform.position.x, (player.transform.position.y + height) - this.transform.position.y);
        if (motion.magnitude > 0.1)
        {
            // if the camera is far enough from the center, move it closer
            motion = motion.normalized;
            motion *= 10;
            Vector3 motion3d = new Vector3(motion.x, motion.y, 0);
            this.transform.position += motion3d * Time.deltaTime;
        } else
        {
            // center the camera if the camera is already almost centered
            Vector3 motion3d = new Vector3(motion.x, motion.y, 0);
            this.transform.position += motion3d;
        }
    }
}
