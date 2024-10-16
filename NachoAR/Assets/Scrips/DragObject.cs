using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 startPos;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        startPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPos = cam.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, cam.nearClipPlane));
        transform.position = new Vector3(newPos.x, newPos.y, startPos.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Aquí puedes añadir lógica cuando termine el drag
    }
}
