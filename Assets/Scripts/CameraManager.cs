using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    InputManager inputManager;
    
    public Transform targetTransform;// o que a câmera vai seguir
    private Vector3 camFollowVelocity = Vector3.zero;
    public Transform camPivot;//Objeto pivô da câmera
    private float defaultPosition;
    public Transform camTransform;//Transform da câmera na cena
    public LayerMask collisionLayers;// Com qual layer a câmera vai colidir
    private Vector3 camVectorPosition;

    public float camCollisionOffSet = 0.2f;//Quanto a câmera irá mexer quando colidi com objetos
    public float minCollisionOffSet = 0.2f;
    public float camfollowSpeed = 0.2f;
    public float camLookSpeed = 2;
    public float camPivotSpeed = 2;
    public float camCollisionRadius = 0.2f;
    
    public float lookAngle;//câmera olhar para cima e para baixo
    public float pivotAngle;//câmera olhar para a esquerda e direita

    public float minPivotAngle = -35;//movimentar a cãmera pra cima e para baixo
    public float maxPivotAngle = 35;

    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
        targetTransform = FindObjectOfType<PlayerManager>().transform;
        camTransform = Camera.main.transform;
        defaultPosition = camTransform.localPosition.z;
    }

    public void HandleAllCameraMovement()
    {
        FollowTarget();
        RotateCamera();
        HandleCameraCollisions();
    }

    private void FollowTarget() //seguir alguma coisa]
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref camFollowVelocity, camfollowSpeed);
        transform.position = targetPosition;
    }

    private void RotateCamera()
    {
        Vector3 rotation;
        Quaternion targetRotation;
        
        lookAngle = lookAngle + (inputManager.camInputX * camLookSpeed);
        pivotAngle = pivotAngle - (inputManager.camInputY * camPivotSpeed);
        pivotAngle = Mathf.Clamp(pivotAngle, minPivotAngle, maxPivotAngle);

        rotation = Vector3.zero;
        rotation.y = lookAngle;
        targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        camPivot.localRotation = targetRotation;
    }

    private void HandleCameraCollisions()
    {
        float targetPosition = defaultPosition;
        RaycastHit hit;
        Vector3 direction = camTransform.position - camPivot.position;
        direction.Normalize();

        if (Physics.SphereCast(camPivot.transform.position, camCollisionRadius, direction, out hit, Mathf.Abs(targetPosition), collisionLayers))
        {
            float distance = Vector3.Distance(camPivot.position, hit.point);
            targetPosition = targetPosition =- (distance - camCollisionOffSet);
        }

        if (Mathf.Abs(targetPosition) < minCollisionOffSet)
        {
            targetPosition = targetPosition - minCollisionOffSet;
        }

        camVectorPosition.z = Mathf.Lerp(camTransform.localPosition.z, targetPosition, 0.2f);
        camTransform.localPosition = camVectorPosition;
    }
}