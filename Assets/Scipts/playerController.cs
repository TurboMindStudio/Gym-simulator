using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class playerController : MonoBehaviour
{
    [Range(0f, 50f)]
    [SerializeField] float walkSpeed;
    [SerializeField] CharacterController cc;
    [SerializeField] Transform cam;
    float turnSmoothVelocity;
    float smooth_Time = 0.1f;
    private Vector3 direction;
    public bool canMove;
    private void Awake()
    {

       // Cursor.lockState = CursorLockMode.Locked;
       // Cursor.visible = false;
    }
    private void Start()
    {

        canMove = true;
        cc=GetComponent<CharacterController>();
        
    }

    private void Update()
    {
        if(canMove)
        {
           
            float horizontal = Input.GetAxis("Horizontal");
            float Vertical = Input.GetAxis("Vertical");

            direction = new Vector3(horizontal, 0, Vertical);
        }
        
        

       
    }

    private void FixedUpdate()
    {
        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smooth_Time);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir= Quaternion.Euler(0f, targetAngle, 0f)*Vector3.forward;
           // Vector3 move = transform.right * horizontal + transform.forward * Vertical;
            cc.Move(moveDir.normalized * walkSpeed * Time.deltaTime);
        }
        
    }
}
