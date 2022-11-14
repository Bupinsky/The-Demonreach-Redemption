using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite activeFlag;
    public Sprite innactiveFlag;
    bool active;
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
        // if player touches flag, activate it
        if (collision.gameObject.tag == "Player")
        {
            active = true;
            spriteRenderer.sprite = activeFlag;
            PlayerScript playerScript = collision.gameObject.GetComponent<PlayerScript>();
            playerScript.spawn = this.transform.position;
            playerScript.reload();
        }
    }
}
