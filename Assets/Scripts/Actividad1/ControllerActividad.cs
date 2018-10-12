using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerActividad : MonoBehaviour
{
    List<string> preguntas = new List<string> { "Cual de estas opciones es un cepillo de dientes?", "La pasta de dientes es para ponerla en ...", "Cual es la toalla para secarse" };
    public static int _Actividad;
    public static int one_touch;
    // Use this for initialization
    void Start()
    {
        //INICIO
        _Actividad = 0;
        GameObject.Find("Canvas2").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Canvas3").GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       
       
        if (_Actividad == 1)
        {
         
            GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
            GameObject.Find("Canvas2").GetComponent<Canvas>().enabled = true;
            GameObject.Find("Canvas3").GetComponent<Canvas>().enabled = false;
        }
        if (_Actividad == 2 )
           
        {
           
            GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
            GameObject.Find("Canvas2").GetComponent<Canvas>().enabled = false;
            GameObject.Find("Canvas3").GetComponent<Canvas>().enabled = true;
        }

        if (_Actividad == 3)
        {          
           // GameObject.Find("Respuesta").GetComponent<TextMesh>().text = "MUY BIEN!!!!";
         
        }
        else
            GameObject.Find("TxtConsigna").GetComponent<TextMesh>().text = preguntas[_Actividad];        
    }
}
