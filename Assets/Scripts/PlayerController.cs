using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator charterAnimator;
    public CharacterController characterController;
    public AudioSource audioSource;

    public AudioClip m4a1;

    public float gravity = 9.81f;
    public float speed = 5;
    public float jumpStrength = 3.5f;

    float directionY;

    public float spineRotation;
    public Transform spine;

    public Transform FirePoint;
    public ParticleSystem MuzzleEffect;

    Vector2 Axis;
    void Start()
    {
        charterAnimator = gameObject.GetComponent<Animator>();
        characterController = gameObject.GetComponent<CharacterController>();
        audioSource = gameObject.GetComponent<AudioSource>();
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


        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(m4a1);
        }

    }

    private void LateUpdate()
    {
        spine.rotation *= Quaternion.Euler(Vector3.right * spineRotation);
    }
}
