using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSource : MonoBehaviour
{
    public Transform targetPoint;
    public Camera cameraLink;
    public float targetInSkyDistance;
    int[] numbers = { 7, 12, 4, 8, 3, 64, 11 };
    int result = 5;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 6; i++)
        {
            result += numbers[i];
        }
        Debug.Log(result);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        var ray = cameraLink.ViewportPointToRay(new Vector3(0.5f, 0.7f, 0f));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint.position = hit.point;
        }
        else
        {
            targetPoint.position = ray.GetPoint(targetInSkyDistance);
        }
        transform.LookAt(targetPoint.position);
    }
}
