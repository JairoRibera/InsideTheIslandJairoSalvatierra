using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    private AudioManager _aMReference;
    void Start()
    {
        _aMReference = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        AudioListener.volume = slider.value;
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
    }
}
