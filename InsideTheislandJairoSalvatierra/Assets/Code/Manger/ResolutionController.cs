using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResolutionController : MonoBehaviour
{
    public Toggle toggle;
    public TMP_Dropdown resolutionDropDown;
    Resolution[] resoluciones;
    // Start is called before the first frame update
    void Start()
    {
        if (Screen.fullScreen)
            toggle.isOn = true;
        else 
            toggle.isOn = false;
        RevisarResolucion();
    }
    public void RevisarResolucion()
    {
        resoluciones = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionesActual = 0;

        for(int i = 0; i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            opciones.Add(opcion);
            if(Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)
            {
                resolucionesActual = i;
            }
        }

        resolutionDropDown.AddOptions(opciones);
        resolutionDropDown.value = resolucionesActual;
        resolutionDropDown.RefreshShownValue();
        resolutionDropDown.value = PlayerPrefs.GetInt("numeroResolucion", 0);

    }
    public void CambiarResolucion(int indiceResolucion)
    {
        PlayerPrefs.SetInt("numeroResolucion", resolutionDropDown.value);
        Resolution resolucion = resoluciones[indiceResolucion];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
