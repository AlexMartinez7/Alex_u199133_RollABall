using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedAp : MonoBehaviour
{   
    public Vector3 direccionMovimiento = Vector3.left; 
    public float distancia = 2f;       
    public float velocidad = 2f;

    private Vector3 posicionInicial;
    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Mathf.Sin(Time.time * velocidad) * distancia;
        transform.position = posicionInicial + direccionMovimiento.normalized * offset;
    }
}
