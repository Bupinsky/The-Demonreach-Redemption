using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
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
        // if player touches flag, progress to next level
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("next level");
            int buildIndex = SceneManager.GetActiveScene().buildIndex;
            if (buildIndex != 9)
            {
                SceneManager.LoadScene(buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
