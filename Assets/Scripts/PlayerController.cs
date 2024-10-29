using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    //구현 해야할 것 우선사항
    //화면 시점
    [Header("Move")]

    [SerializeField] private float speed;
    Vector3 dir = Vector3.zero;

    [Header("Jump")]

    [SerializeField] private float power;
    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Debug.DrawRay(transform.position + (transform.forward * 0.5f)+(transform.right*0.6f) + (transform.up * 0.1f), Vector3.down);
        Debug.DrawRay(transform.position + (transform.forward * 0.5f) -(transform.right * 0.6f) + (transform.up * 0.1f), Vector3.down);
        Debug.DrawRay(transform.position - (transform.forward *0.5f ) + (transform.right * 0.6f) + (transform.up * 0.1f), Vector3.down);
        Debug.DrawRay(transform.position - (transform.forward * 0.5f ) - (transform.right * 0.6f) + (transform.up * 0.1f), Vector3.down);
    }

    private void Move()
    {
        Vector3 moveDir = new Vector3(dir.x,0, dir.y)*speed;
        _rigidbody.velocity = new Vector3(moveDir.x,_rigidbody.velocity.y,moveDir.z);
    }

    private void Jump()
    {
        if (!isGrounded()) return;
        _rigidbody.AddForce(Vector3.up * power, ForceMode.Impulse);
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

    private bool isGrounded()
    {
        if(Physics.Raycast(new Ray(transform.position + (transform.forward * 0.5f) + (transform.right * 0.6f) + (transform.up * 0.1f), Vector3.down), 0.3f, groundLayer)&&
           Physics.Raycast(new Ray(transform.position + (transform.forward * 0.5f) - (transform.right * 0.6f) + (transform.up * 0.1f), Vector3.down), 0.3f, groundLayer)&&
           Physics.Raycast(new Ray(transform.position - (transform.forward * 0.5f) + (transform.right * 0.6f) + (transform.up * 0.1f), Vector3.down), 0.3f, groundLayer)&&
           Physics.Raycast(new Ray(transform.position - (transform.forward * 0.5f) - (transform.right * 0.6f) + (transform.up * 0.1f), Vector3.down), 0.3f, groundLayer))
        {
            return true;
        }
        return false;
    }
}