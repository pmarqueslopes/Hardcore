using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerMovement playerMovement;
    Animator animator;
    CameraManager camManager;
    public Inventory inventoryScript;
    public GameObject inventory;
    public GameObject equipSystem;
    bool showInventory = false;
    public bool crafting = true;
    //bool inEquipSystemRange = false;

    public bool isInteracting;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponentInChildren<Animator>();
        //camManager = FindObjectOfType<CameraManager>();
        inventoryScript = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        inventory = GameObject.FindGameObjectWithTag("AllInventory");
        equipSystem = GameObject.FindGameObjectWithTag("Equip System");
        inventory.SetActive(false);
        equipSystem.SetActive(false);
    }

    public void Update()
    {
        inputManager.HandleAllInputs();

        if (Input.GetKeyDown(KeyCode.I))
        {
            if(crafting)
            {
                if (showInventory == true)
                {
                    DesactivateInventory();
                }
                else
                {
                    ActivateInventory();
                }
            }

        }


        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                float distance = Vector3.Distance(hit.transform.position, this.transform.position);

                if (hit.transform.tag == "Item" && distance <= 3)
                {
                    inventoryScript.AddExistingItem(hit.transform.GetComponent<DroppedItem>().item);
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }

    public void FixedUpdate()
    {
        playerMovement.HandleAllMovement();
    }

    public void LateUpdate()
    {
        //camManager.HandleAllCameraMovement();

        isInteracting = animator.GetBool(("isInteracting"));

        playerMovement.isJumping = animator.GetBool("isJumping");

        animator.SetBool("isGrounded", playerMovement.isGrounded);
    }

    public void ActivateInventory()
    {
        showInventory = true;
        inventory.SetActive(true);
        equipSystem.SetActive(true);
    }
    public void DesactivateInventory()
    {
        showInventory = false;
        inventory.SetActive(false);
        equipSystem.SetActive(false);
    }
}