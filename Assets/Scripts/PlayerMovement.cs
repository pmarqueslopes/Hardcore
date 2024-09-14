using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    InputManager inputManager;
    PlayerManager playerManager;
    AnimatorManager animatorManager;

    private Vector3 movementDirection;
    private Transform cam;
    private Rigidbody rb;

    [Header("Falling")]
    public float inAirTimer;
    public float fallingVelocity;
    public float leapingVelocity;
    public LayerMask groundLayer;
    public float rayCastHeightOffSet = -0.5f;
    public float maxDistance = 1;


    [Header("Movement")]
    public bool isSprinting;
    public bool isGrounded;
    public bool isJumping;


    [Header("Movement Speeds")]
    public float walkingSpeed = 1.5f;
    public float runningSpeed = 5f;
    public float sprintingSpeed = 7f;
    public float rotationSpeed = 15f;

    [Header("Jump")]
    public float jumpHeight = 3;
    public float gravityIntensity = -15;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
        playerManager = GetComponent<PlayerManager>();
        animatorManager = GetComponent<AnimatorManager>();
    }

    public void HandleAllMovement()
    {
        HandleFallingAndLanding();
        if (playerManager.isInteracting)//trava a movimenta��o enquanto est� em outra a��o
        {
            return;
        }
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement() //movimenta��o vertical (WS)
    {
        if (isJumping)
        {
            return;
        }

        movementDirection = cam.forward * inputManager.verticalInput;
        movementDirection = movementDirection + cam.right * inputManager.horizontalInput;
        movementDirection.Normalize();
        movementDirection.y = 0;

        if (isSprinting)
        {
            movementDirection = movementDirection * sprintingSpeed;
        }
        else
        {
            if (inputManager.moveAmount >= 0.5f)//velocidade que o personagem se move
            {
                movementDirection = movementDirection * runningSpeed;
            }
            else
            {
                movementDirection = movementDirection * walkingSpeed;
            }
        }
        if (isGrounded && !isJumping)
        {
            Vector3 movementVelocity = movementDirection;
            rb.velocity = movementVelocity; //this is the root of my jumping problem
        }
            Vector3 velocity = movementDirection;
            rb.velocity = velocity;
    }

    private void HandleRotation()//movimenta��o horizontal (AD)
    {
        if (isJumping)
        {
          //  return;
        }

        Vector3 targetDirection = Vector3.zero; //deixa como zero no come�o
        targetDirection = cam.forward * inputManager.verticalInput;
        targetDirection = targetDirection + cam.right * inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }

    private void HandleFallingAndLanding()
    {
        RaycastHit hit;
        Vector3 rayCastOrigin = transform.position;
        rayCastOrigin.y = rayCastOrigin.y + rayCastHeightOffSet;

        if (!isGrounded && !isJumping)
        {
            if (!playerManager.isInteracting)
            {
                animatorManager.PlayTargetAnimation("metarig|Falling", true);
            }

            inAirTimer = inAirTimer + Time.deltaTime;
            rb.AddForce(transform.forward * leapingVelocity);
            rb.AddForce(-Vector3.up * fallingVelocity * inAirTimer); //Quanto mais tempo no ar mais rapido voc� cai
        }

        if (Physics.SphereCast(rayCastOrigin, 0.2f, -Vector3.up, out hit, groundLayer))
        {
            if (!isGrounded && playerManager.isInteracting)
            {
                animatorManager.PlayTargetAnimation("metarig|Landing", true);
            }

            inAirTimer = 0;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    public void HandleJump()
    {
        if (isGrounded)
        {
            animatorManager.animator.SetBool("isJumping", true);
            animatorManager.PlayTargetAnimation("mixamo_com", false);

            float jumpingVelocity = Mathf.Sqrt(-2 * gravityIntensity * jumpHeight);
            Vector3 playerVelocity = movementDirection;
            playerVelocity.y = jumpingVelocity;
            rb.velocity = playerVelocity;
        }
    }

}
