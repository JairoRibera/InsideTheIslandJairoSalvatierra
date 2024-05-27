using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public AudioManager _aMReference;
    //public Image imageMute;
    // Start is called before the first frame update
    void Start()
    {

        //sliderValue = PlayerPrefs.GetFloat("SliderVolumen", 0.5f);
        AudioListener.volume = slider.value;
        //CheckMute();
    }
    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("SliderVolumen", sliderValue);
        //_aMReference.bgm.volume = slider.value;
        //_aMReference.levelEndMusic.volume = slider.value;
        //_aMReference.bossMusic.volume = slider.value;
        foreach (AudioSource sound in _aMReference.soundEffects)
        {
            sound.volume = sliderValue;
        }
        foreach (AudioSource sound in _aMReference.Music)
        {
            sound.volume = sliderValue;
        }
        AudioListener.volume = slider.value;
        //CheckMute();
    }
    //public void CheckMute()
    //{
    //    if (sliderValue == 0)
    //        imageMute.enabled = true;
    //    else
    //        imageMute.enabled = false;

    //}
}
