using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
        private float speed=7.0f;
    private Vector3 moveVector;
    
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
       if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }


        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxisRaw("Horizontal")*speed;
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > Screen.width / 2)
            {
                moveVector.x = speed;
            }
            else
            {
                moveVector.x= -speed;
            }
        }
        
       moveVector.y = Input.GetAxisRaw("Vertical") * speed;
        moveVector.z = speed;
        
        controller.Move(moveVector * Time.deltaTime);
    }
}
