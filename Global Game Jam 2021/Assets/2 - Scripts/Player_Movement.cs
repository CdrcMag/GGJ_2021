using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player_Movement : MonoBehaviour
{
    public float speed;

    private CharacterController controller;

    private Vector3 dir;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Look();


       if (Input.GetAxisRaw("Vertical") > 0.1f)
       {
            controller.Move(transform.forward * speed);
       }
        if (Input.GetAxisRaw("Vertical") < -0.1f)
        {
            controller.Move(-transform.forward * speed);
        }
    }

    public float lookSpeed = 3;
    private Vector2 rotation = Vector2.zero;
    public void Look()
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
        transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;
        Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);
    }

}
