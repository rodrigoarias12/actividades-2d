using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
public class OpcionIncorrecta : MonoBehaviour , IPointerClickHandler
{

	// Use this for initialization
	void Start () {
		
	}
    public void OnPointerClick(PointerEventData eventData)
    {
       
      //  GameObject.Find("SonidoPerdedor").GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
