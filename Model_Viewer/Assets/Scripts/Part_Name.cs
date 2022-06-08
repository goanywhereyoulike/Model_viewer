using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Part_Name : MonoBehaviour
{
    [SerializeField]
    TMP_Text NameText;

    // Start is called before the first frame update
    public void SetModelPartName(string name)
    {
        NameText.text = name;
    }
}
