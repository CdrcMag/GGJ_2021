using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player_Movement : MonoBehaviour
{
    //Movement speed
    public float speed;

    //Mouse speed
    public float lookSpeed = 3;

    //Rotation X max of camera
    public float maxXRotation;

    private Vector2 rotation = Vector2.zero;
    private CharacterController controller;
    
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //Look around you
        Look();

        Vector3 dir = Vector3.zero;

        if (Input.GetAxisRaw("Vertical") > 0.1f)
            dir = dir + transform.forward;
        
        if (Input.GetAxisRaw("Vertical") < -0.1f)
            dir = dir + -transform.forward;
        
        if (Input.GetAxisRaw("Horizontal") > 0.1f)
            dir = dir + transform.right;
        
        if (Input.GetAxisRaw("Horizontal") < -0.1f)
            dir = dir + -transform.right;

        dir.y = -9.81f;

        dir.Normalize();

        controller.Move(dir * speed);


    }

   


    public void Look()
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");

        rotation.x = Mathf.Clamp(rotation.x, -maxXRotation, maxXRotation);
        transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;
        Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);
    }

}
