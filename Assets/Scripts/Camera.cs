using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Vector2 mouseAxis;
    public Transform Player;

    float xRotation;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseAxis.x = Input.GetAxis("Mouse X");
        mouseAxis.y = Input.GetAxis("Mouse Y");

        xRotation -= mouseAxis.y;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        Player.Rotate(Vector3.up * mouseAxis.x);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }
}
