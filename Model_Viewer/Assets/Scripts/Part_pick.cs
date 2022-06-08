using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part_pick : MonoBehaviour
{
    private bool partmoving;
    public bool Partmoving { get => partmoving; set => partmoving = value; }

    public GameObject PartNamePrefab;

    [SerializeField]
    Vector3 Offset;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray;
            RaycastHit hit;
            GameObject obj;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                obj = hit.collider.gameObject;

                if (obj != null)
                {
                    var part = obj.GetComponent<Part_show>();
                    if (part && part.IsClicked)
                    {
                        Part_Name partname = obj.GetComponentInChildren<Part_Name>();
                        if (partname)
                        {
                            return;
                        }
                        GameObject PartPanel = Instantiate(PartNamePrefab);
                        PartPanel.GetComponent<Part_Name>().SetModelPartName(obj.name);
                        var pos = part.GetWorldMousePosition();
                        pos.z -= 0.5f;
                        PartPanel.transform.position = pos;
                        PartPanel.transform.SetParent(obj.transform);
                    }
                    else
                    {
                        Part_Name partname = obj.GetComponentInChildren<Part_Name>();
                        if (partname)
                        {
                            Destroy(partname.gameObject);
                        }

                    }

                }


            }
        }

    }
}
