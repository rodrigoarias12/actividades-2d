﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SegundaOpcion : MonoBehaviour, IPointerClickHandler
{

 
    void Start()
    {
       
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        ControllerActividad._Actividad = 2;
        var exp = GameObject.Find("EfectoGanar").GetComponent<ParticleSystem>();
        exp.Play();
        exp.transform.position = GameObject.Find("Canvas").transform.position;
        exp.Play();
        GameManager.match++;
    }


    // Update is called once per frame
    void Update () {
		
	}
}