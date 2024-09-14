using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
     PlayerController playerController;
     PlayerMovement playerMovement;
     AnimatorManager animatorManager;
     
     public Vector2 movementInput;
     public Vector2 camInput;

     public float camInputX;
     public float camInputY;
     
     public float moveAmount;
     public float verticalInput;
     public float horizontalInput;

     public bool b_Input;
     public bool jump_Input;

     private void Awake()
     {
          animatorManager = GetComponent<AnimatorManager>();
          playerMovement = GetComponent<PlayerMovement>();
     }

     private void OnEnable()
     {
          if (playerController == null)
          {
               playerController = new PlayerController();
               playerController.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>(); //Quando alguma tecla (WASD) é pressionada, o movimento será gravado na variável
               playerController.PlayerMovement.Camera.performed += i => camInput = i.ReadValue<Vector2>();

               playerController.PlayerActions.B.performed += i => b_Input = true;
               playerController.PlayerActions.B.canceled += i => b_Input = false;
               
               playerController.PlayerActions.Jump.performed += i => jump_Input = true;
          }
          playerController.Enable();
     }

     private void OnDisable()
     {
          playerController.Disable();
     }

     public void HandleAllInputs()
     {
          HandleMovementInput();
          HandleSprint();
          HandleJumpInput();
          //HandleActionInput
     }

     private void HandleMovementInput()
     {
          verticalInput = movementInput.y;
          horizontalInput = movementInput.x;

          camInputY = camInput.y;
          camInputX = camInput.x;
          
          moveAmount = Mathf.Clamp01(movementInput.magnitude);// mover dentro dos valores de -1 e 1
          animatorManager.UpdateAnimatorValues(0, moveAmount, playerMovement.isSprinting);
     }
     
     private void HandleSprint()
     {
          if (b_Input && moveAmount > 0.5f)
          {
               playerMovement.isSprinting = true;

          }
          else
          {
               playerMovement.isSprinting = false;
          }
     }

     private void HandleJumpInput()
     {
          if (jump_Input == true)
          {
               jump_Input = false;
               playerMovement.HandleJump();
          }
     }
}
