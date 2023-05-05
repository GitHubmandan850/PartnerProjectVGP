using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
 {
    public int walkingSpeed, runningSpeed;
    public int movementSpeed;
    public float turnSmoothTime;
 
    public bool isSprinting;

    Vector3 velocity;
    public float gravity = -9.8f;
    bool isGrounded;
 
    CharacterController charController;
    public Transform playerCamera;
 
     // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();    
    }
 
     // Update is called once per frame
    void Update()
    {
        Movement();
    }
 
    void Movement() 
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputZ = Input.GetAxisRaw("Vertical");
        isSprinting = Input.GetKey(KeyCode.LeftShift);
 
        Vector3 moveDir = new Vector3(inputX, 0, inputZ).normalized;
        movementSpeed = isSprinting ? runningSpeed : walkingSpeed;
 
        transform.rotation = Quaternion.Euler(0f, playerCamera.eulerAngles.y, 0f);
 
        Vector3 moveAmount = moveDir * movementSpeed;
        velocity.y += gravity * Time.deltaTime;
        moveAmount.y = velocity.y;
 
        charController.Move(moveAmount *  Time.deltaTime);
     }
 }