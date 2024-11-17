using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class moveman : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runningSpeed;
    [SerializeField] private float walkSpeed;
    public float smoothTime = 0.1f;
    private Vector3 moveVertical;
    private Vector3 moveHorizontal;
    float turnSmoothVelocity;

    public Transform cam;

    //private Inventory inventory;
    //test edit
    
    //Gravity
    [SerializeField] private float gravity;
    [SerializeField] private float currentGravity;
    [SerializeField] private float constantGravity;
    [SerializeField] private float maxGravity;

    [SerializeField] private stamina stamina;
    //[SerializeField] private UIInventory uiInventory;

    private Vector3 gravityDirection;
    private Vector3 gravityMovement;
    
    private CharacterController controller;
    private Animator anim;

    [SerializeField] private bool onFlash;

    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        CalculateGravity();
        anim = GetComponent<Animator>();
    }

    private void Awake()
    {
        gravityDirection = Vector3.down;

        //inventory = new Inventory();
        //uiInventory.SetInventory(inventory);
    }

    //Gravity
    private bool isGrounded()
    {
        return controller.isGrounded;
    }
    private void CalculateGravity()
    {
        if (isGrounded())
        {
            gravity = constantGravity;
        }
        else
        {
            if (currentGravity > maxGravity)
            {
                currentGravity -= gravity * Time.deltaTime;
            }
        }
        gravityMovement = gravityDirection * -currentGravity * Time.deltaTime;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        moveVertical = new Vector3(0,0,vertical);
        moveHorizontal = new Vector3(horizontal,0,0);
        
        Vector3 directonWalk = new Vector3(horizontal, 0f, vertical).normalized;
        
        if (directonWalk.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(directonWalk.x, directonWalk.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime + gravityMovement);
        }
        if ((moveVertical != Vector3.zero || moveHorizontal != Vector3.zero) && Input.GetKey(KeyCode.LeftShift))
        {
            stamina.isRun = true;
            if (stamina.Stamina == 0)
            {
                walk();
            }
            else
            {
                run();
            }
            
        }
        else if ((moveVertical != Vector3.zero || moveHorizontal != Vector3.zero) && !Input.GetKey(KeyCode.LeftShift))
        {
            stamina.isRun = false;
            walk();
        }
        else if(moveVertical == Vector3.zero || moveHorizontal == Vector3.zero)
        {
            stamina.isRun = false;
            Idle();
        }
        

        flashBehaviour();
    }
    
    private void Idle()
    {
        anim.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
    }
    private void run()
    {
        speed = runningSpeed;
        anim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
    }

    private void walk()
    {
        speed = walkSpeed;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }
    private void flashBehaviour()
    {
        //ChangeToBlendFlashLightBehaviour
        if (Input.GetKeyDown(KeyCode.F))
        {
            onFlash = !onFlash;
            if (onFlash == false)
            {
               anim.ResetTrigger("onFlashlight"); 
            }
            if (onFlash == true)
            {
               anim.SetTrigger("onFlashlight"); 
            }
        }
    }
}
