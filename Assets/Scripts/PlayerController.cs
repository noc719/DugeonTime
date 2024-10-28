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

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 moveDir = new Vector3(dir.x,0, dir.y)*speed;
        _rigidbody.velocity = new Vector3(moveDir.x,_rigidbody.velocity.y,moveDir.z);
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * power, ForceMode.Impulse);
        //Ray를 쏴서 지면과 일정이상 멀어지면 점프가 안되도록
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
}