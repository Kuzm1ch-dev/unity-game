using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator charterAnimator;
    public CharacterController characterController;

    public float gravity = 9.81f;
    public float speed = 5;
    public float jumpStrength = 3.5f;

    float directionY;

    public Vector2 Axis;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Axis.x = Input.GetAxis("Horizontal");
        Axis.y = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(Axis.x,0,Axis.y);

        if (characterController.isGrounded)
        {
            charterAnimator.SetFloat("FallTime", 0);
            if (Input.GetKey(KeyCode.Space))
            {
                directionY = jumpStrength;
                charterAnimator.SetTrigger("Jump");
            }

            if (Axis != Vector2.zero)
            {
                charterAnimator.SetFloat("WalkFloat", Axis.y);
                charterAnimator.SetBool("Walk", true);
            }
            else
            {
                charterAnimator.SetBool("Walk", false);
            }

        }
        else
        {
            charterAnimator.SetFloat("FallTime",charterAnimator.GetFloat("FallTime") + Time.deltaTime);
        }

        directionY -= gravity * Time.deltaTime;
        dir.y = directionY;

        characterController.Move(transform.TransformDirection(dir) * speed * Time.deltaTime);


    }
}
