using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit application");
    }
    public void QuitToMenu()
    {
        SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
    }
}
