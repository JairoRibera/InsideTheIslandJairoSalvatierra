using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjetos : MonoBehaviour
{
    public Transform pos;
    public GameObject[] listaPluma;
    //public GameObject[] listaHongo;
    //public GameObject[] listaPocion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator GenerarItemCo()
    {
        yield return new WaitForSeconds(1f);
        InstantiatePluma();
    }
    public void InstantiatePluma()
    {
        int n = Random.Range(0, listaPluma.Length);
        Instantiate(listaPluma[n], pos.position, pos.transform.rotation);
    }
}
