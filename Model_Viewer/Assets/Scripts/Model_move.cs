using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_move : MonoBehaviour
{
    public List<string> ModelPartsName = new List<string>();
    private float rotationSpeed = 1.0f;
    private void Awake()
    {
        foreach (Transform parts in GetComponentsInChildren<Transform>())
        {
            ModelPartsName.Add(parts.name);
        }
    }
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float XRotation = Input.GetAxis("Mouse X") * rotationSpeed;
            float YRotation = Input.GetAxis("Mouse Y") * rotationSpeed;

            transform.Rotate(Vector3.down, XRotation);
            transform.Rotate(Vector3.right, -YRotation);
        }
        if (Input.GetMouseButton(2))
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z);
            Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            transform.position = objectPosition;
        }

    }
}
