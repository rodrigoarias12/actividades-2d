using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PrimerOpcion : MonoBehaviour, IPointerClickHandler
{
    // Use this for initialization
    void Start()
    {

       

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var exp = GameObject.Find("EfectoGanar").GetComponent<ParticleSystem>();
        exp.Play();
        exp.transform.position = GameObject.Find("Canvas").transform.position;
        exp.Play();
        GameManager.match++;
        ControllerActividad._Actividad = 1;
        //  GameObject.Find("SonidoGanador").GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
      
    
    }
}
