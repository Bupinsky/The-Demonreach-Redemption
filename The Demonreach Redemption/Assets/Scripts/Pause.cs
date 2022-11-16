using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool inButton;
    public static bool paused;
    public GameObject pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        inButton = false;
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click()
    {
        if (paused)
        {
            Time.timeScale = 1;
            paused = false;
            pauseScreen.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            paused = true;
            pauseScreen.SetActive(true);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse entered");
        inButton = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        inButton = false;
    }
}
