using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceArea : MonoBehaviour
{
    public string transitionName, savedTransitionName;
    public float dirX;
    PlayerMovement _pM;
    // Start is called before the first frame update
    void Start()
    {
       
        _pM = GameObject.Find("Player").GetComponent<PlayerMovement>();
        //este if sirve para cargar el valor guardado
        if (PlayerPrefs.HasKey("areaTransitionNameV"))
            //aqui se obtiene el valor exacto de lo que queremos cargar
            savedTransitionName = PlayerPrefs.GetString("areaTransitionNameV");
        if (transitionName == savedTransitionName)
        {
            _pM.transform.position = transform.position;
            if (dirX > 0)
                _pM.transform.eulerAngles = new Vector2(0, 0);  
            else if (dirX < 0)
                _pM.transform.eulerAngles = new Vector2(0, 180);
              
            _pM.InitializaNoInput();
        }
    }
}
