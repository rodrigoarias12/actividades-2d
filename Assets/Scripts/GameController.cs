using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    public static int[] orden = new int[100];
    public static int numeroClick;
    // Use this for initialization
    void Start () {
        numeroClick = 0;

    }
   
    // Update is called once per frame
    void Update () {
        if (orden[0]==1 && orden[1]==2 && orden[2]==3 )
        {
           // Destroy(gameObject);
            Debug.Log("ordena");
        }


	}
}
