using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [Header("Move")]

    [SerializeField] private float speed;
    Vector3 dir;

    [Header("Jump")]
    [SerializeField] private float power;
    [SerializeField] private LayerMask groundLayer;

    [Header("Look")]
    private Camera cam;
    [SerializeField] private float camSpeed;
    [SerializeField] private float camMinRotate;
    [SerializeField] private float camMaxRotate;
    private Vector3 mouseDir;
    private float curXRotation;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        Look();
    }

    private void Move()
    {
        Vector3 moveDir = (transform.forward * dir.y + transform.right * dir.x) * speed;
        moveDir.y = _rigidbody.velocity.y;
        _rigidbody.velocity = moveDir;

    }

    private void Jump()
    {
        if (!isGrounded()) return;
        _rigidbody.AddForce(Vector3.up * power, ForceMode.Impulse);
    }

    private void Look()
    {
        curXRotation -= mouseDir.y*camSpeed;
        curXRotation = Mathf.Clamp(curXRotation, camMinRotate, camMaxRotate);
        cam.transform.localEulerAngles = new Vector3(curXRotation,0,0);

        transform.localEulerAngles += new Vector3(0,mouseDir.x,0); 
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            dir = context.ReadValue<Vector2>();
        }

        if(context.phase == InputActionPhase.Canceled)
        {
            dir = Vector3.zero;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            Jump();
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDir = context.ReadValue<Vector2>();
    }

    private bool isGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.5f) + (transform.right * 0.6f) + (transform.up * 0.1f),Vector3.down),
            new Ray(transform.position + (transform.forward * 0.5f) + (transform.right * 0.6f) + (transform.up * 0.1f),Vector3.down),
            new Ray(transform.position + (transform.forward * 0.5f) + (transform.right * 0.6f) + (transform.up * 0.1f),Vector3.down),
            new Ray(transform.position + (transform.forward * 0.5f) + (transform.right * 0.6f) + (transform.up * 0.1f),Vector3.down)
        };

        for(int i = 0; i<rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.2f, groundLayer))
            {
                return true;
            }
        }
        return false;
    }
}