using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjetos : MonoBehaviour
{
    public int contador;
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
    public IEnumerator GenerarItemPlumaCo()
    {
        yield return new WaitForSeconds(1f);
        InstantiatePluma();
    }
    public void InstantiatePluma()
    {
        if (contador <= 0)
        {
            //En la lista que tenemos, hacemos que eliga un numero de forma random
            int n = Random.Range(0, listaPluma.Length);
            //Si no se esta moviendo a la derecha instanciamos un objeto en la lista, usando la pos y rotacion del generador
            if(!GetComponentInParent<EnemiesController>().movingRight)
            Instantiate(listaPluma[n], pos.position, pos.transform.rotation);
            else
            {
                //En caso de que este mirando a la derecha, le añadimos un valor en la pos en X
                Vector3 newPos = new Vector3 (pos.position.x + 3.6f, pos.position.y, pos.position.z);
                Instantiate(listaPluma[n], newPos, pos.transform.rotation);
            }
            contador++;
        }
        else if (contador >= 1)
            contador--;
    }
}
