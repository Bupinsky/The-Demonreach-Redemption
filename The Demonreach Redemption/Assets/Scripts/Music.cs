using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource source;
    private void Start()
    {
        SceneManager.activeSceneChanged += Change;
        source = this.GetComponent<AudioSource>();
    }
    void Awake()
    {
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

            if (objs.Length > 1)
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    { 
    }
    private void Change(Scene current, Scene next)
    {
        if(next.name == "MainMenu")
        {
            source.Stop();
        }
        else if(!source.isPlaying)
        {
            source.Play();
        }
    }
}
