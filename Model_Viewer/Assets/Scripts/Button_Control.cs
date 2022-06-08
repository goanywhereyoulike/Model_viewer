using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button_Control : MonoBehaviour
{
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
    }
}
