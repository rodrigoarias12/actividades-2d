using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Orden1 : MonoBehaviour, IPointerClickHandler
{

	// Use this for initialization
	void Start () {
		
	}
    public void OnPointerClick(PointerEventData eventData)
    {
     
        GameController.orden[GameController.numeroClick] =1;
        GameController.numeroClick++;
        //  GameObject.Find("SonidoGanador").GetComponent<AudioSource>().Play();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
