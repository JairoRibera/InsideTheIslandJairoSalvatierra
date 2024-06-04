using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swicht : MonoBehaviour
{
    public GameObject objectToSwitch;
    private bool _activateSwitch;
    public GameObject infoPanel;
    private PlayerMovement _pC;
    public Sprite pOn;
    private SpriteRenderer _sR;
    //Collider2D _trampCollider;
    // Start is called before the first frame update
    void Start()
    {
        _sR = GetComponent<SpriteRenderer>();
        _pC = GameObject.Find("Player").GetComponent<PlayerMovement>();
        //_trampCollider = GameObject.Find("ObjectActivator").GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && _pC.canInteract)
        {
            if (objectToSwitch.GetComponent<ObjectcActivator>().isActive == false)
            {
                _sR.sprite = pOn;
                objectToSwitch.GetComponent<ObjectcActivator>().ActivateObject();
                objectToSwitch.GetComponent<ObjectcActivator>().isActive = true;
                //_trampCollider.enabled = true;
            }
            //else
            //{
                
            //    objectToSwitch.GetComponent<ObjectcActivator>().isActive = false;
            //    _trampCollider.enabled = false;
            //}
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            infoPanel.SetActive(true);
            collision.GetComponent<PlayerMovement>().canInteract = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            infoPanel.SetActive(false);
            collision.GetComponent<PlayerMovement>().canInteract = false;
        }
    }
    
}
