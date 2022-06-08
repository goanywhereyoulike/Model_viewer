using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Part_show : MonoBehaviour
{
    Button_Control buttonc;
    [SerializeField]
    Material HighlightMaterial;
    private Material startMaterial;
    private MeshRenderer meshrenderer;
    private Vector3 offset;
    private float ZCoord;
    private Part_pick Ppick;
    public bool IsClicked = false;
    private void Start()
    {
        buttonc = FindObjectOfType<Button_Control>();
        meshrenderer = GetComponent<MeshRenderer>();
        startMaterial = meshrenderer.material;
        Ppick = FindObjectOfType<Part_pick>();

    }
    private void OnMouseEnter()
    {
        if (!Ppick.Partmoving && !EventSystem.current.IsPointerOverGameObject())
            meshrenderer.material = HighlightMaterial;
    }
    private void OnMouseExit()
    {
        if (!IsClicked)
        {
            if (buttonc.IsX_ray)
            {
                meshrenderer.material = buttonc.X_ray_material;
            }
            else
            {
                meshrenderer.material = startMaterial;
            }

        }

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

        meshrenderer.material = HighlightMaterial;

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
        meshrenderer.material = HighlightMaterial;
    }
    public Vector3 GetWorldMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = ZCoord;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }


}
