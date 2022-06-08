using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Part_show : MonoBehaviour
{
    private Color startcolor;
    private MeshRenderer meshrenderer;
    private Vector3 offset;
    private float ZCoord;
    private Part_pick Ppick;
    public bool IsClicked = false;
    private void Start()
    {
        meshrenderer = GetComponent<MeshRenderer>();
        startcolor = meshrenderer.material.color;
        Ppick = FindObjectOfType<Part_pick>();

    }
    private void OnMouseEnter()
    {
        if (!Ppick.Partmoving && !EventSystem.current.IsPointerOverGameObject())
            meshrenderer.material.color = Color.red;
    }
    private void OnMouseExit()
    {
        if (!IsClicked)
            meshrenderer.material.color = startcolor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        ZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        offset = gameObject.transform.position - GetWorldMousePosition();

        Ppick.Partmoving = true;
        IsClicked = !IsClicked;

        meshrenderer.material.color = Color.red;

    }
    private void OnMouseUp()
    {
        Ppick.Partmoving = false;
        // meshrenderer.material.color = startcolor;
    }
    private void OnMouseDrag()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        transform.position = GetWorldMousePosition() + offset;
        meshrenderer.material.color = Color.red;
    }
    public Vector3 GetWorldMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = ZCoord;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }


}
