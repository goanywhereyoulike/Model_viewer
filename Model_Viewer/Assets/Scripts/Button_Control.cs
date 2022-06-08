using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button_Control : MonoBehaviour
{
    [SerializeField]
    Model_move model;
    Part_show[] parts;


    public Material X_ray_material;

    [SerializeField]
    Material lambert_material;

    [SerializeField]
    GameObject Part_List;
    [SerializeField]
    Button PartlistButton;
    [SerializeField]
    Button ResetButton;
    [SerializeField]
    Button X_RayButton;
    [SerializeField]
    Button TransparentButton;

    public bool IsX_ray = false;
    private void Awake()
    {
        parts = model.gameObject.GetComponentsInChildren<Part_show>();
    }
    private void Start()
    {
        PartlistButton.onClick.AddListener(() =>
        {
            if (Part_List.activeInHierarchy)
            {
                Part_List.SetActive(false);
            }
            else
            {
                Part_List.SetActive(true);
            }
        });

        ResetButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });

        X_RayButton.onClick.AddListener(() =>
        {
            foreach (var part in parts)
            {
                if (part.gameObject.GetComponent<MeshRenderer>().sharedMaterial.name == "X_ray_material")
                {
                    part.gameObject.GetComponent<MeshRenderer>().material = lambert_material;
                    IsX_ray = false;
                }
                else
                {
                    part.gameObject.GetComponent<MeshRenderer>().material = X_ray_material;
                    IsX_ray = true;
                }
            }
        });
    }
}
