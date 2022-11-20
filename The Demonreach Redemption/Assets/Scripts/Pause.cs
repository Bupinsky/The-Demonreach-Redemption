using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Pause : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool inButton;
    public static bool paused;
    public GameObject pauseScreen;
    public GameObject buttonTextObject;
    TMP_Text buttonText;
    // Start is called before the first frame update
    void Start()
    {
        inButton = false;
        paused = false;
        buttonText = buttonTextObject.GetComponent<TMP_Text>();

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
            buttonText.text = "Pause";


        }
        else
        {
            Time.timeScale = 0;
            paused = true;
            pauseScreen.SetActive(true);
            buttonText.text = "Resume";
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
