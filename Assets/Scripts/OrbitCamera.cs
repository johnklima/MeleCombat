using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{

    [Header("Camera Target")]
    public GameObject target;
    private Transform cameraPos;
    private Vector3 targetCameraBobPos;

    [Header("Camera Settings")]
    [Range(0f, 20f)]
    public float mouseSensitivity = 10;
    [Range(0f, 10f)]
    public float keySensitivity = 5;

    public float dstFromTarget = 2;
    public Vector2 pitchMinMax = new Vector2(-40, 85);
    public float rotationSmoothTime = .12f;

       

    [Header("Cursor Check")]
    public bool lockCursor;
    public bool lockMovement;

    [Header("Input Control")]
    public bool usingMouse;
    public bool usingKeys;

    Vector3 rotationSmoothVelocity;
    public Vector3 currentRotation;

    public float yaw;
    public float pitch;


    // Start is called before the first frame update
    void Start()
    {// Assigning the private variable to the Camera Game Component
        cameraPos = this.gameObject.transform;

        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        //initialize pitch to -1
        pitch = -1;
    }

    // LateUpdate is called once per frame, after everything else
    void LateUpdate()
    {
        CameraMovement();
    }

    void CameraMovement()
    {
        
        //if using mouse
        if(usingMouse)
        {
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        }
        if(usingKeys)
        {
            yaw += Input.GetAxis("Horizontal") * keySensitivity;
            pitch -= Input.GetAxis("Vertical") * keySensitivity;
        }
        
        
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;

        transform.position = target.transform.position - transform.forward * dstFromTarget;
    }
    public void SetPitchYaw()
    {
        currentRotation = transform.eulerAngles;
    }

}
