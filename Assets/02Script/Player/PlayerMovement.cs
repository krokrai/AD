using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] LayerMask ground;

    Rigidbody2D _rb;

    public float movement { get; private set; }

    [SerializeField]float _rayDistance;
    float _jumpPower;
    float _moveSpeed;
    bool _jump;
    bool _canJump;


    private void FixedUpdate()
    {
        _rb.linearVelocityX = movement;

        if (_jump)
        {
            _rb.linearVelocityY = _jumpPower;
            _jump = false;
        }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, _rayDistance, ground))
        {
            _canJump = true;
        }
        else
        {
            _canJump = false;
        }
    }

    public void InitState(float speed, float jump)
    {
        _moveSpeed = speed;
        _jumpPower = jump;
        Debug.Log("플레이어 이동 관련 능력치 초기화 완료");
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        movement = ctx.ReadValue<Vector2>().x;
        switch (movement)
        {
            case -1:
                transform.rotation = Quaternion.Euler(0,0,180);
                break;
            case 1:
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }
        movement = movement * _moveSpeed;
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && _canJump)
        {
            _jump = true;
            _canJump = false;
        }
            
    }
}
