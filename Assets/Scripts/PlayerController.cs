using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    //구현 해야할 것 우선사항
    //이동
    //점프
    //화면 시점
    [Header("Move")]
    [SerializeField] private float speed;
    Vector3 dir = Vector3.zero;

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
        Vector3 moveDir = new Vector3(dir.x, 0, dir.y);
        Debug.Log(moveDir);
        _rigidbody.velocity = moveDir*speed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            dir = context.ReadValue<Vector2>();
            Debug.Log(dir);
        }

        if(context.phase == InputActionPhase.Canceled)
        {
            dir = Vector3.zero;
        }
    }
}