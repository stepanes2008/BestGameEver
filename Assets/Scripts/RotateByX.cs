using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByX : MonoBehaviour
{
    public Transform CameraAxisTransform;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var X = (CameraAxisTransform.localEulerAngles.x - Time.deltaTime * rotationSpeed * Input.GetAxis("Mouse Y"));
        if (X > 180)
        {
            X -= 360f;
        }
        CameraAxisTransform.localEulerAngles = new Vector3(Mathf.Clamp(X, -30, 15), 0, 0);
    }
}
