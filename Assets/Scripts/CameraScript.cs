using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Vector2 mouseAxis;
    public Transform Player;

    public Animator charterAnimator;

    public float xRotation;

    public PlayerController playerController;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        mouseAxis.x = Input.GetAxis("Mouse X");
        mouseAxis.y = Input.GetAxis("Mouse Y");

        xRotation -= mouseAxis.y;
        xRotation = Mathf.Clamp(xRotation, -75, 50);

        Player.Rotate(Vector3.up * mouseAxis.x);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerController.spineRotation = xRotation;
    }

}
