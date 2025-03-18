using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    FPCam firstPersonCamera;
    Movement movement;
    PlayerInteraction playerInteraction;

    void Start()
    {
        firstPersonCamera = GetComponent<FPCam>();
        movement = GetComponent<Movement>();   
        playerInteraction = GetComponent<PlayerInteraction>();  
    }

    void Update()
    {
        HandleCameraInput();
        HandleMoveInput();
        HandleInteractionInput();
    }

    void HandleCameraInput()
    {
        firstPersonCamera.AddXAxisInput(Input.GetAxis("Mouse Y") * Time.deltaTime);
        firstPersonCamera.AddYAxisInput(Input.GetAxis("Mouse X") * Time.deltaTime);
    }

    void HandleMoveInput()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float rightInput= Input.GetAxis("Horizontal");

        movement.AddMoveInput(forwardInput, rightInput);
    }

    void HandleInteractionInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerInteraction.TryInteract();
        }
    }
}
