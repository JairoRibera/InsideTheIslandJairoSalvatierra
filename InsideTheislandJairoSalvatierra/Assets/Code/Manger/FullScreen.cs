using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreen : MonoBehaviour
{
    public Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        if (Screen.fullScreen)
        {
            if (Screen.fullScreen)
                toggle.isOn = true;
            else
                toggle.isOn = false;
        }
    }
    public void ActivateFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
