using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIImage : MonoBehaviour
{

    public const string DRAGGABLE_TAG = "UIDraggable";
    // public const string NOT_DRAGGABLE_TAG = "DragAndDrop";
    public const string NOT_DRAGGABLE_TAG = "DragAndDrop";
    private bool dragging = false;

    private Vector3 originalPosition;
    private Transform objectToDrag;
    private Image objectToDragImage;

    List<RaycastResult> hitObjects = new List<RaycastResult>();
    [SerializeField]
    protected int m_numero;

    #region Monobehaviour API
    Vector3 mouseStartPos;
    Vector3 playerStartPos;
    void Update()
    {
  

        if (Input.GetMouseButtonDown(0))
        {
            objectToDrag = GetDraggableTransformUnderMouse();

            if (objectToDrag != null)
            {
                dragging = true;

                objectToDrag.SetAsLastSibling();

                originalPosition = objectToDrag.position;
                mouseStartPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                playerStartPos = objectToDrag.position;
                objectToDragImage = objectToDrag.GetComponent<Image>();
                objectToDragImage.raycastTarget = false;
                

            }
        }

        if (dragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            Vector3 move = mousePos - mouseStartPos;
            objectToDrag.transform.position= playerStartPos + move;
        }
        var exp = GameObject.Find("EfectoGanar").GetComponent<ParticleSystem>();

        if (Input.GetMouseButtonUp(0))
        {
            if (objectToDrag != null)
            {
                var objectToReplace = GetDraggableTransformUnderMouseWithNotDraggableTag();


                if (objectToReplace != null)
                {

                    GameManager.DragAndDrop++;
                    Debug.Log("GameManager.DragAndDrop"+ GameManager.DragAndDrop);
                    if (objectToDrag.name == "InventoryTile1" && "1" == objectToReplace.name)
                    {
                        GameManager.match++;   
                        Debug.Log("match +1");
                        AudioManager.Singleton.PlayCoinSound();
                        exp.transform.position = objectToReplace.position;
                        exp.Play();

                    }
                    if (objectToDrag.name == "InventoryTile2" && "2" == objectToReplace.name)
                    {
                        GameManager.match++;
                        Debug.Log("match +1");
                        AudioManager.Singleton.PlayCoinSound(); exp.transform.position = objectToReplace.position;
                        exp.Play();

                    }
                    if (objectToDrag.name == "InventoryTile3" && "3" == objectToReplace.name)
                    {
                        GameManager.match++;
                        Debug.Log("match +1");
                        AudioManager.Singleton.PlayCoinSound(); exp.transform.position = objectToReplace.position;
                        exp.Play();
                    }
                    if (objectToDrag.name == "InventoryTile4" && "4" == objectToReplace.name)
                    {
                        GameManager.match++;
                        Debug.Log("match +1");
                        AudioManager.Singleton.PlayCoinSound();
                       
                        exp.transform.position = objectToReplace.position;
                        exp.Play();
                    }
                    objectToDrag.position = objectToReplace.position;
                    //Para superponer la imagen reemplezada donde estaba la imagen que estoy arrastrando.
                    //       objectToReplace.position = originalPosition;
                    //cambio el tag asi no puede arrastrar la imagen por segunda vez.
                    objectToReplace.tag = NOT_DRAGGABLE_TAG;
                    
                   // Destroy(gameObject, exp.main.duration);
                    
                    // objectToDragImage.tag = NOT_DRAGGABLE_TAG;
                    //  objectToDragImage.raycastTarget = false;

                }
                else
                {
                    objectToDrag.position = originalPosition;
                }

                objectToDragImage.raycastTarget = true;
                objectToDrag = null;
            }

            dragging = false;
        }
    }
    //objetos que estan abajo del mouse 
    private GameObject GetObjectUnderMouse()
    {
        var pointer = new PointerEventData(EventSystem.current);

        pointer.position = Input.mousePosition;

        EventSystem.current.RaycastAll(pointer, hitObjects);

        if (hitObjects.Count <= 0) return null;

        return hitObjects.First().gameObject;
    }
    //traemos la imagen seleccionada con el mousa con el tag que definimos 
    private Transform GetDraggableTransformUnderMouse()
    {
        var clickedObject = GetObjectUnderMouse();

        // get top level object hit
        if (clickedObject != null && clickedObject.tag == DRAGGABLE_TAG)
        {
            return clickedObject.transform;
        }

        return null;
    }
    //traemos la imagen seleccionada con el mousa con el tag que definimos 
    private Transform GetDraggableTransformUnderMouseWithNotDraggableTag()
    {
        var clickedObject = GetObjectUnderMouse();

        // get top level object hit
        if (clickedObject != null && clickedObject.tag == NOT_DRAGGABLE_TAG)
        {
            return clickedObject.transform;
        }

        return null;
    }
    #endregion
}

