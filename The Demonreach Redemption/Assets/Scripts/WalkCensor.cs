using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkCensor : MonoBehaviour
{
    // the walker is the enemy that is using ground censors to patrol
    // the walkers x velocity will be reversed when a censor exits a ground object
    public GameObject walker;

    // not exactly sure how to generalize this script rn, for now I gotta specify the exact script i'm gonna reference
    Naagloshii naagloshii;

    // Start is called before the first frame update
    void Start()
    {
        naagloshii = walker.GetComponent<Naagloshii>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        print("collision exited");
        if (collision.gameObject.layer == 3)
        {
            print("collision exited");
            naagloshii.turn();
        }
    }
}
